// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace DataExchange.Commerce.Sdk.Console
{
    using System;
    using System.Configuration;
    using System.Linq;
    using Sitecore.DataExchange;
    using Sitecore.DataExchange.Remote.Http;
    using Sitecore.DataExchange.Remote.Repositories;
    using Sitecore.DataExchange.Remote.Runners;
    using Sitecore.DataExchange.Repositories.PipelineBatches;

    /// <summary>
    ///     Host console app sample to demonstrate doing the Channel Extraction Process
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">
        /// The arguments.
        /// </param>
        private static void Main(string[] args)
        {
            try
            {
                Context.Logger = new ConsoleLogger();
                Context.PipelineBatchRepository = new SitecorePipelineBatchRepository();
                var connectionSettings = new ConnectionSettings
                                             {
                                                 Host = ConfigurationManager.AppSettings.Get("Host"), 
                                                 UserName =
                                                     ConfigurationManager.AppSettings.Get("UserName"), 
                                                 Password =
                                                     ConfigurationManager.AppSettings.Get("Password")
                                             };
                Context.ItemModelRepository =
                    new WebApiItemModelRepository(
                        ConfigurationManager.AppSettings.Get("SitecoreDatabase"), 
                        connectionSettings);

                var tenants = Context.PipelineBatchRepository.GetTentants().ToList();
                if (!tenants.Any())
                {
                    Context.Logger.Error("No tenants were found");
                    return;
                }

                var tenantName = ConfigurationManager.AppSettings.Get("TenantName");
                var tenant = tenants.FirstOrDefault(t => t.Name.Equals(tenantName, StringComparison.OrdinalIgnoreCase));
                if (tenant == null)
                {
                    Context.Logger.Error("'{0}' tenant was not found", tenantName);
                    return;
                }

                var pipelineBatchs = Context.PipelineBatchRepository.GetPipelineBatches(tenant.ID, true).ToList();
                if (!pipelineBatchs.Any() || pipelineBatchs.FindAll(x => x.Name.Contains("Dynamics WinePlans batch")).Count == 0)
                {
                    Context.Logger.Error("Pipeline batches for tenant '{0}' were not found", tenantName);
                    return;
                }

                var runner = new RemotePipelineBatchRunner();
                foreach (var pipelineTask in pipelineBatchs.FindAll(x => x.Name.Contains("Dynamics WinePlans batch")))
                {
                    Context.Logger.Info("Pipeline batch '{0}' starting", pipelineTask.Name);
                    var done = runner.Run(pipelineTask);

                    Context.Logger.Info(
                        done ? "Pipeline batch '{0}' completed" : "Pipeline batch '{0}' did not complete", 
                        pipelineTask.Name);
                }
            }
            catch (Exception ex)
            {
                Context.Logger.Error(ex.ToString());
            }
        }
    }
}