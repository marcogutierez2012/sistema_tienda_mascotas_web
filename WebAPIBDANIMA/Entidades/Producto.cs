namespace WebAPIBDANIMA.Entidades
{
    public class Producto
    {
        public string? codprod { get; set; }
        public string? desprod { get; set; }
        public decimal preprod { get; set; }
        public int stkprod { get; set; }
        public int codanimal { get; set; }
        public int codtipopro { get; set; }
        public string? eliminado { get; set; }
    }
}
