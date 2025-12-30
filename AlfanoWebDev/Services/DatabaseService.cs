using Microsoft.Data.SqlClient;
using AlfanoWebDev.Models;

namespace AlfanoWebDev.Services
{
    public class DatabaseService
    {
        private string _connectionString = "Server=.;Database=AlfanoDevHub;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<MediaAsset> GetAllMedia()
        {
            var list = new List<MediaAsset>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM MediaLibrary";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MediaAsset
                        {
                            Id = (int)reader["ID"],
                            Title = reader["Title"].ToString(),
                            MediaType = reader["MediaType"].ToString(),
                            MediaUrl = reader["MediaUrl"].ToString(),
                            Description = reader["Description"].ToString()
                        });
                    }
                }
            }
            return list;
        }


        // Updated to save Social Media info
        public void InsertMessage(ContactMessage msg)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // 1. The SQL Command now includes the extra columns
                string sql = "INSERT INTO ContactMessages (SenderName, SenderEmail, MessageBody, InstagramHandle, LinkedInUrl, TwitterHandle) VALUES (@Name, @Email, @Body, @Insta, @Linked, @Twit)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", msg.SenderName);
                cmd.Parameters.AddWithValue("@Email", msg.SenderEmail);
                cmd.Parameters.AddWithValue("@Body", msg.MessageBody);

                // 2. We use 'DBNull.Value' so it doesn't crash if they leave these blank
                cmd.Parameters.AddWithValue("@Insta", (object)msg.InstagramHandle ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Linked", (object)msg.LinkedInUrl ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Twit", (object)msg.TwitterHandle ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}