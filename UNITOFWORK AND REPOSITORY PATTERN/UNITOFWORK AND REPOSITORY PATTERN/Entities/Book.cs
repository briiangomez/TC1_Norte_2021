using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNITOFWORK_AND_REPOSITORY_PATTERN.Entities
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public int Author_ID { get; set; }

        [ForeignKey("Author_ID")]
        public virtual Author Author { get; set; }

        public EstadoIntermedio Estado { get; set; }


    }

    public enum EstadoIntermedio
    {
        SinCambios,
        Agregado,
        Modificado,
        Eliminado
    }
}
