using System;
using System.Collections.Generic;
using System.Text;

namespace Stadsarkiv.Utils
{
    public static class DatatypeValidator
    {
        public static bool Validate(string data, string type)
        {
            //For brevity i am only handling common SQL types
            if (type.ToLower().Contains("char") || type.ToLower().Contains("text"))
            {
                //If we were validating varchar lengths the logic would go here
                return true;
            }
                
            switch (type.ToLower())
            {
                case "int":
                    return int.TryParse(data, out _);
                case "decimal":
                    return decimal.TryParse(data, out _);
                case "bool":
                    return bool.TryParse(data, out _);
                case "datetime":
                    return DateTime.TryParse(data, out _);
                default:
                    throw new ArgumentOutOfRangeException($"Unknown data type {type}");
            }
        }
    }
}
