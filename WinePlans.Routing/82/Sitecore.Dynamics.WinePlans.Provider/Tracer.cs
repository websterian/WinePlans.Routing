// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tracer.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Sitecore.Dynamics.WinePlans.Provider
{
    using System.Diagnostics;

    /// <summary>
    ///     Provides a tracing diagnostics class
    /// </summary>
    public static class Tracing
    {
        /// <summary>
        ///     The _trace source.
        /// </summary>
        private static TraceSource _traceSource;

        /// <summary>
        ///     Gets the instance of the TraceSwitch
        /// </summary>
        public static TraceSource Tracer
        {
            get
            {
                if (_traceSource == null)
                {
                    _traceSource = new TraceSource("DynamicsRetail.Routing");
                }

                return _traceSource;
            }
        }
    }
}