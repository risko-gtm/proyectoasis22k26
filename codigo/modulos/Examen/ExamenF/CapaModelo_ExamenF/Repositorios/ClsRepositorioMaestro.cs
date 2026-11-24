

using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo_ExamenF.Repositorios
{
    public abstract class ClsRepositorioMaestro : ClsRepositorio
    {
        private DataTable _TablaDatos;

        public DataTable LogisticaMetEjecucionConsulta(string ComandoTexto, CommandType ComandoTipo)
        {
            _TablaDatos = new DataTable();

            using (var ConexionActiva = LogisticaMetObtenerConexion())
            {
                ConexionActiva.Open();

                using (var Comando = new OdbcCommand())
                {
                    Comando.Connection = ConexionActiva;
                    Comando.CommandText = ComandoTexto;
                    Comando.CommandType = ComandoTipo;

                    using (var LectorDatos = Comando.ExecuteReader())
                    {
                        _TablaDatos.Load(LectorDatos);
                    }
                }

                return _TablaDatos;
            }
        }

        public DataTable LogisticaMetEjecucionConsulta(
            string ComandoTexto,
            CommandType ComandoTipo,
            List<OdbcParameter> Parametros)
        {
            _TablaDatos = new DataTable();

            using (var ConexionActiva = LogisticaMetObtenerConexion())
            {
                ConexionActiva.Open();

                using (var Comando = new OdbcCommand())
                {
                    Comando.Connection = ConexionActiva;
                    Comando.CommandText = ComandoTexto;
                    Comando.CommandType = ComandoTipo;
                    Comando.Parameters.AddRange(Parametros.ToArray());

                    using (var LectorDatos = Comando.ExecuteReader())
                    {
                        _TablaDatos.Load(LectorDatos);
                    }
                }

                return _TablaDatos;
            }
        }
    }
}