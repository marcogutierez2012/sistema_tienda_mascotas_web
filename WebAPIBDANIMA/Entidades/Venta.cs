namespace WebAPIBDANIMA.Entidades
{
    public class Venta
    {
        public string? codventa { get; set; }
        public string? fecventa { get; set; }
        public int codtipoven { get; set; }
        public string? codcli { get; set; }
        public string? codemp { get; set; }
        public string? codconsul { get; set; }
        public decimal total { get; set; }
        public string? anulado { get; set; }
    }
}
