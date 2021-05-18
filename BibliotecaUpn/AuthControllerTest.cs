using CalidadT2.Controllers;
using CalidadT2.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUpn
{
    [TestFixture]
    public class AuthControllerTest:Usuario
    {
        [Test]
        public void DebePoderIngresarUsuario()
    {
        string Username = "admin";
        string Password = "admin";

        Usuario usuario = new Usuario()
        {
            Id = 1,
            Nombres = "Oscar",
            Password = "admin",
            Username = "admin"
        };

        var login = new Mock<UsuarioSession>();
        var login2 = new Mock<Usuario>();

        login2.Setup(p => p.GetUsuario(Username, Password)).Returns(usuario);

        login.Setup(a => a.AutenticaUsername(Username, true));

        var controller = new AuthController(login2.Object, login.Object);


        var rederit = controller.Login(Username, Password);

        Assert.IsInstanceOf<RedirectToRouteResult>(rederit);
        Assert.IsNotInstanceOf<ViewResult>(rederit);

        }

        private class UsuarioSession
        {
            internal void AutenticaUsername(string username, bool v)
            {
                throw new NotImplementedException();
            }
        }
    }
}