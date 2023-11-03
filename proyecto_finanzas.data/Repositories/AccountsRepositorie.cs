using Dapper;
using MySql.Data.MySqlClient;
using poryecto_finanzas;
using proyecto_finanzas.data.DTOs;
using System.Data;

namespace proyecto_finanzas.data.Repositories
{
    public class AccountsRepositorie : IAccountsRepositorie
    {

        private readonly MySqlConfig _config;

        public AccountsRepositorie(MySqlConfig config)
        {
            this._config = config;
        }


        public async Task<string> createAccount(AccountsDTO cuenta)
        {

            string response;

            try
            {
                MySqlConnection connection = _config.GetConnection();

                const string QUERY = "INSERT INTO cuentas(Nombre, Saldo, MonedaId, IdUser) " +
                    "VALUES (@nombre, @saldo, @monedaid, @iduser)";
                var parameters = new DynamicParameters();
                parameters.Add("@nombre", cuenta.Nombre, DbType.String, ParameterDirection.Input, cuenta.Nombre.Length);
                parameters.Add("@saldo", cuenta.Saldo, DbType.Int64, ParameterDirection.Input, cuenta.Saldo.ToString().Length);
                parameters.Add("@monedaid", cuenta.MonedaId, DbType.Int32, ParameterDirection.Input, cuenta.MonedaId.ToString().Length);
                parameters.Add("@iduser", cuenta.IdUser, DbType.Int32, ParameterDirection.Input, cuenta.IdUser.ToString().Length);

                var t = await connection.ExecuteAsync(QUERY, parameters);


                response = "1";

            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }

        public async Task<string> deleteAccount(int idAccount, int idUser)
        {
            string response;

            try
            {
                MySqlConnection connection = _config.GetConnection();

                const string QUERY = "DELETE FROM cuentas " +
                    "WHERE Id = id AND IdUser = idUser";
                var parameters = new DynamicParameters();
                parameters.Add("@id", idAccount, DbType.Int32, ParameterDirection.Input, idAccount.ToString().Length);
                parameters.Add("@idUser", idUser, DbType.Int32, ParameterDirection.Input, idUser.ToString().Length);

                var t = await connection.ExecuteAsync(QUERY, parameters);

                response = "1";

            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }

        public async Task<List<AccountsResponseDTO>> getAccounts(string idUser)
        {
            List<AccountsResponseDTO> accounts = new List<AccountsResponseDTO>();
            try
            {
                MySqlConnection connection = _config.GetConnection();

                const string QUERY = "SELECT c.Nombre, c.Saldo, m.Nombre as Moneda, c.Id FROM cuentas c " +
                    "JOIN monedas m ON m.Id = c.MonedaId " +
                    "WHERE IdUser = @idUser";

                var parameters = new DynamicParameters();
                parameters.Add("@idUser", idUser, DbType.Int32, ParameterDirection.Input, idUser.ToString().Length);

                accounts = connection.Query<AccountsResponseDTO>(QUERY,parameters).ToList();

            }
            catch (Exception e)
            {
                _ = e;
            }
            return accounts;
        }

        public async Task<string> updateAccount(AccountsDTO account)
        {
            string response;

            try
            {
                MySqlConnection connection = _config.GetConnection();

                const string QUERY = "UPDATE cuentas " +
                    "SET Nombre=@nombre, Saldo=@saldo, MonedaId=@monedaid " +
                    "WHERE Id=@id AND IdUser=iduser";

                var parameters = new DynamicParameters();
                parameters.Add("@nombre", account.Nombre, DbType.String, ParameterDirection.Input, account.Nombre.Length);
                parameters.Add("@saldo", account.Saldo, DbType.Int64, ParameterDirection.Input, account.Saldo.ToString().Length);
                parameters.Add("@monedaid", account.MonedaId, DbType.Int32, ParameterDirection.Input, account.MonedaId.ToString().Length);
                parameters.Add("@iduser", account.IdUser, DbType.Int32, ParameterDirection.Input, account.IdUser.ToString().Length);
                parameters.Add("@id", account.Id, DbType.Int32, ParameterDirection.Input, account.Id.ToString().Length);

                var t = await connection.ExecuteAsync(QUERY, parameters);

                response = "1";

            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }

    }
}
