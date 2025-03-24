using System.Net.Http.Headers;
using MvcApiClient.Models;
using Newtonsoft.Json;

namespace MvcApiClient.Services
{
    public class ServiceHospitales
    {
        private string ApiUrl;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceHospitales(IConfiguration configuration)
        {
            this.ApiUrl = configuration.GetValue<string>("ApiUrls:ApiHospitales");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/hospitales";

                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);

                //HACEMOS LA PETICION AL SERVICIO(GET) Y CAPTURAMOS LA RESPUESTA
                HttpResponseMessage response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    //DESCARGAMOS EL JSON COMO STRING
                    string json = await response.Content.ReadAsStringAsync();
                    //UTILIZAMOS NEWTON PARA RECUPERAR LOS DATOS SERIALIZADOS DE JSON A List<Hospital>
                    List<Hospital> data = JsonConvert.DeserializeObject<List<Hospital>>(json);
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Hospital> FindHospitalAsync(int idHospital)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/hospitales/" + idHospital;

                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);

                HttpResponseMessage response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    //SI LAS PROPIEDADES SE LLAMAN IGUAL A LA LECTURA DEL JSON, 
                    //NO ES NECESARIO MAPEAR CON LA DECORACION [JsonProperty] Y 
                    //NO LEEREMOS CON NewtonSoft.
                    Hospital data = await response.Content.ReadAsAsync<Hospital>();
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
