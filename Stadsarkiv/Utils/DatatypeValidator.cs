using System;
using System.Collections.Generic;
using System.Text;

namespace Stadsarkiv.Utils
{
    public static class DatatypeValidator
    {
        public static bool Validate(string data, string type)
        {
            if (type.ToUpper().Contains("CHARACTER"))
            {
                //If we were validating varchar lengths the logic would go here
                return true;
            }
                
            switch (type.ToUpper())
            {
                case "INTEGER":
                    return int.TryParse(data, out _);
                case "DECIMAL":
                    return decimal.TryParse(data, out _);
                case "DATE":
                    return DateTime.TryParse(data, out _);
                default:
                    throw new ArgumentOutOfRangeException($"Unknown data type {type}");
            }
        }
    }
}
