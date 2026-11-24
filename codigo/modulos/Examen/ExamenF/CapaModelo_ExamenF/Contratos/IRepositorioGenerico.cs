
using System.Collections.Generic;

namespace CapaModelo_ExamenF.Contratos
{
    public interface IRepositorioGenerico<Entidad> where Entidad : class
    {
        IEnumerable<Entidad> LogisticaMetObtenerTodos();
    }
}