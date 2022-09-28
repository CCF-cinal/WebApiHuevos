using System.ComponentModel.DataAnnotations;

namespace WebApiHuevos.Entidades
{
    public class Encargado
    {
        public int Id { get; set; }
        [StringLength(maximumLength:10,ErrorMessage ="El campo {0} solo puede tener hasta 10 caracteres")]
        public string Nombre { get; set; }
        public List<Huevo> huevos { get; set; }
    }
}
