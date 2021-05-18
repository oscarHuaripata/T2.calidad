using CalidadT2.Controllers;
using CalidadT2.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaUpn
{
    [TestFixture]
    public class BibliotecaControllerTests
    {

        [Test]
        public void ListaDeBibliotecas()
        {
            var sess = new Mock<Usuario>();
            var list = new Mock<Biblioteca>();
            Usuario usuario = new Usuario()
            {
                Id = 1,
                Nombres = "Oscar",
                Password = "Admin",
                Username = "Admin"
            };

            sess.Setup(s => s.setNombreUsuario()).Returns(usuario);
            list.Setup(a => a.GetBibliotecas(usuario)).Returns(new List<Biblioteca>());

            var listaBi = new BibliotecaController(list.Object, sess.Object);

            var view = listaBi.Index() as ViewResult;

            Assert.IsInstanceOf<List<Biblioteca>>(view.Model);
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void AddBiblioteca()
        {
            var sess = new Mock<Usuario>();
            var list = new Mock<Biblioteca>();
            Usuario usuario = new Usuario()
            {
                Id = 1,
                Nombres = "Oscar",
                Password = "Admin",
                Username = "Admin"
            };

            sess.Setup(s => s.setNombreUsuario()).Returns(usuario);
            list.Setup(a => a.GetBibliotecas(usuario)).Returns(new List<Biblioteca>());

            var listaBi = new BibliotecaController(list.Object, sess.Object);

            var view = listaBi.Add(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
        [Test]
        public void MarcarComoLeyendo()
        {
            var sess = new Mock<Usuario>();
            var list = new Mock<Biblioteca>();
            Usuario usuario = new Usuario()
            {
                Id = 1,
                Nombres = "Oscar",
                Password = "Admin",
                Username = "Admin"
            };

            sess.Setup(s => s.setNombreUsuario()).Returns(usuario);
            list.Setup(a => a.GetBibliotecas(usuario)).Returns(new List<Biblioteca>());

            var listaBi = new BibliotecaController(list.Object, sess.Object);

            var view = listaBi.MarcarComoLeyendo(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
        [Test]
        public void MarcarComoTerminado()
        {
            var sess = new Mock<Usuario>();
            var list = new Mock<Biblioteca>();
            Usuario usuario = new Usuario()
            {
                Id = 1,
                Nombres = "Oscar",
                Password = "Admin",
                Username = "Admin"
            };

            sess.Setup(s => s.setNombreUsuario()).Returns(usuario);
            list.Setup(a => a.GetBibliotecas(usuario)).Returns(new List<Biblioteca>());

            var listaBi = new BibliotecaController(list.Object, sess.Object);

            var view = listaBi.MarcarComoTerminado(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }

    }

}