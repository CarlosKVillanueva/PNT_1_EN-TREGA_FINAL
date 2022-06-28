namespace RESERVA_RESTAURANT_PNT1.Models;

public class Menu
{
    public int Id { get; set; }
    public DateTime fechaVigenicia { get; set; }
    public Plato Plato { get; set; }
    public Bebida Bebida { get; set; }
}