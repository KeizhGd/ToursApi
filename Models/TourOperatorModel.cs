using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace slothlandapi.Models
{
    public class TourOperatorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("IdCliente")]
        public long? IdCliente { get; set; }

        [JsonPropertyName("NombreCliente")]
        public string NombreCliente { get; set; }

        [JsonPropertyName("IdTour")]
        public int? IdTour { get; set; }

        [JsonPropertyName("NombreTour")]
        public string NombreTour { get; set; }

        [JsonPropertyName("IdZona")]
        public int? IdZona { get; set; }

        [JsonPropertyName("NombreZona")]
        public string NombreZona { get; set; }

        [JsonPropertyName("Adultos")]
        public float? Adultos { get; set; }

        [JsonPropertyName("Ninos")]
        public float? Ninos { get; set; }

        [JsonPropertyName("Documento")]
        public byte[] Documento { get; set; }

        [JsonPropertyName("IdMovil")]
        public int? IdMovil { get; set; }

        [JsonPropertyName("NombreMovil")]
        public string NombreMovil { get; set; }

        [JsonPropertyName("IdGuia1")]
        public int? IdGuia1 { get; set; }

        [JsonPropertyName("NombreGuia1")]
        public string NombreGuia1 { get; set; }

        [JsonPropertyName("IdGuia2")]
        public int? IdGuia2 { get; set; }

        [JsonPropertyName("NombreGuia2")]
        public string NombreGuia2 { get; set; }

        [JsonPropertyName("IdTarifa")]
        public int? IdTarifa { get; set; }

        [JsonPropertyName("NombreTarifa")]
        public string NombreTarifa { get; set; }

        [JsonPropertyName("GastosExtra")]
        public float? GastosExtra { get; set; }

        [JsonPropertyName("Ingreso")]
        public float? Ingreso { get; set; }

        [JsonPropertyName("TieneTransporte")]
        public bool? TieneTransporte { get; set; }

        [JsonPropertyName("MontoTransporte")]
        public float? MontoTransporte { get; set; }

        [JsonPropertyName("MontoParque")]
        public float? MontoParque { get; set; }

        [JsonPropertyName("MontoLaCabana")]
        public float? MontoLaCabana { get; set; }

        [JsonPropertyName("MontoGuia")]
        public float? MontoGuia { get; set; }

        [JsonPropertyName("GastosExtras")]
        public float? GastosExtras { get; set; }

        [JsonPropertyName("TotalGasto")]
        public float? TotalGasto { get; set; }

        [JsonPropertyName("UtilidadColones")]
        public float? UtilidadColones { get; set; }

        [JsonPropertyName("UtilidadDolares")]
        public float? UtilidadDolares { get; set; }
    }
}
