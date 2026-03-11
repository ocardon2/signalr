using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario?> GetById(int id);
        Task<Usuario> Add(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Task Delete(int id);
    }
}
