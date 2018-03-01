﻿using System;
using System.Web.Script.Serialization;

/// <summary>
/// BORROWED FROM :
/// https://www.codeproject.com/Articles/1028416/RESTful-Day-sharp-Request-logging-and-Exception-ha
/// </summary>
namespace TCMManagement.Helpers
{
    public static class JSONHelper
    {
        #region Public extension methods.
        /// <summary>
        /// Extened method of object class
        /// Converts an object to a json string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJSON(this object obj)
        {
            var serializer = new JavaScriptSerializer();

            try
            {
                return serializer.Serialize(obj);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
}