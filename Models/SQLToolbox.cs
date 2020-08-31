using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTema_WPF_Offline_App.Models
{
    public static class SQLToolbox
    {
        const string connectionString = @"Data Source=10.0.4.114;Initial Catalog=GeoTema;Persist Security Info=True;User ID=Logon;Password=Passw0rd1";

        #region Login
        public static UserModel Login(string Username, string Password)
        {
            UserModel CurrentUser = new UserModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.UserTable WHERE Username = @Username AND Password = @Password", connection))
                {
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CurrentUser.Username = reader.GetString(1);
                        CurrentUser.Type = reader.GetByte(3);
                    }
                }
            }
            return CurrentUser;
        }
        #endregion

        #region GeoData CRUD
        /*GeoData Functions
         * This is all the functions needed for the app regarding GeoData
         * FULL CRUD
         */
        #region CreateGeoData
        /*CreateGeoData
         * Takes in GeoDataModel object to add
         * Returns 1 if successful
         * Returns 0 if not
         */
        public static int CreateGeoData(GeoDataModel NewGeoData)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.GeoTable VALUES (@PostalCode, @City, @Population, @Temperature)", connection))
                {
                    cmd.Parameters.AddWithValue("@PostalCode",NewGeoData.PostalCode);
                    cmd.Parameters.AddWithValue("@City",NewGeoData.City);
                    cmd.Parameters.AddWithValue("@Population",NewGeoData.Population);
                    cmd.Parameters.AddWithValue("@Temperature",NewGeoData.Temperature);
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region ReadGeoData
        /*ReadGeoData
         * Takes nothing
         * Returns List of all GeoData in DB
         */
        public static List<GeoDataModel> ReadGeoData()
        {
            List<GeoDataModel> GeoDataList = new List<GeoDataModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.GeoTable", connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        GeoDataModel data = new GeoDataModel
                        {
                            ID = reader.GetInt32(0),
                            PostalCode = reader.GetInt32(1),
                            City = reader.GetString(2),
                            Population = reader.GetInt32(3),
                            Temperature = reader.GetDouble(4)
                        };
                        GeoDataList.Add(data);
                    }
                }
            }
            return GeoDataList;
        }
        #endregion

        #region UpdateGeoData
        /*UpdateGeoData
         * Takes in GeoDataModel object to update
         * Returns 1 if successful
         * Returns 0 if not
         */
        public static int UpdateGeoData(GeoDataModel UpdatedGeoData)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE dbo.GeoTable SET PostalCode = @PostalCode, City = @City, Population = @Population, Temperature = @Temperature WHERE ID = @ID", connection))
                {
                    cmd.Parameters.AddWithValue("@PostalCode", UpdatedGeoData.PostalCode);
                    cmd.Parameters.AddWithValue("@City", UpdatedGeoData.City);
                    cmd.Parameters.AddWithValue("@Population", UpdatedGeoData.Population);
                    cmd.Parameters.AddWithValue("@Temperature", UpdatedGeoData.Temperature);
                    cmd.Parameters.AddWithValue("@ID", UpdatedGeoData.ID);
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region DeleteGeoData
        /*DeleteGeoData
         * Takes in GeoDataModel object to remove
         * Returns 1 if successful
         * Returns 0 if not
         */
        public static int DeleteGeoData(GeoDataModel RemovedGeoData)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.GeoTable WHERE ID = @ID", connection))
                {
                    cmd.Parameters.AddWithValue("@ID", RemovedGeoData.ID);
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region ReturnGeoDataWithID
        /*ReturnIDGeo
         * Takes GeoDataModel object to add id to
         * returns GeoDataModel object
         * used to fix issue with running code having no id for current GeoDataModel item
         */
        public static GeoDataModel ReturnIDGeo(GeoDataModel geoData)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ID FROM dbo.GeoTable WHERE PostalCode=@PostalCode AND City=@City", connection))
                {
                    cmd.Parameters.AddWithValue("@PostalCode",geoData.PostalCode);
                    cmd.Parameters.AddWithValue("@City",geoData.City);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        geoData.ID = reader.GetInt32(0);
                    }
                }
            }
            return geoData;
        }
        #endregion
        #endregion

        #region UserData CRUD
        /*GeoData Functions
         * This is all the functions needed for the app regarding GeoData
         * FULL CRUD
         */
        #region CreateUserData
        /*CreateUser
         * Takes in UserModel object to add
         * Returns 1 if successful
         * Returns 0 if not
         */
        public static int CreateUser(UserModel NewUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.UserTable VALUES (@Username, @Password, @Type)", connection))
                {
                    cmd.Parameters.AddWithValue("@Username", NewUser.Username);
                    cmd.Parameters.AddWithValue("@Password", NewUser.Password);
                    cmd.Parameters.AddWithValue("@Type", NewUser.Type);
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region ReadUserData
        /*ReadUserData
         * Takes nothing
         * Returns List of all Users in DB
         */
        public static List<UserModel> ReadUserData()
        {
            List<UserModel> UserList = new List<UserModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.UserTable", connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UserModel user = new UserModel
                        {
                            ID = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            //Doesnt need passwords lying around in memory for all users?...
                            Password = reader.GetString(2),
                            Type = reader.GetByte(3)
                        };
                        UserList.Add(user);
                    }
                }
            }
            return UserList;
        }
        #endregion

        #region DeleteUserData
        /*DeleteUser
         * Takes in UserModel object to remove
         * Returns 1 if successful
         * Returns 0 if not
         */
        public static int DeleteUser(UserModel RemovedUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.UserTable WHERE ID = @ID", connection))
                {
                    cmd.Parameters.AddWithValue("@ID", RemovedUser.ID);
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region UpdateUserData
        /*UpdateUser
         * Takes in UserModel object to update
         * Returns 1 if successful
         * Returns 0 if not
         */
        public static int UpdateUser(UserModel UpdatedUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE dbo.UserTable SET Username = @Username, Password = @Password, Type = @Type WHERE ID = @ID", connection))
                {
                    cmd.Parameters.AddWithValue("@Username", UpdatedUser.Username);
                    cmd.Parameters.AddWithValue("@Password", UpdatedUser.Password);
                    cmd.Parameters.AddWithValue("@Type", UpdatedUser.Type);
                    cmd.Parameters.AddWithValue("@ID", UpdatedUser.ID);
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region ReturnUserWithID
        /*ReturnIDUser
         * Takes UserModel object to add id to
         * returns UserModel object
         * used to fix issue with running code having no id for current UserModel item
         */
        public static UserModel ReturnIDUser(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ID FROM dbo.UserTable WHERE Username=@Username", connection))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user.ID = reader.GetInt32(0);
                    }
                }
            }
            return user;
        }
        #endregion

        #region ResetPassword
        /*ResetPassword
        * Takes in UserModel object to reset password for
        * Returns 1 if successful
        * Returns 0 if not
        */
        public static string ResetPassword(UserModel User)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE dbo.UserTable SET Password = 'Passw0rd1' WHERE ID = @ID", connection))
                {
                    cmd.Parameters.AddWithValue("@ID", User.ID);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return "Passw0rd1";
        }
        #endregion
        #endregion
    }
}
