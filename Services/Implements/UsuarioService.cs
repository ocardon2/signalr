using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements
{
    public class UsuarioService : IUsuarioService
    {
        public async Task<Usuario> Add(Usuario usuario)
        {
            return usuario;
        }

        public Task Delete(int id)
        {
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            List<Usuario> usr = new List<Usuario>()
            {
                new Usuario()
                {
                    Id = 1,
                    Activo = true,
                    Nombre ="El Pepe"
                }
            };
            return usr;
        }

        public async Task<Usuario?> GetById(int id)
        {
            return null;
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            return usuario;
        }
    }
}
