using Dapper;
using MySql.Data.MySqlClient;
using poryecto_finanzas;
using proyecto_finanzas.data.DTOs;
using System.Data;

namespace proyecto_finanzas.data.Repositories
{
    public class TransactionsRepositorie : ITransactionsRepositorie
    {
        private readonly MySqlConfig _config;

        public TransactionsRepositorie(MySqlConfig config)
        {
            this._config = config;
        }
        public async Task<string> createExpensesIncome(ExpensesIncome expensesIncome)
        {
            string response;

            try
            {
                MySqlConnection connection = _config.GetConnection();

                const string QUERY = "INSERT INTO gastos_ingresos(Nombre, Monto, Tipo, IdCuenta, fecha, categoriaId) " +
                    "VALUES (@nombre, @monto, @tipo, @idCuenta, @fecha, @categoriaId)";
                var parameters = new DynamicParameters();
                parameters.Add("@nombre", expensesIncome.Nombre, DbType.String, ParameterDirection.Input, expensesIncome.Nombre.Length);
                parameters.Add("@monto", expensesIncome.Monto, DbType.Int64, ParameterDirection.Input, expensesIncome.Monto.ToString().Length);
                parameters.Add("@tipo", expensesIncome.Tipo, DbType.Int32, ParameterDirection.Input, expensesIncome.Tipo.ToString().Length);
                parameters.Add("@idCuenta", expensesIncome.IdCuenta, DbType.Int32, ParameterDirection.Input, expensesIncome.IdCuenta.ToString().Length);
                parameters.Add("@fecha", expensesIncome.Fecha, DbType.DateTime, ParameterDirection.Input, expensesIncome.Fecha.ToString().Length);
                parameters.Add("@categoriaId", expensesIncome.CategoriaId, DbType.Int32, ParameterDirection.Input, expensesIncome.CategoriaId.ToString().Length);

                var t = await connection.ExecuteAsync(QUERY, parameters);

                response = "1";

            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }

        public async Task<string> deleteExpensesIncome(int idAccount, int idExpensesIncome)
        {
            string response;

            try
            {
                MySqlConnection connection = _config.GetConnection();

                const string QUERY = "DELETE FROM gastos_ingresos " +
                    "WHERE IdCuenta=@idAccount AND Id=@idExpensesIncome";
                var parameters = new DynamicParameters();
                parameters.Add("@idAccount", idAccount, DbType.Int32, ParameterDirection.Input, idAccount.ToString().Length);
                parameters.Add("@idExpensesIncome", idExpensesIncome, DbType.Int32, ParameterDirection.Input, idExpensesIncome.ToString().Length);

                var t = await connection.ExecuteAsync(QUERY, parameters);

                response = "1";

            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }

        public async Task<List<ExpensesIncomeResponse>> getExpensesIncome(string idCuenta, string fechaInicial, string fechaFinal)
        {

            List<ExpensesIncomeResponse> expenseIncome = new List<ExpensesIncomeResponse>();
            try
            {
                MySqlConnection connection = _config.GetConnection();

                const string QUERY = "SELECT g.Nombre, g.Monto, g.Id, t.Nombre as tipo, t.Id as tipoId, g.IdCuenta, g.fecha, c.Nombre as categoria, c.Id as categoriaId " +
                    "FROM gastos_ingresos g " +
                    "JOIN tipooperaciones t ON g.Tipo = t.Id " +
                    "JOIN categorias c ON c.Id = g.categoriaId " +
                    "WHERE g.IdCuenta=@idCuenta AND g.fecha BETWEEN @fechaInicial AND @fechaFinal";

                var parameters = new DynamicParameters();
                parameters.Add("@idCuenta", idCuenta, DbType.Int32, ParameterDirection.Input, idCuenta.ToString().Length);
                parameters.Add("@fechaInicial", fechaInicial, DbType.String, ParameterDirection.Input, fechaInicial.Length);
                parameters.Add("@fechaFinal", fechaFinal, DbType.String, ParameterDirection.Input, fechaFinal.Length);


                expenseIncome = connection.Query<ExpensesIncomeResponse>(QUERY, parameters).ToList();

            }
            catch (Exception e)
            {
                _ = e;
            }
            return expenseIncome;
        }

        public async Task<string> updateExpensesIncome(ExpensesIncome expensesIncome)
        {
            string response;

            try
            {
                MySqlConnection connection = _config.GetConnection();

                const string QUERY = "UPDATE gastos_ingresos " +
                    "SET Nombre=@nombre, Monto=@monto, Tipo=@tipo, fecha=@fecha, categoriaId=@categoriaId " +
                    "WHERE Id = @id AND idCuenta = @idCuenta";
                var parameters = new DynamicParameters();
                parameters.Add("@nombre", expensesIncome.Nombre, DbType.String, ParameterDirection.Input, expensesIncome.Nombre.Length);
                parameters.Add("@monto", expensesIncome.Monto, DbType.Int64, ParameterDirection.Input, expensesIncome.Monto.ToString().Length);
                parameters.Add("@tipo", expensesIncome.Tipo, DbType.Int32, ParameterDirection.Input, expensesIncome.Tipo.ToString().Length);
                parameters.Add("@idCuenta", expensesIncome.IdCuenta, DbType.Int32, ParameterDirection.Input, expensesIncome.IdCuenta.ToString().Length);
                parameters.Add("@fecha", expensesIncome.Fecha, DbType.DateTime, ParameterDirection.Input, expensesIncome.Fecha.ToString().Length);
                parameters.Add("@categoriaId", expensesIncome.CategoriaId, DbType.Int32, ParameterDirection.Input, expensesIncome.CategoriaId.ToString().Length);
                parameters.Add("@id", expensesIncome.Id, DbType.Int32, ParameterDirection.Input, expensesIncome.Id.ToString().Length);

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
