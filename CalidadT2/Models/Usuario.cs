using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombres { get; set; }

        public void setNombreUsuario()
        {
            throw new NotImplementedException();
        }

        public void GetUsuario(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
