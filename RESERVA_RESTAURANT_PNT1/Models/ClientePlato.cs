using System.ComponentModel.DataAnnotations;

namespace RESERVA_RESTAURANT_PNT1.Models;

public class ClientePlato
{
    [Key]
    public int ClienteId { get; set; }
    [Key]
    public int PlatoId { get; set; }
    public Cliente Cliente { get; set; }
    public Plato Plato { get; set; }
}