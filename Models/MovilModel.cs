using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace slothlandapi.Models
{
    public class MovilModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("TipoUnidad")]
        public string TipoUnidad { get; set; }

        [JsonPropertyName("Capacidad")]
        public int Capacidad { get; set; }

        [JsonPropertyName("Ano")]
        public int Ano { get; set; }

        [JsonPropertyName("Placa")]
        public string Placa { get; set; }

        [JsonPropertyName("Marca")]
        public string Marca { get; set; }

        [JsonPropertyName("Observaciones")]
        public string Observaciones { get; set; }


        [JsonPropertyName("Inhabilitado")]
        public bool? Inhabilitado { get; set; }
    }


}
