using System.ComponentModel.DataAnnotations;
using RESERVA_RESTAURANT_PNT1.Helpers;

namespace RESERVA_RESTAURANT_PNT1.Models;

public class Persona
{
    public int Id { get; set; }
    [Required(ErrorMessage =MensajesError.Requerido)]
    [StringLength(Restricciones.Ceil3,MinimumLength =Restricciones.Floor1,ErrorMessage =MensajesError.MaxMinStr)]
    public string Nombre { get; set; }

    [Required(ErrorMessage = MensajesError.Requerido)]
    [MaxLength(Restricciones.Ceil3,ErrorMessage = MensajesError.MaxStr)]
    public string Apellido { get; set; }

    [Required(ErrorMessage = MensajesError.Requerido)]
    [Range(Restricciones.FloorDni,Restricciones.CeilDni,ErrorMessage = MensajesError.MinMaxStr)]
    [Display(Name = "DNI")]
    public int Dni { get; set; }

    [Required(ErrorMessage =MensajesError.Requerido)]
    [EmailAddress(ErrorMessage = MensajesError.Invalido)]
    [Display(Name = "Correo Electronico")]
    public string Mail { get; set; }
}