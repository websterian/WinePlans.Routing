// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicsWinePlan.cs" company="">
//   
// </copyright>
// <summary>
//   The dynamics winePlan.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Sitecore.Dynamics.WinePlans.Provider.Models
{
    /// <summary>
    /// The dynamics winePlan.
    /// </summary>
    public class DynamicsWinePlan
    {
        
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }      

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        public System.DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public System.DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the template id.
        /// </summary>
        public string TemplateId { get; set; }
    }
}