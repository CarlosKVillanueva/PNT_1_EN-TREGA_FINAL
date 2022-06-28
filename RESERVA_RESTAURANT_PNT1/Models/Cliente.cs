using System.ComponentModel.DataAnnotations;
using RESERVA_RESTAURANT_PNT1.Helpers;

namespace RESERVA_RESTAURANT_PNT1.Models;

public class Cliente : Persona
{
    [Required(ErrorMessage = MensajesError.Requerido)]
    [Range(Restricciones.FloorCuil, Restricciones.CeilCuil, ErrorMessage = MensajesError.MinMaxStr)]
    public long Cuit { get; set; }
    public Direccion Direccion { get; set; }
    public List<ClientePlato> PlatosConsumidos { get; set; }
}