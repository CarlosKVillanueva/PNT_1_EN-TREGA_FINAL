using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESERVA_RESTAURANT_PNT1.Models;

public class Direccion
{
    [Display(Name = "Cliente")]
    [Key, ForeignKey("Cliente")]
    public int Id { get; set; }

    [Required(ErrorMessage = MensajesError.Requerido)]
    public string Calle { get; set; }
    [Required(ErrorMessage = MensajesError.Requerido)]
    public int Numero { get; set; }
    [Required(ErrorMessage = MensajesError.Requerido)]
    public int Piso { get; set; } = 0;
    public string Departamento { get; set; } = "N/A";
    public string CodigoPostal { get; set; }
    public Cliente Cliente { get; set; }
}