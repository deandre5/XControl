using Dapper;
using MySql.Data.MySqlClient;
using poryecto_finanzas.DTOs;
using System.Data;

namespace poryecto_finanzas.Repositories
{
    public class UserRepositorie : IUserRepositorie
    {

        private readonly MySqlConfig _config;

        public UserRepositorie(MySqlConfig config)
        {
            this._config = config;
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            UserDTO user = new UserDTO();

            try
            {
                MySqlConnection connection = _config.GetConnection();

                const string QUERY = "SELECT * FROM usuario WHERE email = @email";
                var parameters = new DynamicParameters();
                parameters.Add("@email", email, DbType.String, ParameterDirection.Input, email.Length);
                user = connection.Query<UserDTO>(QUERY, parameters).First();
            }
            catch (Exception ex)
            {
                _ = ex;
            }

            return user;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            List<UserDTO> users = new List<UserDTO>();
            try {
                MySqlConnection connection = _config.GetConnection();

                const string QUERY = "SELECT * FROM usuario";

                users = connection.Query<UserDTO>(QUERY).ToList();

            } catch (Exception e)
            {
                _ = e;
            }
            return users;

        }
    }
}
