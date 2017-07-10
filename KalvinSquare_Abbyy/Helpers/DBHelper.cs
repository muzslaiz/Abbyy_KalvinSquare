using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace KalvinSquare_Abbyy.Helpers
{
    class DBHelper
    {
        public static string TryGetFieldValue(SqlDataReader rdr, string fieldName)
        {
            string back = "";
            try
            {
                if (rdr.HasRows)
                {
                    int ordinalNumber = rdr.GetOrdinal(fieldName);
                    var value = rdr.GetValue(ordinalNumber);
                    if (value is string)
                        back = rdr.GetString(ordinalNumber);
                    else
                    {
                        back = value.ToString();
                    }
                }
            }
            catch (Exception)
            {
            }
            return back;
        }
    }
}
