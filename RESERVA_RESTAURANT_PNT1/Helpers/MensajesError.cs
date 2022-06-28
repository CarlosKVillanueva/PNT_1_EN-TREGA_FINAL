namespace RESERVA_RESTAURANT_PNT1.Models;

public static class MensajesError
{
    public const string Requerido = "El campo {0} es obligatorio";
    public const string MaxMinStr = "El campo {0}, debe tener un mínimo de {2} y un máximo de {1}";
    public const string MinMaxStr = "El campo {0} debe estar comprendido entre {1} y {2}";
    public const string MaxStr = "El campo {0} debe tener un maximo de {1}";
    public const string Invalido = "El campo {0} no es valido";
}