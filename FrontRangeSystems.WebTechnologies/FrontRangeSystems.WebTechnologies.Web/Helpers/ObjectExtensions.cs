﻿using System.Collections.Generic;
using System.Linq;

namespace FrontRangeSystems.WebTechnologies.Web.Helpers
{
    public static class ObjectExtensions
    {
        public static TResult Copy<TSource, TResult>(this TSource input) where TResult : new()
        {
            return input.Copy(new TResult());
        }

        public static TResult Copy<TSource, TResult>(this TSource input, TResult output) where TResult : new()
        {
            if (input == null)
            {
                return default(TResult);
            }

            if (output == null)
            {
                output = new TResult();
            }

            var sourceProperties = input.GetType().GetProperties().Where(p => p.CanRead);
            var destinationProperties = output.GetType().GetProperties()
                .Where(p => sourceProperties.Select(s => s.Name).Contains(p.Name) && p.CanWrite);

            foreach (var dest in destinationProperties)
            {
                var source = sourceProperties.FirstOrDefault(p => p.Name == dest.Name && p.PropertyType == dest.PropertyType);
                if (source != null)
                {
                    dest.SetValue(output, source.GetValue(input));
                }
            }

            return output;
        }

        public static T GetOrdinalItem<T>(this IList<T> input, int ordinal)
        {
            if (input == null || !input.Any())
            {
                return default(T);
            }

            return input[ordinal % input.Count];
        }
    }

}