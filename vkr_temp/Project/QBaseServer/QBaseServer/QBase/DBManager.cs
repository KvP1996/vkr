using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using QBaseServer.Determinant;
using System.IO;
using Npgsql;
using System.Windows.Forms;

namespace QBaseServer.QBase
{
    /// <summary>
    /// Manages the database.
    /// </summary>
    public class DBManager
    {
        // Correct ' in SQL.Data 
        //Строка подключения к бд

        private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "QbaseKvp";
        private static string Password = "123";
        private static string Port = "5432";

        // const string localString = @"Server=localhost;Username=postgres;Database=QbaseKvp;Port=5432;Password=123;SSLMode=Prefer";
        //const string localString = @"user id=SA;server=HOME-PS2015\KVP;Trusted_Connection=yes;database=QbaseKvp; connection timeout=30";
        // const string localString = @"Data Source=DESKTOP-TDL137K\KVP;Initial Catalog=QbaseKvp;Persist Security Info=True;User ID=sa;Password=123";
        static NpgsqlConnection connection;
        const string localString = @"Server=localhost;Username=postgres;Database=QbaseKvp;Port=5432;Password=123;SSLMode=Prefer";
        static DBManager()
        {
            connection = new NpgsqlConnection(localString);

        }
        /// <summary>
        /// Get all algorithms int the database.
        /// </summary>
        /// <returns>Algorithms list</returns>

