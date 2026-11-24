
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: FrmProveedor.cs
 *
 * REALIZADO POR: VELVETH SARAÍ CHÁVEZ MEJÍA
 * CARNÉ: 0901 23 6269
 *
 * DESCRIPCIÓN:
 * Formulario de mantenimiento de proveedores del examen parcial final 
 * realizado el 24/11/2026
 * Permite gestionar los registros mediante el Navegador
 * y generar reportes con los datos registrados.
 * Ádemas, se implemento la ayuda dinamica
 * ============================================================================
 */



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CapaVista_Proveedor_Logistica.Formularios
{
    public partial class FrmProveedor : Form
    {

        public FrmProveedor()
        {
            InitializeComponent();

            // ================================================
            // OBTENER LOS REGISTROS DE BODEGAS
            // ================================================


            // ================================================
            // CONFIGURAR EL NAVEGADOR
            // ================================================

            LogisticaNavProveedores.NavegadorMetConfigurar("tbl_proveedor", 5000, 5030);

        }

        private void LogisticaNavProveedores_Load(object sender, EventArgs e)
        {

        }
    }
}
