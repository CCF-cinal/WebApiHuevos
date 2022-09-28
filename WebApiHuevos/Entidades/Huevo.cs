namespace WebApiHuevos.Entidades
{
    public class Huevo
    {
        public int Id { get; set; }
        public int Dias { get; set; }
        public string Estado { get; set; }
        public int EncargadoId { get; set; }
        public Encargado Encargado { get; set; }
    }
}