        static public List<Algorithm> GetAllAlgorithms()
        {
            //SqlDataReader reader;
            //try
            //{
            //    SqlCommand com = new SqlCommand("select * from Algorithms;", connection);
            //    reader = com.ExecuteReader();
            //}
            //catch
            //{
            //    connection.Close();
            //    return algorithmsListError("Error", "Unsuccessful SQL-request.");
            //}

            //Npgsql
            try
            {
                connection.Open();
            }
            catch
            {
                return algorithmsListError("Error", "Cannot connect to the database");
            }
            NpgsqlDataReader reader;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("select *  From public.\"Algorithms\"", connection);
                reader = cmd.ExecuteReader();
            }
            catch
            {
                connection.Close();
                return algorithmsListError("Error", "Unsuccessful SQL-request.");
            }
            List<Algorithm> res = new List<Algorithm>();
            try
            {
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string name = (string)reader["name"];
                    string description = (string)reader["description"];
                    res.Add(new Algorithm(id, name, description));
                }
            }
            catch
            {
                connection.Close();
                return algorithmsListError("Error", "Cannot parse SQL-response.");
            }
            connection.Close();
            return res;
        }

        /// <summary>
        /// Add algorithm to datatbase.
        /// </summary>
        /// <param name="alg">Algorithm</param>
        /// <returns>Posted algorithm's ID</returns>
        static public string AddAlgorithm(IDLessAlgorithm alg)
        {
            NpgsqlDataReader reader;
            try
            {
                connection.Open();
            }
            catch
            {
                return "Error. Cannot connect to database.";
            }

            try
            {
                NpgsqlCommand com = new NpgsqlCommand(string.Format("INSERT INTO Algorithms(name, description) values ('{0}', '{1}');", alg.Name, alg.Description), connection);
                com.ExecuteNonQuery();
                com = new NpgsqlCommand("select MAX(id) from Algorithms;", connection);
                reader = com.ExecuteReader();
            }
            catch
            {
                connection.Close();
                return "Error. Unsuccessful SQL-request.";
            }

            int res = -1;
            if (reader.Read())
                res = (Int32)reader[0];
            connection.Close();
            if (res == -1)
                return "Error. Cannot read ID.";
            return res.ToString();
        }

        /// <summary>
        /// Delete algorithm.
        /// </summary>
        /// <param name="id">Algorithm's id</param>
        /// <returns>Deletion result</returns>
        static public string DeleteAlgorithm(int id)
        {

            int[] ids = GetAlgorithmDeterminants(id);
            if ((ids.Length == 1) && (ids[0] == -1))
                return "Error. Cannot get algorithm's determinants";
            for (int i = 0; i < ids.Length; i++)
            {
                string detres = DeleteDeterminant(ids[i]);
                if (detres != "OK")
                    return "Error. Cannot delete algorithm\'s determinants. Reason: " + detres;
            }

            try
            {
                connection.Open();
            }
            catch
            {
                return "Error. Cannot connect to database.";
            }

            bool res;
            try
            {
                var com = new NpgsqlCommand(string.Format("delete from Algorithms where id={0};", id), connection);
                res = com.ExecuteNonQuery() > 0;
            }
            catch
            {
                connection.Close();
                return "Error. Unsuccessful SQL-request.";
            }

            connection.Close();
            if (!res)
                return "Error. Unsuccessful deletion.";
            return "OK";
        }

        /// <summary>
        /// Update algorithm's info.
        /// </summary>
        /// <param name="id">Algorithm's ID</param>
        /// <param name="alg">Algorithm's info</param>
        /// <returns>Updating result</returns>
        static public string UpdateAlgorithm(int id, IDLessAlgorithm alg)
        {
            try
            {
                connection.Open();
            }
            catch
            {
                return "Error. Cannot connect to database.";
            }

            bool res;
            try
            {
                NpgsqlCommand com = new NpgsqlCommand(string.Format("update Algorithms set description='{0}', name='{1}' where id={2};", alg.Description, alg.Name, id), connection);
                res = com.ExecuteNonQuery() > 0;
            }
            catch
            {
                connection.Close();
                return "Error. Unsuccessful SQL-request.";
            }

            connection.Close();
            if (!res)
                return "Error. Unsuccessful updating.";
            return "OK";
        }


        /// <summary>
        /// Add Q-determinant for algorithm.
        /// </summary>
        /// <param name="algorithmId">Algorithm's ID</param>
        /// <param name="determinant">Q-determinant in JSON</param>
        /// <returns>Q-determinant's ID</returns>
        static public string AddDeterminant(int algorithmId, string determinant)
        {
            string readPath = @"C:\vkr_temp\json.json";
            StreamReader reader = new StreamReader(readPath);
            string json = reader.ReadToEnd();
            reader.Close();
            //ВАР1
            //  string str = json;

            //ВАР2 НОРМ
            // string str = determinant;
            var dimensions = new int[0];
            Expression expression = null;
            var ser = new JavaScriptSerializer{MaxJsonLength =Int32.MaxValue,RecursionLimit = Int32.MaxValue };
            try
            {
                //string ReadPath = @"D:\json1.json";
                //StreamReader reader = new StreamReader(ReadPath);
                //string json = reader.ReadToEnd();
                //var obj = ser.DeserializeObject(str) as Dictionary<string, object>;
                var obj = ser.DeserializeObject(json) as Dictionary<string, object>;
                var objArray = obj["Dimensions"] as object[];
                dimensions = new int[objArray.Length];
                for (var i = 0; i < objArray.Length; i++)
                    dimensions[i] = int.Parse(objArray[i].ToString());
                expression = Expression.FromJSON(ser.Serialize(obj["Determinant"]));

            }
            catch
            {
                //return str;
                return "Deserialize problems. Check input data format.";

            }
            string connectionStringz = String.Format(
              "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
              Host,
              User,
              DBname,
              Port,
              Password);

            // string connectionStringz = @"Data Source=HOME-PS2015\KVP;Initial Catalog=QbaseKvp;Persist Security Info=True;User ID=sa";
            //string connectionStringz = @"Data Source=DESKTOP-TDL137K\KVP;Initial Catalog=QbaseKvp;Persist Security Info=True;User ID=sa;Password=123";
            //         using (SqlConnection connectionz = new SqlConnection(connectionStringz))
            //             {
            //                   connectionz.Open();
            //                  SqlCommand maxid2 = new SqlCommand(@"select max([id]) from [dbo].[Complexity_characteristic]", connectionz);
            //                 int rows_dt3 = Convert.ToInt32(maxid2.ExecuteScalar());
            //                 SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Complexity_characteristic]
            //SET [ticks] = '" + expression.GetTicks() + "',[processors] = '" + expression.GetProcessors() + "' WHERE [id] = '" + rows_dt3 + "'", connectionz);
            //                 cmd.ExecuteNonQuery();

            //         }
            using (NpgsqlConnection connectionz = new NpgsqlConnection(connectionStringz))
            {
                connectionz.Open();
                NpgsqlCommand maxid2 = new NpgsqlCommand("select max(id) from public.\"Complexity_characteristic\"", connectionz);
                int rows_dt3 = Convert.ToInt32(maxid2.ExecuteScalar());
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"Complexity_characteristic\" SET ticks = '" + expression.GetTicks() + "',processors = '" + expression.GetProcessors() + "' WHERE id = '" + rows_dt3 + "'", connectionz);
                cmd.ExecuteNonQuery();
                connectionz.Close();
            }

            return "Данные  добавлены и сохранены успешно..";

        }

        /// <summary>
        /// Get all Q-determinants' IDs for algorithm.
        /// </summary>
        /// <param name="id">Algorithm's ID</param>
        /// <returns>Q-determinants' IDs array</returns>
        static public int[] GetAlgorithmDeterminants(int id)
        {
            //try
            //{
            //    connection.Open();
            //}
            //catch
            //{
            //    return new int[1] { -1 };
            //}

            //SqlDataReader reader;
            //try
            //{
            //    //SqlCommand com = new SqlCommand(string.Format("select Determinants.id from Determinants, Algorithms where algorithm={0} group by Determinants.id", id), connection);
            //    SqlCommand com = new SqlCommand(string.Format("select Complexity_characteristic.id from Complexity_characteristic, Algorithms where ID_Algorithm={0} group by Complexity_characteristic.id", id), connection);
            //    reader = com.ExecuteReader();
            //}
            //catch
            //{
            //    connection.Close();
            //    return new int[1] { -1 };
            //}
            NpgsqlDataReader reader;
            try
            {
                connection.Open();
            }
            catch
            {
                return new int[1] { -1 };
            }
            try
            {
                NpgsqlCommand com = new NpgsqlCommand(string.Format(@"select ""Complexity_characteristic"".""id"" from public.""Complexity_characteristic"" where ""ID_Algorithm""={0} group by ""Complexity_characteristic"".""id"" ", id), connection);
                reader = com.ExecuteReader();
            }
            catch
            {
                connection.Close();
                return new int[1] { -1 };
            }
            List<int> lst = new List<int>();
            try
            {
                while (reader.Read())
                {
                    int did = (int)reader["id"];
                    lst.Add(did);
                }
            }
            catch
            {
                connection.Close();
                return new int[1] { -1 };
            }

            connection.Close();
            return lst.ToArray();

        }

        /// <summary>
        /// Get Q-determinant.
        /// </summary>
        /// <param name="id">Q-determinant's ID</param>
        /// <returns>Q-determinant</returns>
        static public string GetDeterminant(int id)
        {
            return GetDeterminantsStringField(id, "expression");
        }

        /// <summary>
        /// Delete Q-determinant.
        /// </summary>
        /// <param name="id">Q-determinant's ID</param>
        /// <returns>Deletion result</returns>
        static public string DeleteDeterminant(int id)
        {

            try
            {
                connection.Open();
            }
            catch
            {
                return "Error. Cannot connect to database.";
            }

            bool res;
            try
            {
                var com = new NpgsqlCommand(string.Format("delete from Determinants where id={0};", id), connection);
                res = com.ExecuteNonQuery() > 0;
            }
            catch
            {
                connection.Close();
                return "Error. Unsuccessful SQL-request.";
            }

            connection.Close();
            if (!res)
                return "Error. Unsuccessful deletion.";
            return "OK";
        }

        /// <summary>
        /// Get ticks count for Q-determinant.
        /// </summary>
        /// <param name="id">Q-determinant's id.</param>
        /// <returns>Ticks count.</returns>
        static public int GetDeterminantsTicks(int id)
        {
            return GetDeterminantsIntField(id, "ticks");
        }

        /// <summary>
        /// Get processors count for Q-determinant.
        /// </summary>
        /// <param name="id">Q-determinant's id.</param>
        /// <returns>Processors count.</returns>
        static public int GetDeterminantsProcessors(int id)
        {
            return GetDeterminantsIntField(id, "processors");
        }

        /// <summary>
        /// Get dimensions for Q-determinant.
        /// </summary>
        /// <param name="id">Q-determinant.</param>
        /// <returns>Dimensions.</returns>
        static public string GetDeterminantsDimensions(int id)
        {
            return GetDeterminantsStringField(id, "dimensions");
        }

        /// <summary>
        /// Compare determinants ticks.
        /// </summary>
        /// <param name="id1">First algorithm's id.</param>
        /// <param name="id2">Second algorithm's id.</param>
        /// <returns>Comparions result.</returns>
        static public string CompareDeterminantsTicks(int id1, int id2)
        {
            int[][] ids = GetCommonDeterminants(id1, id2);
            int[][] data = GetComparisonData(ids, "ticks");
            return CompareData(data);
        }

        /// <summary>
        /// Compare determinants processors.
        /// </summary>
        /// <param name="id1">First algorithm's id.</param>
        /// <param name="id2">Second algorithm's id.</param>
        /// <returns>Comparison result.</returns>
        static public string CompareDeterminantsProcessors(int id1, int id2)
        {
            int[][] ids = GetCommonDeterminants(id1, id2);
            int[][] data = GetComparisonData(ids, "processors");
            return CompareData(data);
        }

        static int GetDeterminantsIntField(int id, string field)
        {
            //try
            //{
            //    connection.Open();
            //}
            //catch
            //{
            //    return -1;
            //}

            //SqlDataReader reader;
            //try
            //{
            //    //SqlCommand com = new SqlCommand(string.Format("select {0} from Determinants where id={1}", field, id), connection);
            //    SqlCommand com = new SqlCommand(string.Format("select {0} from Complexity_characteristic where id={1}", field, id), connection);
            //    reader = com.ExecuteReader();
            //}
            //catch
            //{
            //    connection.Close();
            //    return -2;
            //}

            try
            {
                connection.Open();
            }
            catch
            {
                return -1;
            }

            NpgsqlDataReader reader;
            try
            {
                NpgsqlCommand com = new NpgsqlCommand(string.Format("select {0} from public.\"Complexity_characteristic\" where id={1}", field, id), connection);
                reader = com.ExecuteReader();
            }
            catch
            {
                connection.Close();
                return -2;
            }

            int res = 0;
            try
            {
                while (reader.Read())
                {
                    res = (int)reader[field];
                }
            }
            catch
            {
                connection.Close();
                return -3;
            }
            connection.Close();
            return res;

        }

        static string GetDeterminantsStringField(int id, string field)
        {
            //try
            //{
            //    connection.Open();
            //}
            //catch
            //{
            //    return "Error. Cannot connect to database";
            //}

            //SqlDataReader reader;
            //try
            //{
            //   // SqlCommand com = new SqlCommand(string.Format("select {0} from Determinants where id={1}", field, id), connection);
            //    SqlCommand com = new SqlCommand(string.Format("select {0} from Complexity_characteristic where id={1}", field, id), connection);
            //    reader = com.ExecuteReader();
            //}
            //catch
            //{
            //    connection.Close();
            //    return "Error. Unsuccessful SQL-request.";
            //}

            try
            {
                connection.Open();
            }
            catch
            {
                return "Error. Cannot connect to database";
            }
            NpgsqlDataReader reader;
            try
            {
                NpgsqlCommand com = new NpgsqlCommand(string.Format("select {0} from public.\"Complexity_characteristic\" where id={1}", field, id), connection);
                reader = com.ExecuteReader();
            }
            catch
            {
                connection.Close();
                return "Error. Unsuccessful SQL-request.";
            }

            string res = "";
            try
            {
                while (reader.Read())
                {
                    res = (string)reader[field];

                }
            }
            catch
            {
                connection.Close();
                return "Error. Cannot parse SQL-request.";
            }

            connection.Close();

            return res;

        }

        static int[][] GetCommonDeterminants(int id1, int id2)
        {
            var res1 = new List<int>();
            var res2 = new List<int>();

            int[] ids1 = GetAlgorithmDeterminants(id1);
            int[] ids2 = GetAlgorithmDeterminants(id2);
            var dims1 = new Dictionary<string, int>();
            for (var i = 0; i < ids1.Length; i++)
            {
                string resp = GetDeterminantsDimensions(ids1[i]);
                if (dims1.ContainsKey(resp))
                    continue;
                dims1.Add(resp, ids1[i]);
            }
            var dims2 = new Dictionary<string, int>();
            for (var i = 0; i < ids2.Length; i++)
            {
                string resp = GetDeterminantsDimensions(ids2[i]);
                if (dims2.ContainsKey(resp))
                    continue;
                dims2.Add(resp, ids2[i]);
            }
            foreach (var x in dims1)
            {
                if (dims2.ContainsKey(x.Key))
                {
                    res1.Add(x.Value);
                    res2.Add(dims2[x.Key]);
                }
            }

            var res = new int[2][];
            res[0] = res1.ToArray();
            res[1] = res2.ToArray();
            return res.ToArray();
        }

        static int[][] GetComparisonData(int[][] ids, string field)
        {
            var res = new int[ids.Length][];

            for (var i = 0; i < res.Length; i++)
            {
                res[i] = new int[ids[i].Length];
                for (var j = 0; j < res[i].Length; j++)
                {
                    if (field == "ticks")
                        res[i][j] = GetDeterminantsTicks(ids[i][j]);
                    if (field == "processors")
                        res[i][j] = GetDeterminantsProcessors(ids[i][j]);
                }
            }

            return res;
        }

        static string CompareData(int[][] data)
        {

            if (data.Length < 2)
                return "Data array error: array length.";
            if (data[0].Length != data[1].Length)
                return "Data array error: subarrays lengths mismatch.";

            int res = 0;
            for (var i = 0; i < data[0].Length; i++)
            {
                res += data[0][i] - data[1][i];
            }

            return res.ToString();
        }

        static List<Algorithm> algorithmsListError(string title, string description)
        {
            var error = new List<Algorithm>();
            error.Add(new Algorithm(-1, title, description));
            return error;
        }
    }
}


