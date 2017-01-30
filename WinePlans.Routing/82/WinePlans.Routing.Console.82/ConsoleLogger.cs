// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleLogger.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace DataExchange.Commerce.Sdk.Console
{
    using System;
    using System.Globalization;

    using Sitecore.Services.Core.Diagnostics;

    /// <summary>
    ///     Defines the console logger
    /// </summary>
    /// <seealso cref="Sitecore.Services.Core.Diagnostics.ILogger" />
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConsoleLogger" /> class.
        /// </summary>
        public ConsoleLogger()
        {
            this.Prefix = "Data Exchange";
        }

        /// <summary>
        ///     Gets or sets the prefix.
        /// </summary>
        /// <value>
        ///     The prefix.
        /// </value>
        public string Prefix { get; set; }

        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Debug(string message)
        {
            Console.WriteLine(this.Format(message));
        }

        /// <summary>
        /// Debugs the specified message format.
        /// </summary>
        /// <param name="messageFormat">
        /// The message format.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public void Debug(string messageFormat, params object[] args)
        {
            this.Debug(string.Format(CultureInfo.InvariantCulture, messageFormat, args));
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(this.Format(message), this);
            Console.ResetColor();
        }

        /// <summary>
        /// Errors the specified message format.
        /// </summary>
        /// <param name="messageFormat">
        /// The message format.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public void Error(string messageFormat, params object[] args)
        {
            this.Error(string.Format(CultureInfo.InvariantCulture, messageFormat, args));
        }

        /// <summary>
        /// Fatals the specified message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Fatal(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(this.Format(message), this);
            Console.ResetColor();
        }

        /// <summary>
        /// Fatals the specified message format.
        /// </summary>
        /// <param name="messageFormat">
        /// The message format.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public void Fatal(string messageFormat, params object[] args)
        {
            this.Fatal(string.Format(CultureInfo.InvariantCulture, messageFormat, args));
        }

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(this.Format(message), this);
            Console.ResetColor();
        }

        /// <summary>
        /// Informations the specified message format.
        /// </summary>
        /// <param name="messageFormat">
        /// The message format.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public void Info(string messageFormat, params object[] args)
        {
            this.Info(string.Format(CultureInfo.InvariantCulture, messageFormat, args));
        }

        /// <summary>
        /// Warns the specified message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(this.Format(message), this);
            Console.ResetColor();
        }

        /// <summary>
        /// Warns the specified message format.
        /// </summary>
        /// <param name="messageFormat">
        /// The message format.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public void Warn(string messageFormat, params object[] args)
        {
            this.Warn(string.Format(CultureInfo.InvariantCulture, messageFormat, args));
        }

        /// <summary>
        /// Formats the specified message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// A string formated
        /// </returns>
        private string Format(string message)
        {
            return string.Format(CultureInfo.InvariantCulture, "[{0}] {1}", this.Prefix, message);
        }
    }
}