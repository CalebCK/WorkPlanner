using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConvertor.Extensions
{
    public static class GlobalFunctions
    {
        public static string GetModelStateErrors(ModelStateDictionary modelState)
        {
            string error = "";

            foreach (var item in modelState.Values)
            {
                foreach (var err in item.Errors)
                {
                    error = error + $"{err.ErrorMessage};" + Environment.NewLine;
                }
            }

            return error;
        }

        /// <summary>
        /// IEnumerable extension method that returns the index of the current item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self) => self?.Select((item, index) => (item, index)) ?? new List<(T, int)>();
    }
}
