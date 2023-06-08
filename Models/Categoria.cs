
using System.Text.Json.Serialization;

namespace webapi.Models
{
    // [Table("Categoria")]
    public class Categoria
    {
        // [Key]
        public Guid CategoriaId { get; set; }

        // [Required]
        // [MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;
        public int Peso { get; set; }
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<Tarea>? Tareas { get; set; }
    }
}