using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaControlador_Contabilidad;
using CapaModelo_Contabilidad.Entidades;

namespace Pruebas_Contabilidad
{
    // ====================================================================
    // PRUEBAS PARA EL MODELO (VALIDACIONES)
    // ====================================================================
    [TestClass]
    public class ClsPruebasModeloActivoFijo
    {
        [TestMethod]
        public void Modelo_Validate_DatosValidos_NoRetornaErrores()
        {
            // Arrange
            ClsModeloActivoFijoContabilidad Modelo = new ClsModeloActivoFijoContabilidad
            {
                Descripcion = "Computadora",
                Adquisicion = new DateTime(2026, 1, 1),
                Inicio = new DateTime(2026, 2, 1),
                Compra = 5000m,
                Residual = 500m,
                Meses = 36
            };
            ValidationContext Contexto = new ValidationContext(Modelo);

            // Act
            List<ValidationResult> Errores = Modelo.Validate(Contexto).ToList();

            // Assert
            Assert.AreEqual(0, Errores.Count);
        }

        [TestMethod]
        public void Modelo_Validate_InicioAnteriorAAdquisicion_RetornaErrorInicio()
        {
            // Arrange
            ClsModeloActivoFijoContabilidad Modelo = new ClsModeloActivoFijoContabilidad
            {
                Descripcion = "Computadora",
                Adquisicion = new DateTime(2026, 5, 1),
                Inicio = new DateTime(2026, 4, 1), // Fecha inválida
                Compra = 5000m,
                Residual = 500m,
                Meses = 36
            };
            ValidationContext Contexto = new ValidationContext(Modelo);

            // Act
            List<ValidationResult> Errores = Modelo.Validate(Contexto).ToList();

            // Assert
            Assert.AreEqual(1, Errores.Count);
            Assert.IsTrue(Errores[0].MemberNames.Contains("Inicio"));
        }

        [TestMethod]
        public void Modelo_Validate_CompraMenorOIgualACero_RetornaErrorCompra()
        {
            // Arrange
            ClsModeloActivoFijoContabilidad Modelo = new ClsModeloActivoFijoContabilidad
            {
                Descripcion = "Computadora",
                Adquisicion = new DateTime(2026, 1, 1),
                Inicio = new DateTime(2026, 2, 1),
                Compra = 0m, // Inválido
                Residual = 0m,
                Meses = 36
            };
            ValidationContext Contexto = new ValidationContext(Modelo);

            // Act
            List<ValidationResult> Errores = Modelo.Validate(Contexto).ToList();

            // Assert
            Assert.AreEqual(1, Errores.Count);
            Assert.IsTrue(Errores[0].MemberNames.Contains("Compra"));
        }

        [TestMethod]
        public void Modelo_Validate_ResidualMayorQueCompra_RetornaErrorResidual()
        {
            // Arrange
            ClsModeloActivoFijoContabilidad Modelo = new ClsModeloActivoFijoContabilidad
            {
                Descripcion = "Computadora",
                Adquisicion = new DateTime(2026, 1, 1),
                Inicio = new DateTime(2026, 2, 1),
                Compra = 1000m,
                Residual = 1500m, // Mayor a la compra (Inválido)
                Meses = 36
            };
            ValidationContext Contexto = new ValidationContext(Modelo);

            // Act
            List<ValidationResult> Errores = Modelo.Validate(Contexto).ToList();

            // Assert
            Assert.AreEqual(1, Errores.Count);
            Assert.IsTrue(Errores[0].MemberNames.Contains("Residual"));
        }
    }

    // ====================================================================
    // PRUEBAS PARA EL CONTROLADOR (LÓGICA DE VALIDACIÓN Y ERRORES)
    // ====================================================================
    [TestClass]
    public class ClsPruebasControladorActivosFijos
    {
        private ClsControladorActivosFijosContabilidad Controlador;

        [TestInitialize]
        public void Inicializar()
        {
            Controlador = new ClsControladorActivosFijosContabilidad();
        }

        // --- ContabilidadFuncErroresActivo ---

        [TestMethod]
        public void ErroresActivo_DatosValidos_RetornaDiccionarioVacio()
        {
            // Arrange
            string Descripcion = "Laptop";
            DateTime Adquisicion = new DateTime(2026, 1, 15);
            DateTime Inicio = new DateTime(2026, 2, 1);
            decimal Compra = 5000m;
            decimal Residual = 500m;
            int Meses = 36;

            // Act
            Dictionary<string, string> Errores = Controlador.ContabilidadFuncErroresActivo(
                Descripcion, Adquisicion, Inicio, Compra, Residual, Meses);

            // Assert
            Assert.AreEqual(0, Errores.Count);
        }

