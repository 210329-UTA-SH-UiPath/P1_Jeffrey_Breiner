/* 
 * PizzaBox.Api
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// Defines CRUSTS
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
        public enum CRUSTS
    {
        /// <summary>
        /// Enum NUMBER_0 for value: 0
        /// </summary>
        [EnumMember(Value = "0")]
        DEEPDISH,
        /// <summary>
        /// Enum NUMBER_1 for value: 1
        /// </summary>
        [EnumMember(Value = "1")]
        STANDARD,
        /// <summary>
        /// Enum NUMBER_2 for value: 2
        /// </summary>
        [EnumMember(Value = "2")]
        STUFFED,
        /// <summary>
        /// Enum NUMBER_3 for value: 3
        /// </summary>
        [EnumMember(Value = "3")]
        THIN
    }
}