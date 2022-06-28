using Microsoft.AspNetCore.Mvc;
using RESERVA_RESTAURANT_PNT1.Data;
using RESERVA_RESTAURANT_PNT1.Models;

namespace RESERVA_RESTAURANT_PNT1.Controllers
{
    public class ReservasController : Controller
    {

        private readonly RestaurantContext _restaurantContext;

        public ReservasController(RestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public IActionResult Index()
        {
            var reservas = _restaurantContext.Reservas.ToList();


            return View(reservas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string nombre, string apellido, int dni, string telefono, string mail, int comensales,
                                    DateTime fecha, DateTime hora, FormaPago formaPago, bool newsletter)
        {
            Reserva reserva = new Reserva()
            {
                Nombre = nombre,
                Apellido = apellido,
                Dni = dni,
                Telefono = telefono,
                Mail = mail,
                Comensales = comensales,
                Fecha = fecha,
                Hora = hora,
                FormaPago = formaPago,
                Newsletter = newsletter
            };

            _restaurantContext.Reservas.Add(reserva);
            _restaurantContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
