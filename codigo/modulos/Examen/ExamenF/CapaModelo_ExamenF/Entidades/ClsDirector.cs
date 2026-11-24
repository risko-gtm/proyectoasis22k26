
/*
 * Autor: [Nombre del estudiante]
 * Descripción: Representa la información de los directores.
 */

using System;

namespace CapaModelo_ExamenF.Entidades
{
    public class ClsDirector
    {
        public int Pk_Director { get; set; }

        public string Nombre { get; set; }

        public string Nacionalidad { get; set; }

        public DateTime? FechaNacimiento { get; set; }
    }
}
