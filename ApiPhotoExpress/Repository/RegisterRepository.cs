
using ApiPhotoExpress.Model.Entity;
using Dapper;
using MySqlConnector;

namespace ApiPhotoExpress.Repository
{
    public class RegisterRepository
    {

        private readonly MySQLConfiguration _connectionString;

        public RegisterRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection OpenConnection()
        {
            var connection = new MySqlConnection(_connectionString.ConnectionString);
            connection.Open();
            return connection;
        }

        public async Task<bool> InsertRegister(Register register)
        {
            using (var db = OpenConnection())
            {
                var sql = @"
                    INSERT INTO events (InstitucionSuperior, DireccionInstitucion, NumeroAlumnos, HoraInicio, ValorServicio) 
                    VALUES (@InstitucionSuperior, @DireccionInstitucion, @NumeroAlumnos, @HoraInicio, @ValorServicio)";


                var result = await db.ExecuteAsync(sql, new
                { register.InstitucionSuperior, register.DireccionInstitucion, register.NumeroAlumnos, register.HoraInicio, register.ValorServicio});



                return result > 0;
            }
        }

        public async Task<List<Register>> GetRegisters()
        {
            using (var db = OpenConnection())
            {
                var sql = "SELECT * FROM events";
                var registers = await db.QueryAsync<Register>(sql);
                return registers.AsList();
            }
        }
    }
}


