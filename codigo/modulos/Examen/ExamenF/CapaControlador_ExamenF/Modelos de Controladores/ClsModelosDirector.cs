
using System;
using System.Collections.Generic;
using System.Globalization;
using CapaModelo_ExamenF.Contratos;
using CapaModelo_ExamenF.Entidades;
using CapaModelo_ExamenF.Repositorios;

namespace CapaControlador_ExamenF.Modelos_de_Controladores
{
    public class ClsModelosDirector
    {
        private readonly IRepositorioDirector _RepositorioDirector;

        public int PkDirector { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public string FechaNacimiento { get; set; }

        // Constructor normal para utilizar el repositorio real
        public ClsModelosDirector()
            : this(new ClsRepositorioDirector())
        {
        }

        // Constructor para realizar pruebas unitarias
        public ClsModelosDirector(IRepositorioDirector repositorioDirector)
        {
            if (repositorioDirector == null)
            {
                throw new ArgumentNullException(nameof(repositorioDirector));
            }

            _RepositorioDirector = repositorioDirector;
        }

        public List<ClsModelosDirector> LogisticaMetObtenerTodos()
        {
            var ResultadoConsulta =
                _RepositorioDirector.LogisticaMetObtenerTodos();

            var ListaDirectores = new List<ClsModelosDirector>();

            if (ResultadoConsulta == null)
            {
                return ListaDirectores;
            }

            foreach (ClsDirector Item in ResultadoConsulta)
            {
                ListaDirectores.Add(new ClsModelosDirector
                {
                    PkDirector = Item.Pk_Director,
                    Nombre = Item.Nombre,
                    Nacionalidad = Item.Nacionalidad,

                    FechaNacimiento = Item.FechaNacimiento.HasValue
                        ? Item.FechaNacimiento.Value.ToString(
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture)
                        : ""
                });
            }

            return ListaDirectores;
        }
    }
}
