using Microsoft.Extensions.Options;
using SensitiveData.CTF.BrownBox.Domain;
using System.Collections.Immutable;
using System.Data.SqlClient;

namespace SensitiveData.CTF.BrownBox.Infrastructure
{
    public class TokenRepository : ITokenRepository
    {
        private ApiConfiguration _config;

        public TokenRepository(IOptions<ApiConfiguration> config)
        {
            _config = config.Value;
        }
        public IReadOnlyCollection<TokenizedCardDomain> Get(TokenDomain token)
        {
            string panTokenQuery = $"SELECT Name, Token FROM OwnerInformation WHERE Token = '{token.Value}'";
            using (SqlConnection connection = new SqlConnection(_config.ConnectionString))
            {
                connection.Open();
                SqlCommand panTokenCommand = new SqlCommand(panTokenQuery, connection);
                using (SqlDataReader reader = panTokenCommand.ExecuteReader())
                {
                    if(!reader.HasRows)
                    {
                        return Enumerable.Empty<TokenizedCardDomain>().ToImmutableList();
                    }
                    List<TokenizedCardDomain> tokenizedCard = new List<TokenizedCardDomain>();
                    while (reader.Read())
                    {
                        tokenizedCard.Add(TokenizedCardDomain.Create(reader.GetString(1), reader.GetString(0)));
                    }
                    return tokenizedCard.ToImmutableList();
                }
            }
        }
    }
}
