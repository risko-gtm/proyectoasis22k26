

using CapaModelo_ExamenF.Contratos;
using CapaModelo_ExamenF.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaModelo_ExamenF.Repositorios
{
    public class ClsRepositorioDirector :
        ClsRepositorioMaestro, IRepositorioDirector
    {
        private readonly string _SelectAll;

        public ClsRepositorioDirector()
        {
            _SelectAll =
                "SELECT " +
                "id_director AS Pk_Director, " +
                "nombre AS Nombre, " +
                "nacionalidad AS Nacionalidad, " +
                "fecha_nacimiento AS FechaNacimiento " +
                "FROM Directores " +
                "ORDER BY nombre ASC";
        }

        public IEnumerable<ClsDirector> LogisticaMetObtenerTodos()
        {
            var ListaDirectores = new List<ClsDirector>();

            var TablaDatos = LogisticaMetEjecucionConsulta(
                _SelectAll,
                CommandType.Text
            );

            foreach (DataRow Fila in TablaDatos.Rows)
            {
                var Director = new ClsDirector
                {
                    Pk_Director = Convert.ToInt32(
                        Fila["Pk_Director"]
                    ),

                    Nombre = Fila["Nombre"].ToString(),

                    Nacionalidad = Fila.IsNull("Nacionalidad")
                        ? ""
                        : Fila["Nacionalidad"].ToString(),

                    FechaNacimiento = Fila.IsNull("FechaNacimiento")
                        ? (DateTime?)null
                        : Convert.ToDateTime(Fila["FechaNacimiento"])
                };

                ListaDirectores.Add(Director);
            }

            return ListaDirectores;
        }
    }
}
