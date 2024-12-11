using System.Data;
using Dapper;
using MVC_Inventario.Models;
using MVC_Inventario.Request;

namespace MVC_Inventario.Data
{
    public class MovimientoInvData : IMovimientoInventario
    {
        private readonly Conexion _conexion;

        public MovimientoInvData(Conexion conexion)
        {
            _conexion = conexion;
        }
        public void ActualizarMovimientoInv(MovimientoInventarioModel _request)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@COD_CIA", _request.COD_CIA, DbType.String);
                parametros.Add("@COMPANIA_VENTA_3", _request.COMPANIA_VENTA_3, DbType.String);
                parametros.Add("@ALMACEN_VENTA", _request.ALMACEN_VENTA, DbType.String);
                parametros.Add("@TIPO_MOVIMIENTO", _request.TIPO_MOVIMIENTO, DbType.String);
                parametros.Add("@TIPO_DOCUMENTO", _request.TIPO_DOCUMENTO, DbType.String);
                parametros.Add("@NRO_DOCUMENTO", _request.NRO_DOCUMENTO, DbType.String);
                parametros.Add("@COD_ITEM_2", _request.COD_ITEM_2, DbType.String);
                parametros.Add("@PROVEEDOR", _request.PROVEEDOR, DbType.String);
                parametros.Add("@ALMACEN_DESTINO", _request.ALMACEN_DESTINO, DbType.String);
                parametros.Add("@CANTIDAD", _request.CANTIDAD, DbType.Int32);
                parametros.Add("@DOC_REF_1", _request.DOC_REF_1, DbType.String);
                parametros.Add("@DOC_REF_2", _request.DOC_REF_2, DbType.String);
                parametros.Add("@DOC_REF_3", _request.DOC_REF_3, DbType.String);
                parametros.Add("@DOC_REF_4", _request.DOC_REF_4, DbType.String);
                parametros.Add("@DOC_REF_5", _request.DOC_REF_5, DbType.String);
                conexion.Execute("SP_ACTUALIZAR_MOVIMIENTO_INV", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public void EliminarMovimientoInv(string pCodCIA)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@COD_CIA", pCodCIA, DbType.String);                
                conexion.Execute("SP_ELIMINAR_MOVIMIENTO_INV", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public void InsertarMovimientoInv(MovimientoInventarioModel _request)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@COD_CIA", _request.COD_CIA, DbType.String);
                parametros.Add("@COMPANIA_VENTA_3", _request.COMPANIA_VENTA_3, DbType.String);
                parametros.Add("@ALMACEN_VENTA", _request.ALMACEN_VENTA, DbType.String);
                parametros.Add("@TIPO_MOVIMIENTO", _request.TIPO_MOVIMIENTO, DbType.String);
                parametros.Add("@TIPO_DOCUMENTO", _request.TIPO_DOCUMENTO, DbType.String);
                parametros.Add("@NRO_DOCUMENTO", _request.NRO_DOCUMENTO, DbType.String);
                parametros.Add("@COD_ITEM_2", _request.COD_ITEM_2, DbType.String);
                parametros.Add("@PROVEEDOR", _request.PROVEEDOR, DbType.String);
                parametros.Add("@ALMACEN_DESTINO", _request.ALMACEN_DESTINO, DbType.String);
                parametros.Add("@CANTIDAD", _request.CANTIDAD, DbType.Int32);
                parametros.Add("@DOC_REF_1", _request.DOC_REF_1, DbType.String);
                parametros.Add("@DOC_REF_2", _request.DOC_REF_2, DbType.String);
                parametros.Add("@DOC_REF_3", _request.DOC_REF_3, DbType.String);
                parametros.Add("@DOC_REF_4", _request.DOC_REF_4, DbType.String);
                parametros.Add("@DOC_REF_5", _request.DOC_REF_5, DbType.String);
                conexion.Execute("SP_INSERTAR_MOVIMIENTO_INV", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public MovimientoInventarioModel ListarMovimientoPorCodigo(string codCia)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@CODIGO_CIA", codCia, DbType.String);
                return conexion.QueryFirstOrDefault<MovimientoInventarioModel>("SP_LISTAR_MOVIMIENTO_INV_CODIGO", 
                    parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<MovimientoInventarioModel> ListarMovimientos(RequestMovimientoInv _request)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@FECINICIO", _request.fecInicio, DbType.String);
                parametros.Add("@FECFINAL", _request.fecFinal, DbType.String);
                parametros.Add("@TIPMOVIMIENTO", _request.tipMovimiento, DbType.String);
                parametros.Add("@NRODOCUMENTO", _request.nroDocumento, DbType.String);
                return conexion.Query<MovimientoInventarioModel>("SP_LISTAR_MOVIMIENTO_INV", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
        }

    }
}