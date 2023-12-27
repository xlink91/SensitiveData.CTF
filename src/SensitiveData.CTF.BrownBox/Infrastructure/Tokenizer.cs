using Microsoft.Extensions.Options;
using SensitiveData.CTF.BrownBox.Domain;
using System.Data.SqlClient;

namespace SensitiveData.CTF.BrownBox.Infrastructure
{
    public class Tokenizer : ITokenizer
    {
        private ApiConfiguration _config;

        public Tokenizer(IOptions<ApiConfiguration> config)
        {
            _config = config.Value;
        }

        public string Tokenize(CardDomain card)
        {
            string token = Guid.NewGuid().ToString();
            string panTokenQuery = "INSERT INTO PanToken (Token, Pan) VALUES (@Token, @Pan)";
            string ownerQuery = "INSERT INTO OwnerInformation(Name, Token) VALUES (@Name, @Token)";
            using (SqlConnection connection = new SqlConnection(_config.ConnectionString))
            {

                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand panTokenCommand = new SqlCommand(panTokenQuery, connection, transaction);
                panTokenCommand.Parameters.AddWithValue("@Token", token);
                panTokenCommand.Parameters.AddWithValue("@Pan", card.Pan.Value);
                _ = panTokenCommand.ExecuteNonQuery();

                SqlCommand ownerCommand = new SqlCommand(ownerQuery, connection, transaction);
                ownerCommand.Parameters.AddWithValue("@Token", token);
                ownerCommand.Parameters.AddWithValue("@Name", card.CardOwner.Name);
                _ = ownerCommand.ExecuteNonQuery();
                transaction.Commit();
            }
            return token;
        }
    }
}
