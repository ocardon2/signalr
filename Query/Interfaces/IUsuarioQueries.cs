using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Query.Interfaces
{
    public interface IUsuarioQueries
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario?> GetById(int id);
    }
}
