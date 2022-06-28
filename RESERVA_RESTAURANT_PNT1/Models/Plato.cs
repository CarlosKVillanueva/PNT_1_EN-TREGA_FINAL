using System.ComponentModel.DataAnnotations;

namespace RESERVA_RESTAURANT_PNT1.Models;

public class Plato
{
    public int Id { get; set; }
    [Required(ErrorMessage = MensajesError.Requerido)]
    public string Nombre { get; set; }
    [Required(ErrorMessage = MensajesError.Requerido)]
    public float Peso { get; set; }
    [Required(ErrorMessage = MensajesError.Requerido)]
    public float Precio { get; set; }
    [Required(ErrorMessage = MensajesError.Requerido)]
    public TipoPlato TipoPlato { get; set; }

    public List<ClientePlato> FueConsumido { get; set; }
}