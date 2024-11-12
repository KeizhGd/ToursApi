using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace slothlandapi.Models
{
    public class ProveedoresModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("CodigoProv")]
        public int CodigoProv { get; set; }

        [Required]
        [JsonPropertyName("Cedula")]
        public string Cedula { get; set; }

        [Required]
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [JsonPropertyName("Contacto")]
        public string Contacto { get; set; }

        [Required]
        [JsonPropertyName("Telefono_Cont")]
        public string Telefono_Cont { get; set; }

        [Required]
        [JsonPropertyName("Observaciones")]
        public string Observaciones { get; set; }

        [Required]
        [JsonPropertyName("Telefono1")]
        public string Telefono1 { get; set; }

        [Required]
        [JsonPropertyName("Telefono2")]
        public string Telefono2 { get; set; }

        [Required]
        [JsonPropertyName("Fax1")]
        public string Fax1 { get; set; }

        [Required]
        [JsonPropertyName("Fax2")]
        public string Fax2 { get; set; }

        [Required]
        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("Direccion")]
        public string Direccion { get; set; }

        [Required]
        [JsonPropertyName("MontoCredito")]
        public double MontoCredito { get; set; }

        [Required]
        [JsonPropertyName("Plazo")]
        public int Plazo { get; set; }

        [Required]
        [JsonPropertyName("CostoTotal")]
        public bool CostoTotal { get; set; }

        [Required]
        [JsonPropertyName("ImpIncluido")]
        public bool ImpIncluido { get; set; }

        [Required]
        [JsonPropertyName("PedidosMes")]
        public int PedidosMes { get; set; }

        [Required]
        [JsonPropertyName("Utilidad_Inventario")]
        public double Utilidad_Inventario { get; set; }

        [Required]
        [JsonPropertyName("Utilidad_Fija")]
        public bool Utilidad_Fija { get; set; }

        [JsonPropertyName("CuentaContable")]
        public string CuentaContable { get; set; }

        [JsonPropertyName("DescripcionCuentaContable")]
        public string DescripcionCuentaContable { get; set; }

        [Required]
        [JsonPropertyName("Comisionista")]
        public bool Comisionista { get; set; }

        [Required]
        [JsonPropertyName("Mensajeria")]
        public bool Mensajeria { get; set; }

        [Required]
        [JsonPropertyName("CorreoPedidos")]
        public string CorreoPedidos { get; set; }

        [Required]
        [JsonPropertyName("DiasVisita")]
        public string DiasVisita { get; set; }
    }
}
