using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace slothlandapi.Models
{
    public class ChoferModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("TipoLicencia")]
        public string TipoLicencia { get; set; }

        [JsonPropertyName("VencimientoLicencia")]
        public DateTime VencimientoLicencia { get; set; }

        [JsonPropertyName("Celular")]
        public string Celular { get; set; }

        [JsonPropertyName("Correo")]
        public string Correo { get; set; }

        [JsonPropertyName("Direccion")]
        public string Direccion { get; set; }

        [JsonPropertyName("Observaciones")]
        public string Observaciones { get; set; }


        [JsonPropertyName("Inhabilitado")]
        public bool? Inhabilitado { get; set; }



    }


}
