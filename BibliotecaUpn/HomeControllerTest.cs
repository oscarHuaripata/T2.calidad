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
        public class HomeControllerTest
        {
            [Test]

            public void DebePoderRetornarUnaListaDeLibros()
            {
                var lista = new Mock<AppBibliotecaContext>();

                

                var controller = new HomeController(lista.Object);



                var view = controller.Index() as ViewResult;

                Assert.IsInstanceOf<ViewResult>(view);
                Assert.IsInstanceOf<List<Libro>>(view.Model);
            }
            [Test]

            public void NoDebePoderRetornarUnaListaDeLibros()
            {
                var lista = new Mock<AppBibliotecaContext>();

              

                var controller = new HomeController(lista.Object);

                var view = controller.Index() as ViewResult;

                Assert.IsInstanceOf<ViewResult>(view);
                Assert.IsNull(view.Model);
            }
        }
    }


