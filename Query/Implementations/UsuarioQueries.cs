using Dapper;
using Models;
using Query.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Query.Implementations
{
    public class UsuarioQueries : IUsuarioQueries
    {
        private readonly IDbConnection _db;

        public UsuarioQueries(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            try
            {
                string sql = "SELECT * FROM Usuario";
                return await _db.QueryAsync<Usuario>(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Usuario?> GetById(int id)
        {
            try
            {
                string sql = "SELECT * FROM Usuario WHERE Id=@id";
                return await _db.QueryFirstOrDefaultAsync<Usuario>(sql, new { id });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
