
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

using CapaControlador_ExamenF.Modelos_de_Controladores;
using CapaModelo_ExamenF.Contratos;
using CapaModelo_ExamenF.Entidades;

namespace TestDirector
{
    [TestClass]
    public class UnitTest1
    {
        // PRUEBA 1:
        // Verificar que se obtengan y conviertan correctamente
        // los datos de un director.

        [TestMethod]
        public void LogisticaMetObtenerTodos_ConDatosValidos_RetornaDirectores()
        {
            // ARRANGE
            var ListaFalsa = new List<ClsDirector>
            {
                new ClsDirector
                {
                    Pk_Director = 1,
                    Nombre = "Juan Perez",
                    Nacionalidad = "Guatemalteca",
                    FechaNacimiento = new DateTime(1980, 5, 15)
                }
            };

            var RepositorioFalso =
                new RepositorioDirectorFalso(ListaFalsa);

            var Controlador =
                new ClsModelosDirector(RepositorioFalso);

            // ACT
            var Resultado = Controlador.LogisticaMetObtenerTodos();

            // ASSERT
            Assert.IsNotNull(Resultado);
            Assert.AreEqual(1, Resultado.Count);

            Assert.AreEqual(1, Resultado[0].PkDirector);
            Assert.AreEqual("Juan Perez", Resultado[0].Nombre);
            Assert.AreEqual("Guatemalteca", Resultado[0].Nacionalidad);
            Assert.AreEqual("15/05/1980", Resultado[0].FechaNacimiento);
        }


        // PRUEBA 2:
        // Verificar que una fecha de nacimiento nula
        // se convierta en una cadena vacía.

        [TestMethod]
        public void LogisticaMetObtenerTodos_SinFechaNacimiento_RetornaFechaVacia()
        {
            // ARRANGE
            var ListaFalsa = new List<ClsDirector>
            {
                new ClsDirector
                {
                    Pk_Director = 2,
                    Nombre = "Maria Lopez",
                    Nacionalidad = "Mexicana",
                    FechaNacimiento = null
                }
            };

            var RepositorioFalso =
                new RepositorioDirectorFalso(ListaFalsa);

            var Controlador =
                new ClsModelosDirector(RepositorioFalso);

            // ACT
            var Resultado = Controlador.LogisticaMetObtenerTodos();

            // ASSERT
            Assert.IsNotNull(Resultado);
            Assert.AreEqual(1, Resultado.Count);
            Assert.AreEqual("", Resultado[0].FechaNacimiento);
        }


        // PRUEBA 3:
        // Verificar que cuando no existen directores
        // se retorne una lista vacía.

        [TestMethod]
        public void LogisticaMetObtenerTodos_SinRegistros_RetornaListaVacia()
        {
            // ARRANGE
            var ListaFalsa = new List<ClsDirector>();

            var RepositorioFalso =
                new RepositorioDirectorFalso(ListaFalsa);

            var Controlador =
                new ClsModelosDirector(RepositorioFalso);

            // ACT
            var Resultado = Controlador.LogisticaMetObtenerTodos();

            // ASSERT
            Assert.IsNotNull(Resultado);
            Assert.AreEqual(0, Resultado.Count);
        }


        // REPOSITORIO FALSO:
        // Simula la respuesta del repositorio real sin utilizar MySQL.

        private class RepositorioDirectorFalso : IRepositorioDirector
        {
            private readonly IEnumerable<ClsDirector> _Directores;

            public RepositorioDirectorFalso(
                IEnumerable<ClsDirector> Directores)
            {
                _Directores = Directores;
            }

            public IEnumerable<ClsDirector> LogisticaMetObtenerTodos()
            {
                return _Directores;
            }
        }
    }
}
