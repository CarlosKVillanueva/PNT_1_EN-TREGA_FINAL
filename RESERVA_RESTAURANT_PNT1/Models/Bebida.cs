namespace RESERVA_RESTAURANT_PNT1.Models;

public class Bebida
{
    public int Id { get; set; }
    public float Cm3 { get; set; }
    public string Nombre { get; set; }
    public string Marca { get; set; }
    public float Precio { get; set; }
    public TipoBebida TipoBebida { get; set; }
    public Presentacion Presentacion { get; set; }
}