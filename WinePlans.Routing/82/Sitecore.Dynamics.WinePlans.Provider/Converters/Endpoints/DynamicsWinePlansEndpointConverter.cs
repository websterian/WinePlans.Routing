// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicsEndpointConverter.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Sitecore.Dynamics.WinePlans.Provider.Converters.Endpoints
{
    using Sitecore.DataExchange.Converters.Endpoints;
    using Sitecore.DataExchange.Models;
    using Sitecore.DataExchange.Repositories;
    using Sitecore.Services.Core.Model;

    /// <summary>
    ///     Defines the dynamics WinePlans endpoint converter
    /// </summary>
    /// <seealso cref="DynamicswinePlanEndpointConverter" />
    public class DynamicswinePlanEndpointConverter : BaseEndpointConverter<ItemModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicswinePlanEndpointConverter"/> class. 
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        public DynamicswinePlanEndpointConverter(IItemModelRepository repository)
            : base(repository)
        {
        }

        /// <summary>
        /// The add plugins.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="endpoint">
        /// The endpoint.
        /// </param>
        protected override void AddPlugins(ItemModel source, Endpoint endpoint)
        {
            
        }
    }
}