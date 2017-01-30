// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicsPipelineProcessor.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Sitecore.Dynamics.WinePlans.Provider.Processors.Pipelines
{
    using Sitecore.DataExchange.Contexts;
    using Sitecore.DataExchange.Models;
    using Sitecore.DataExchange.Processors.Pipelines;

    /// <summary>
    ///     Defines the dynamics pipeline converter
    /// </summary>
    /// <seealso cref="DynamicswinePlanPipelineProcessor" />
    public class DynamicswinePlanPipelineProcessor : PipelineProcessor
    {
        /// <summary>
        /// Processes the specified pipeline.
        /// </summary>
        /// <param name="pipeline">
        /// The pipeline.
        /// </param>
        /// <param name="pipelineContext">
        /// The pipeline context.
        /// </param>
        public override void Process(Pipeline pipeline, PipelineContext pipelineContext)
        {
            base.Process(pipeline, pipelineContext);
        }
    }
}