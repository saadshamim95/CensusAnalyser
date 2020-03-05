//-----------------------------------------------------------------------
// <copyright file="CustomException.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace CensusAnalyser
{
    using System;

    /// <summary>
    /// Class for Custom Exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CustomException : Exception
    {
        /// <summary>
        /// The message
        /// </summary>
        private string message;

        /// <summary>
        /// The type
        /// </summary>
        private TypeOfException type;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        public CustomException()
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        public CustomException(string message, TypeOfException type)
        {
            this.message = message;
            this.type = type;
        }

        /// <summary>
        /// Enum for Exception Type
        /// </summary>
        public enum TypeOfException
        {
            /// <summary>
            /// The file not found
            /// </summary>
            FILE_NOT_FOUND,

            /// <summary>
            /// The incorrect file format
            /// </summary>
            INCORRECT_FILE_FORMAT,

            /// <summary>
            /// The incorrect delimiter
            /// </summary>
            INCORRECT_DELIMITER,

            /// <summary>
            /// The incorrect CSV header
            /// </summary>
            INCORRECT_CSV_HEADER
        }

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message 
        {
            get
            {
                return this.message;
            }
        }
    }
}