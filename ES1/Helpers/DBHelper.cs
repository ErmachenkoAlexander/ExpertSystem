using ES1.Models;
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
            try
            {
                using (var db = new CitiesDB("con1"))
                {
                    foreach (var dt in db.CitiesData)
                    {
                        var record = new Dictionary<int, string>()
                    {
                        { 1 , "" + dt.Nhemisphere },
                        { 2 , "" + dt.Whemisphere },
                        { 3 , dt.Continent },
                        { 4 , dt.PosContWEC },
                        { 5 , dt.PosContSNC },
                        { 6 , dt.Country },
                        { 7 , "" + dt.PosBySea },
                        { 8 , dt.PosCountryWEC },
                        { 9 , dt.PosCountrySNC },
                        { 10 , dt.Population },
                        { 11 , dt.Name }
                    };

                        ParametersValues.Add(record);
                    }
                }
            }
            catch(Exception e)
            {

            }
        }

        public static List<Dictionary<int, string>> ExcludeByParameter(int parameter, string value, List<Dictionary<int, string>> parametersValues)
        {
            return parametersValues.Where(x => x[parameter] == value).ToList();
        }

        public static List<string> GetParameterValues(int parameter, List<Dictionary<int, string>> parametersValues)
        {
            return parametersValues.Select(x => x[parameter]).Distinct().ToList();
        }

        static public List<Dictionary<int, string>> ParametersValues { get; set; } = new List<Dictionary<int, string>>();
    }
}