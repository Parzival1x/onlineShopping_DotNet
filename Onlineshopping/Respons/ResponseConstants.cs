using System;
using System.Collections.Generic;
using System.Text;

namespace Onlineshopping.Respons
{
    public class ResponseConstants
    {
        /// <summary>
        /// The OK
        /// </summary>
        public const int Ok = 1;

        /// <summary>
        /// The Info
        /// </summary>
        public const int Info = 2;

        /// <summary>
        /// The Fail
        /// </summary>
        public const int Fail = -1;

        /// <summary>
        /// The Fail
        /// </summary>
        public const int ErrorHandler = -4;

        /// <summary>
        /// Invalid Credentials
        /// </summary>
        public const string InvalidCredentials = "Invalid Credentials";

        public const int UnauthorizedToken = -2;

        public const int IsExist = -3;
    }
}
