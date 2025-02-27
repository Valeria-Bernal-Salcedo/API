using Newtonsoft.Json;
using System.Text;
using System.Windows.Forms.Design.Behavior;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PRUEBA_3
{
    public partial class Form1 : Form
    {
        private readonly HttpClient cliente = new HttpClient();
        private readonly string apiKey = "0DWvw3JVNg6gN2i06aXVVCDYO99DbORuu3xg0Wt2";
        private readonly string accessToken = "KEo6-5r2s6KbWtz3CzgxGLGs5BnNFZqTQ__o7dJr1zY";
        private readonly string instanceUrl = "https://mastodon.social/api/v1/statuses"; 

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await LoadCaracter();
        }

        private async Task LoadCaracter()
        {
            try
            {
                string startDate = "2024-01-03";
                string endDate = "2024-01-05";

                string endpoint = $"https://api.nasa.gov/planetary/apod?api_key={apiKey}&start_date={startDate}&end_date={endDate}";

                HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                respuesta.EnsureSuccessStatusCode();

                string respuestaBody = await respuesta.Content.ReadAsStringAsync();
                MessageBox.Show(respuestaBody); 

                List<API> resultados = JsonConvert.DeserializeObject<List<API>>(respuestaBody);

                if (resultados != null && resultados.Count > 0)
                {
                    foreach (var item in resultados)
                    {
                        MessageBox.Show($"Título: {item.Title}\nFecha: {item.Date}\nExplicación: {item.Explanation}");
                    }
                }
                else
                {
                    MessageBox.Show("No se recibieron datos de la API.");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de HttpRequest: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error genérico: {ex.Message}");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await post();
        }

        private async Task post()
        {
            try
            {
                string url = instanceUrl;

                var tootData = new
                {
                    status = "¡Hola, mundo! Esta es una prueba de un post",
                    "Hola como estan ",
                };

                string json = JsonConvert.SerializeObject(tootData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",accessToken);

                HttpResponseMessage respuesta = await cliente.PostAsync(url, content);
                respuesta.EnsureSuccessStatusCode();


                string respuestaBody = await respuesta.Content.ReadAsStringAsync();
                MessageBox.Show($"Prueba exitosa.\nRespuesta: {respuestaBody}");
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de HttpRequest: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}

