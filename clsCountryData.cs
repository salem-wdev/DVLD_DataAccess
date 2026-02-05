using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsCountryData
    {

        public static string GetCountryName(int CountryID)
        {
            string CountryName = "";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT CountryName FROM Countries WHERE CountryID = @CountryID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);
            try
            {
                connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                {
                    CountryName = result.ToString();
                }
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return CountryName;
        }

        public static DataTable GetAllCountries()
        {
            DataTable Table = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Countries";

            SqlCommand Command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                Table.Load(reader);
                reader.Close();
            }
            catch { }
            finally
            {
                connection.Close();
            }

            return Table;

        }


    }
}
