using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ES1.Helpers
{
    public static class DBHelper
    {
        static DBHelper()
        {

        }

        public static List<Dictionary<int, string>> ExcludeByParameter(int parameter, string value, List<Dictionary<int, string>> parametersValues)
        {
            return parametersValues.Where(x => x[parameter] == value).ToList();
        }

        public static List<string> GetParameterValues(int parameter, List<Dictionary<int, string>> parametersValues)
        {
            return parametersValues.Select(x => x[parameter]).Distinct().ToList();
        }

        static public List<Dictionary<int, string>> ParametersValues { get; set; } = new List<Dictionary<int, string>>()
        {
            new Dictionary<int, string>() { { 1, "abc"}, { 2, "cde" }, { 3, "cde" } },
            new Dictionary<int, string>() { { 1, "abd"}, { 2, "cet" }, { 3, "c" } },
            new Dictionary<int, string>() { { 1, "abc"}, { 2, "cre" }, { 3, "ce" } },
            new Dictionary<int, string>() { { 1, "abd"}, { 2, "cet" }, { 3, "cd\\e" } },
        };
    }
}