using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MvcApiClient.Models
{
    public class Hospital
    {
        [JsonProperty("idHospital")]
        public int IdHospital { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("direccion")]
        public string Direccion { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }

        [JsonProperty("camas")]
        public int Camas { get; set; }
    }
}
