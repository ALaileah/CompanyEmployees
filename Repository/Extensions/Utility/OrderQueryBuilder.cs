using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions.Utility
{
    public static class OrderQueryBuilder
    {
        public static string CreateOrderQuery<T>(string orderByQueryString)
        {
            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var trimmedParam = param.Trim();
                var parts = trimmedParam.Split(' ');
                var propertyName = parts[0]; // Extract property name

                // Find property by name ignoring case
                var objectProperty = propertyInfos.FirstOrDefault(pi =>
                    pi.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = "ascending"; // Default direction is ascending
                if (parts.Length > 1 && string.Equals(parts[1], "desc", StringComparison.OrdinalIgnoreCase))
                {
                    direction = "descending";
                }

                // Append property name with direction
                orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' '); // Trim the trailing comma and space
            return orderQuery;
        }

    }

}
