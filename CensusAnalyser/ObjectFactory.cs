//-----------------------------------------------------------------------
// <copyright file="ObjectFactory.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace CensusAnalyser
{
    using System;

    /// <summary>
    /// Class for Object Creation
    /// </summary>           
    /// <seealso cref="CensusAnalyser.Factory" />
    public class ObjectFactory : Factory
    {
        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="path">The path.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="header">The header.</param>
        /// <returns>It returns object</returns>
        /// <exception cref="ApplicationException">Object cannot be created</exception>
        public override ICSVBuilder GetObject(string className, string path, char delimiter, string header)
        {
            switch (className)
            {
                case "CSVStateCensus":
                    return new CSVStateCensus(path, delimiter, header);
                case "CSVStates":
                    return new CSVStates(path, delimiter, header);
                default:
                    throw new ApplicationException(string.Format("Object of class {0} cannot be created", className));
            }
        }
    }
}