using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace slothlandapi.Models
{
    public class TarifaTourModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("CodigoCliente")]
        public long CodigoCliente { get; set; }
        [JsonPropertyName("NombreCliente")]
        public string NombreCliente{ get; set; }

        [JsonPropertyName("IdTour")]
        public int IdTour { get; set; }

        [JsonPropertyName("NombreTour")]
        public string NombreTour { get; set; }

        [JsonPropertyName("IdZona")]
        public int IdZona { get; set; }

        [JsonPropertyName("NombreZona")]
        public string NombreZona { get; set; }    
        
        [JsonPropertyName("TarifaAdulto")]
        public decimal TarifaAdulto { get; set; }

        [JsonPropertyName("TarifaNino")]
        public decimal TarifaNino { get; set; }

        [JsonPropertyName("Observaciones")]
        public string Observaciones { get; set; }

        [JsonPropertyName("Inhabilitado")]
        public bool? Inhabilitado { get; set; }
    }


}
