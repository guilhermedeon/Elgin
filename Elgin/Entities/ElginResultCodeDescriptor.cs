using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgin.Entities
{
    public static class ElginResultCodeDescriptor
    {
        public static string GetEnumFromInt(int value)
        {
            // Get all enum types from your assemblies (could be adjusted based on where the enums are defined)
            var enumTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(t => t.IsEnum && t.Namespace == "Elgin.Entities.Enums.ResultCodes");

            foreach (var enumType in enumTypes)
            {
                // Check if the integer value exists in the current enum
                if (Enum.IsDefined(enumType, value))
                {
                    // Get the name of the enum value
                    var enumName = Enum.GetName(enumType, value);
                    return $"{enumType.Name}: {enumName}";
                }
            }

            return "Enum value not found.";
        }
    }
}
