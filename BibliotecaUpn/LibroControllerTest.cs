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
   public class LibroControllerTest:Libro
    {
        private AppBibliotecaContext app;

        [Test]
        public void DebePoderRetonarUnDetalleId()
        {
            var retornarDetalle = new Mock<AppBibliotecaContext>();


            Libro libro = new Libro()
            {
                Nombre = "el codigo dainci",
                Id = 1,
                Autor = new Autor()
                {
                    Id = 1,
                    Nombres = "Libro1"
                },
                Comentarios = new List<Comentario>()
                {
                    new Comentario()
                    {
                        Id = 1,
                        Texto = "......"
                    }
                }
            };

            

            var controller = new LibroController(app);

            var resultado = controller.Details(1) as ViewResult;

            Assert.IsInstanceOf<Libro>(resultado.Model);
            Assert.IsInstanceOf<ViewResult>(resultado);
        }
        [Test]
        public void NoDebePoderRetonarUnDetalleId()
        {
            var retornarDetalle = new Mock<AppBibliotecaContext>();

            Libro libro = new Libro()
            {

                Nombre = "El codigo dainci",
                Id = 1,
                Autor = new Autor()
                {
                    Id = 1,
                    Nombres = "Libro1"
                },
                Comentarios = new List<Comentario>()
                {
                    new Comentario()
                    {
                        Id = 1,
                        Texto = "......"
                    }
                }
            };

         

            var controller = new LibroController(app);

            var resultado = controller.Details(2) as ViewResult;

            Assert.IsNull(resultado.Model);
            Assert.IsInstanceOf<ViewResult>(resultado);
        }
        [Test]
        public void DebePoderAddComentario()
        {
            var agregarComentario = new Mock<IAddComentario>();

            var sess = new Mock<IUsuario>();

            Usuario usuario = new Usuario()
            {
                Id = 1,
                Nombres = "oscar",
                Password = "Admin",
                Username = "Admin"
            };

            Comentario comentario = new Comentario()
            {

                Texto = "El codigo dainci",
                Id = 1,
                Puntaje = 3,
                UsuarioId = 1,
                LibroId = 1,
                Fecha = DateTime.Now.Date
            };
            agregarComentario.Setup(a => a.AddComentario(comentario, usuario));

            sess.Setup(s => s.setNombreUsuario()).Returns(usuario);

            var controller = new LibroController(app);

            var resultado = controller.AddComentario(comentario);

            Assert.IsInstanceOf<RedirectToRouteResult>(resultado);
        }



    }
}




