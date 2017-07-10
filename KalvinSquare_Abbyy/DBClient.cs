using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using KalvinSquare_Abbyy.Helpers;
using KalvinSquare_Abbyy.CurrencyFactor;
using System.Data;

namespace KalvinSquare_Abbyy.VATProdPostingGroup
{
    internal static class DBClientVATProdPostingGroups
    {
        public static List<VATProdPostingGroup_Item> GetVatProdPostingGroup_Items() {
            List<VATProdPostingGroup_Item> returnItems = new List<VATProdPostingGroup_Item>();
            using (SqlConnection conn = new SqlConnection(STATIC.CONNSTR_PSDEV2))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("es1.spGetVATProdPostingGroups", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        VATProdPostingGroup_Item vppgi = new VATProdPostingGroup_Item();
                        vppgi.timestamp = DBHelper.TryGetFieldValue(rdr, "timestamp");
                        vppgi.Code = DBHelper.TryGetFieldValue(rdr, "Code");
                        vppgi.Description = DBHelper.TryGetFieldValue(rdr, "Description");
                        vppgi.Prod_Code_Part_TVA = DBHelper.TryGetFieldValue(rdr, "Prod_ Code(Part TVA)");
                        vppgi.Prod_Code_Part_non_TVA = DBHelper.TryGetFieldValue(rdr, "Prod_ Code(Part non TVA)");

                        returnItems.Add(vppgi);
                    }
                }
            }


            return returnItems;
        }
    }

    internal static class DBClientCurrencyFactor
    {
        public static List<CurrencyFactorItem> GetCurrencyFactors(string currencyCode)
        {
            List<CurrencyFactorItem> returnItems = new List<CurrencyFactorItem>();
            using (SqlConnection conn = new SqlConnection(STATIC.CONNSTR_PSDEV2))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("es1.spGetCurrencyFactors", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CurrencyCode", SqlDbType.VarChar).Value = currencyCode;

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        CurrencyFactorItem item = new CurrencyFactorItem();
                        item.CurrencyCode = DBHelper.TryGetFieldValue(rdr, "Currency Code");
                        item.StartingDate = DateTime.Parse(DBHelper.TryGetFieldValue(rdr, "Starting Date"));
                        item.ExchangeRate = double.Parse(DBHelper.TryGetFieldValue(rdr, "Relational Exch_ Rate Amount"));

                        returnItems.Add(item);
                    }
                }
            }


            return returnItems;
        }
    }
}
