using SensitiveData.CTF.BrownBox.Domain;
using System.Data.SqlClient;

namespace SensitiveData.CTF.BrownBox.Infrastructure
{
    public class Tokenizer : ITokenizer
    {
        public string Tokenize(CardDomain card)
        {
            string token = Guid.NewGuid().ToString();
            string connectionString = "Data Source=localhost, 1401;Initial Catalog=TokenizerCTF;Persist Security Info=True;User ID=sa;Password=Password01;Encrypt=False"; // Replace with your connection string
            string query = "INSERT INTO PanToken (Token, Pan) VALUES (@Token, @Pan)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                // Replace these with actual values you want to insert
                command.Parameters.AddWithValue("@Token", token);
                command.Parameters.AddWithValue("@Pan", card.Pan.Value);
                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return token;
        }
    }
}
