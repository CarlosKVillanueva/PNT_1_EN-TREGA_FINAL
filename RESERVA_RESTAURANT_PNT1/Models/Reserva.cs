using System.ComponentModel.DataAnnotations;
using RESERVA_RESTAURANT_PNT1.Helpers;

namespace RESERVA_RESTAURANT_PNT1.Models
{
    public class Reserva
    {

        public int Id{ get; set; }

        [Required(ErrorMessage = MensajesError.Requerido)]
        [StringLength(Restricciones.Ceil3, MinimumLength = Restricciones.Floor1, ErrorMessage = MensajesError.MaxMinStr)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = MensajesError.Requerido)]
        [StringLength(Restricciones.Ceil3, MinimumLength = Restricciones.Floor1, ErrorMessage = MensajesError.MaxMinStr)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = MensajesError.Requerido)]
        [Range(Restricciones.FloorDni, Restricciones.CeilDni, ErrorMessage = MensajesError.MinMaxStr)]
        public int Dni { get; set; }

        [Required(ErrorMessage = MensajesError.Requerido)]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = MensajesError.Requerido)]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Required(ErrorMessage = MensajesError.Requerido)]
        [Range(Restricciones.Floor1, Restricciones.Ceil1, ErrorMessage = MensajesError.MinMaxStr)]
        public int Comensales { get; set; }

        [Required(ErrorMessage = MensajesError.Requerido)]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = MensajesError.Requerido)]
        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }

        [Required(ErrorMessage = MensajesError.Requerido)]
        public FormaPago FormaPago { get; set; }

        [Required(ErrorMessage = MensajesError.Requerido)]
        public bool Newsletter { get; set; }
    }
}
