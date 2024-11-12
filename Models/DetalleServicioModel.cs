using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace slothlandapi.Models
{
    public class DetalleServicioModel
    {
        [Key]
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("IdTour")]
        public int IdTour { get; set; }

        [JsonPropertyName("ServicioId")]
        public int ServicioId { get; set; }

        [JsonPropertyName("Tarifa")]
        public decimal Tarifa { get; set; }

        [JsonPropertyName("Observaciones")]
        public string Observaciones { get; set; }
    }


}
