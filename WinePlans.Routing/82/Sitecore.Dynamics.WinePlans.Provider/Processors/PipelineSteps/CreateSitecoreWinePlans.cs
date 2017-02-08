// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateSitecoreWinePlans.cs" company="">
// </copyright>
// <summary>
//   Create Sitecore WinePlans class
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Sitecore.Dynamics.WinePlans.Provider.Processors.PipelineSteps
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;

    using global::Microsoft.OData.Client;

    using Sitecore.DataExchange;
    using Sitecore.DataExchange.Contexts;
    using Sitecore.DataExchange.Models;
    using Sitecore.DataExchange.Processors.PipelineSteps;
    using Sitecore.Dynamics.WinePlans.Provider.Managers;
    using Sitecore.Dynamics.WinePlans.Provider.Microsoft.Dynamics.DataEntities;
    using Sitecore.Dynamics.WinePlans.Provider.Models;
    using Sitecore.Services.Core.Model;

    /// <summary>
    ///     Create Sitecore WinePlans class
    /// </summary>
    public class CreateSitecoreWinePlans : BasePipelineStepProcessor
    {
        private readonly List<ItemModel> _createdWinePlans = new List<ItemModel>();
        private readonly Stopwatch _masterStopWatch = new Stopwatch();
        private readonly Stopwatch _stopwatch = new Stopwatch();

        private static PipelineContext _pipeLineContext;

        private const string WinePlanTemplateId = "{B1461031-56BE-4FCC-9766-D855B0D3F761}";

        private const string Description = "Description";
        private const string EndDate = "End date";
        private const string ItemId = "ItemID";
        private const string ItemName = "ItemName";
        private const string Name = "Name";
        private const string StartDate = "Start date";
        private const string TemplateId = "TemplateID";
        private const string TemplateName = "TemplateName";

        /// <summary>
        /// Processes the specified route context.
        /// </summary>
        /// <param name="pipelineStep"></param>
        /// <param name="pipelineContext"></param>
        public override void Process(PipelineStep pipelineStep, PipelineContext pipelineContext)
        {
            _pipeLineContext = pipelineContext;
            try
            {
                this.ProcessWinePlans();
            }
            catch (Exception e)
            {
                Log($"The process failed : {e.Message}", ConsoleColor.Red);
                throw;
            }
        }

       private static void Log(string message, ConsoleColor color = ConsoleColor.Green)
        {
            _pipeLineContext.PipelineBatchContext.Logger.Info(message);
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

       private void ProcessWinePlans()
        {
            Log("Processing Dynamics WinePlans...", ConsoleColor.Yellow);
            this._stopwatch.Start();
            foreach (var dynamicswinePlan in GetWinePlans())
            {
                var existing = true;
                var itemId = string.Empty;

                var winePlan = FindWinePlan(dynamicswinePlan.Name);

                if (winePlan == null)
                {
                    existing = false;
                }
                else
                {
                    itemId = winePlan[ItemId].ToString();
                }

                winePlan = new ItemModel
                {
                    [TemplateId] = WinePlanTemplateId, 
                    [ItemName] = dynamicswinePlan.Name, 
                    [Name] = dynamicswinePlan.Name, 
                    [Description] = dynamicswinePlan.Description, 
                    [StartDate] = MapToSitecoreDate(dynamicswinePlan.StartDate), 
                    [EndDate] = MapToSitecoreDate(dynamicswinePlan.EndDate)
                };

                if (existing)
                {
                    Log($"Updating Wine Plan {winePlan[ItemName]}");
                    winePlan[ItemId] = itemId;
                    UpdateItemModel(winePlan);
                }
                else
                {
                    Log($"Creating Wine Plan {winePlan[ItemName]}");
                    CreateItemModel("/ sitecore / content / Storefront / Home / WinePlansPage", winePlan);
                }

                this._createdWinePlans.Add(winePlan);
            }

            Log($"Processing Dynamics Wine Plans completed in {GetElapsedTimeAsString(this._stopwatch)}", ConsoleColor.Yellow);
        }

        #region ApiCalls

        private static void UpdateItemModel(ItemModel item)
        {
            Guid id;
            if (Guid.TryParse(item[ItemId].ToString(), out id))
            {
                Context.ItemModelRepository.Update(id, item);
            }
        }

        private static void CreateItemModel(string path, ItemModel item)
        {
            Guid parentId;

            var parentItem = Context.ItemModelRepository.Get(path);

            if (!Guid.TryParse(parentItem[ItemId].ToString(), out parentId))
            {
                return;
            }

            var id = Context.ItemModelRepository.Create(item[ItemName].ToString(), Guid.Parse(item[TemplateId].ToString()), parentId);
            item[ItemId] = id;
            UpdateItemModel(item);
        }

        private static ItemModel GetSingleItemFromPath(string findPath)
        {
            return Context.ItemModelRepository.Get(findPath);
        }

        private static List<ItemModel> GetItemsFromPath(string path)
        {
            var item = Context.ItemModelRepository.Get(path);
            Guid id;
            return Guid.TryParse(item[ItemId].ToString(), out id) ? Context.ItemModelRepository.GetChildren(id).ToList() : new List<ItemModel>();
        }

        #endregion

       private static ItemModel FindWinePlan(string winePlanName)
        {
            var findPath = "/sitecore/content/Storefront/Home/WinePlansPage/" + winePlanName;

            var winePlan = GetSingleItemFromPath(findPath);
            return winePlan;
        }

        private static string GetElapsedTimeAsString(Stopwatch stopwatch)
        {
            var ts = stopwatch.Elapsed;
            var elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";

            return elapsedTime;
        }
       
        private static IEnumerable<DynamicsWinePlan> GetWinePlans()
        {
            var winePlans = new List<DynamicsWinePlan>();
            var ODataEntityPath = Managers.ClientConfiguration.Default.UriString + "data";
            var oDataUri = new Uri(ODataEntityPath, UriKind.Absolute);
            var resources = new Resources(oDataUri);
            resources.SendingRequest2 += 
                delegate (object sender, SendingRequest2EventArgs e)
                    {
                        var authenticationHeader = OAuthHelper.GetAuthenticationHeader();
                        e.RequestMessage.SetHeader(OAuthHelper.OAuthHeader, authenticationHeader);
                    };

            var axWinePlans = 
                // resources.WinePlans.Where(x => x.DataAreaId == "USRT");
            resources.CreateQuery<WinePlan>("WinePlans").AddQueryOption("filter", "DataAreaId eq 'usrt'").AddQueryOption("cross-company", true);

            foreach (var axwinePlan in axWinePlans)
            {
                var winePlan = new DynamicsWinePlan
                                   {
                                       Description = axwinePlan.WinePlanDescription, 
                                       StartDate = axwinePlan.StartDateTime.Date, 
                                       EndDate = axwinePlan.EndDateTime.Date, 
                                       Name = axwinePlan.WinePlanName
                                   };

                winePlans.Add(winePlan);
            }

            return winePlans;
        }

        public static DateTime MapFromSitecoreDate(string dateAsString) =>
           DateUtil.ParseDateTime(dateAsString, DateTime.MinValue, CultureInfo.InvariantCulture);

        public static string MapToSitecoreDate(DateTime date) =>
            date.ToString("yyyyMMddTHHmmss", CultureInfo.InvariantCulture);
    }
}