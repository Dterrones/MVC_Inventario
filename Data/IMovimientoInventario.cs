using MVC_Inventario.Models;
using MVC_Inventario.Request;

namespace MVC_Inventario.Data
{
    public interface IMovimientoInventario
    {
        IEnumerable<MovimientoInventarioModel> ListarMovimientos(RequestMovimientoInv request);
        void InsertarMovimientoInv(MovimientoInventarioModel request);
        void ActualizarMovimientoInv(MovimientoInventarioModel request);
        void EliminarMovimientoInv(string request);
        MovimientoInventarioModel ListarMovimientoPorCodigo(string codCia);
    }
}
