using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace slothlandapi.Models
{
    public class ServicioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public int? Id { get; set; } // No nullable, ya que es una columna IDENTITY y no debe ser nula

        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; } // Se mantiene como string para varchar(100)

        [JsonPropertyName("Transporte")]
        public bool? Transporte { get; set; } // Nullable para bit, ya que la columna puede ser nula

        [JsonPropertyName("Capacidad")]
        public int Capacidad { get; set; } // Se adapta al tipo nchar(10), como string

        [JsonPropertyName("Observaciones")]
        public string Observaciones { get; set; } // Se mantiene como string para varchar(max)

        [JsonPropertyName("Inhabilitado")]
        public bool? Inhabilitado { get; set; } // Nullable para bit, ya que la columna puede ser nula
    }
}
