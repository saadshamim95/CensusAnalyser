//-----------------------------------------------------------------------
// <copyright file="Factory.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace CensusAnalyser
{
    /// <summary>
    /// Factory Class
    /// </summary>
    public abstract class Factory
    {
        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="path">The path.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="header">The header.</param>
        /// <returns>It returns object</returns>
        public abstract ICSVBuilder GetObject(string className, string path, char delimiter, string header);
    }
}