        [TestMethod]
        public void ErroresActivo_DescripcionVacia_RetornaErrorDescripcion()
        {
            // Arrange
            string Descripcion = ""; // Inválido (Required)
            DateTime Adquisicion = new DateTime(2026, 1, 15);
            DateTime Inicio = new DateTime(2026, 2, 1);
            decimal Compra = 5000m;
            decimal Residual = 500m;
            int Meses = 36;

            // Act
            Dictionary<string, string> Errores = Controlador.ContabilidadFuncErroresActivo(
                Descripcion, Adquisicion, Inicio, Compra, Residual, Meses);

            // Assert
            Assert.IsTrue(Errores.ContainsKey("Descripcion"));
        }

        // --- ContabilidadFuncValidarActivo ---

        [TestMethod]
        public void ValidarActivo_DatosValidos_RetornaCadenaVacia()
        {
            // Arrange
            string Descripcion = "Computadora";
            DateTime Adquisicion = new DateTime(2026, 1, 15);
            DateTime Inicio = new DateTime(2026, 2, 1);
            decimal Compra = 5000m;
            decimal Residual = 500m;
            int Meses = 36;

            // Act
            string Mensaje = Controlador.ContabilidadFuncValidarActivo(
                Descripcion, Adquisicion, Inicio, Compra, Residual, Meses);

            // Assert
            Assert.AreEqual(string.Empty, Mensaje);
        }

        [TestMethod]
        public void ValidarActivo_DatosInvalidos_RetornaPrimerMensajeDeError()
        {
            // Arrange
            string Descripcion = "";
            DateTime Adquisicion = new DateTime(2026, 1, 15);
            DateTime Inicio = new DateTime(2026, 2, 1);
            decimal Compra = 5000m;
            decimal Residual = 500m;
            int Meses = 36;

            // Act
            string Mensaje = Controlador.ContabilidadFuncValidarActivo(
                Descripcion, Adquisicion, Inicio, Compra, Residual, Meses);

            // Assert
            Assert.AreNotEqual(string.Empty, Mensaje);
            Assert.IsNotNull(Mensaje);
        }

        // --- ContabilidadFuncGrabarCambios (Pruebas de validación temprana) ---
        // NOTA: Solo probamos cuando falla la validación para evitar que intente conectarse a la BD.

        [TestMethod]
        public void GrabarCambios_DescripcionVacia_RetornaFalseConMensaje()
        {
            // Arrange
            int IdActivo = 0;
            string Descripcion = "";
            string Modulo = "Logística";
            string Tipo = "VEHICULO";
            DateTime Adquisicion = new DateTime(2026, 1, 15);
            DateTime Inicio = new DateTime(2026, 2, 1);
            decimal Compra = 5000m;
            decimal Residual = 500m;
            int Meses = 36;
            string Mensaje;

            // Act
            bool Resultado = Controlador.ContabilidadFuncGrabarCambios(
                EstadoEntidadContabilidad.Agregar, ref IdActivo, Descripcion, Modulo, Tipo,
                Adquisicion, Inicio, Compra, Residual, Meses, out Mensaje);

            // Assert
            Assert.IsFalse(Resultado);
            Assert.AreNotEqual(string.Empty, Mensaje);
        }

        [TestMethod]
        public void GrabarCambios_ModuloOTipoVacio_RetornaFalseConMensaje()
        {
            // Arrange
            int IdActivo = 0;
            string Descripcion = "Laptop";
            string Modulo = ""; // Inválido por código del controlador
            string Tipo = "EQ_COMPUTO";
            DateTime Adquisicion = new DateTime(2026, 1, 15);
            DateTime Inicio = new DateTime(2026, 2, 1);
            decimal Compra = 5000m;
            decimal Residual = 500m;
            int Meses = 36;
            string Mensaje;

            // Act
            bool Resultado = Controlador.ContabilidadFuncGrabarCambios(
                EstadoEntidadContabilidad.Agregar, ref IdActivo, Descripcion, Modulo, Tipo,
                Adquisicion, Inicio, Compra, Residual, Meses, out Mensaje);

            // Assert
            Assert.IsFalse(Resultado);
            Assert.AreEqual("Seleccione el módulo y el tipo de activo.", Mensaje);
        }
    }

    // ====================================================================
    // PRUEBAS PARA EL ENLACE CON LOGÍSTICA (REFLEXIÓN)
    // ====================================================================
    [TestClass]
    public class ClsPruebasEnlaceLogistica
    {
        [TestMethod]
        public void BuscarReceptor_SinDllDeLogistica_RetornaNull()
        {
            // Arrange
            // (No se hace nada, confiamos en que el entorno de prueba no tiene la DLL de Logística cargada)

            // Act
            IReceptorActivoFijoContabilidad Receptor = ClsEnlaceLogisticaContabilidad.ContabilidadFuncBuscarReceptor();

            // Assert
            // Como no hay un DLL de Logística en la carpeta de ejecución de las pruebas, debería retornar null
            Assert.IsNull(Receptor);
        }
    }
}