using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace slothlandapi.Models
{
    public class TarifaCostoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public long? Id { get; set; }

        [JsonPropertyName("IdProveedor")]
        public int? IdProveedor { get; set; }

        [JsonPropertyName("NombreProveedor")]
        [MaxLength(750)]
        public string NombreProveedor { get; set; }  
        
        [JsonPropertyName("Principal")]
        public bool Principal { get; set; }

        [JsonPropertyName("IdServicio")]
        public int? IdServicio { get; set; }

        [JsonPropertyName("NombreServicio")]
        [MaxLength(750)]
        public string NombreServicio { get; set; }

        [JsonPropertyName("PrecioCostoAdulto")]
        public double? PrecioCostoAdulto { get; set; }

        [JsonPropertyName("PrecioCostoNino")]
        public double? PrecioCostoNino { get; set; }
    }
}
