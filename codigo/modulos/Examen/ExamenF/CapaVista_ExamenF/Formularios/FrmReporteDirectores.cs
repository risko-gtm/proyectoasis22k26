

using CapaControlador_ExamenF.Modelos_de_Controladores;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaVista_ExamenF.Formularios
{
    public partial class FrmReporteDirectores : Form
    {
        ClsModelosDirector _DatosDirector = new ClsModelosDirector();

        Dictionary<string, object> _FuentesReporteDirectores =
            new Dictionary<string, object>();

        // Constructor del formulario
        public FrmReporteDirectores()
        {
            InitializeComponent();

            
            
                // 1. Obtener los directores
                var ListaDirectores = _DatosDirector.LogisticaMetObtenerTodos();

                // 3. Agregar los datos al diccionario
                _FuentesReporteDirectores.Add("DsDirectores", ListaDirectores);

                // 4. Configurar el navegador
                navegador1.NavegadorMetConfigurar(
                    "Directores",
                    15000,
                    15001,
                    _FuentesReporteDirectores
                );

                MessageBox.Show("Configuración del navegador ejecutada.");
   
            }
        }
       
    }
