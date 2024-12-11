using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using MVC_Inventario.Data;
using MVC_Inventario.Models;
using MVC_Inventario.Request;

namespace webInventario.Controllers
{
    public class MovimientoInventarioController : Controller
    {

        private readonly IMovimientoInventario _movimientoInventario;
        public MovimientoInventarioController(IMovimientoInventario movimientoInventario) {
            _movimientoInventario = movimientoInventario;
        }

        public IActionResult Index()
        {
            var producto = _movimientoInventario.ListarMovimientos(new());
            return View(producto);
        }
        [HttpGet]
        public IActionResult Index(RequestMovimientoInv request)
        {
            var producto = _movimientoInventario.ListarMovimientos(request);
            return View(producto);
        }

        public IActionResult Registrar() {
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(MovimientoInventarioModel request)
        {
            _movimientoInventario.InsertarMovimientoInv(request);
            return RedirectToAction("Index");
        }
        public IActionResult Actualizar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Actualizar(MovimientoInventarioModel request)
        {
            _movimientoInventario.ActualizarMovimientoInv(request);
            return RedirectToAction("Index");
        }
        
        public IActionResult Eliminar(string codcia)
        {
            var movimiento = _movimientoInventario.ListarMovimientoPorCodigo(codcia);
            return View(movimiento);
        }
        [HttpPost]
        public IActionResult EliminarConfirmado(string codcia)
        {
            _movimientoInventario.EliminarMovimientoInv(codcia);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(string codcia)
        {
            var movimiento = _movimientoInventario.ListarMovimientoPorCodigo(codcia);
            return View(movimiento);
        }

        [HttpPost]
        public IActionResult Editar(MovimientoInventarioModel request)
        {
            _movimientoInventario.ActualizarMovimientoInv(request);
            return RedirectToAction("Index");
        }

    }
}
