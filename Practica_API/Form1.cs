using Newtonsoft.Json;

namespace Practica_API
{
    public partial class Form1 : Form
    {
        private readonly HttpClient cliente = new HttpClient();
        private readonly string apiKey = "0DWvw3JVNg6gN2i06aXVVCDYO99DbORuu3xg0Wt2";

        public Form1()
        {
            InitializeComponent();
        }


        private async void button1_Click_1(object sender, EventArgs e)
        {
            await LoadCaracter();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await loadImages();
        }

        private async Task LoadCaracter()
        {
            try
            {
                // Obtener las fechas desde los TextBox
                string startDate = txtStartDate.Text.Trim();
                string endDate = txtEndDate.Text.Trim();

                // Validar formato de fechas
                if (!ValidarFormatoFecha(startDate) || !ValidarFormatoFecha(endDate))
                {
                    MessageBox.Show("Las fechas deben estar en formato YYYY-MM-DD.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Convertir fechas a tipo DateTime para validaciones adicionales
                DateTime fechaInicio = DateTime.Parse(startDate);
                DateTime fechaFin = DateTime.Parse(endDate);

                // Validar que la fecha de inicio no sea mayor que la fecha de fin
                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string endpoint = $"https://api.nasa.gov/planetary/apod?api_key={apiKey}&start_date={startDate}&end_date={endDate}";

                HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                respuesta.EnsureSuccessStatusCode();

                string respuestaBody = await respuesta.Content.ReadAsStringAsync();
                MessageBox.Show(respuestaBody); // 🔹 Verifica el JSON devuelto


                List<API> resultados = JsonConvert.DeserializeObject<List<API>>(respuestaBody);

                if (resultados != null && resultados.Count > 0)
                {
                    foreach (var item in resultados)
                    {
                        MessageBox.Show($"Título: {item.Title}\nFecha: {item.Date}\nExplicación: {item.Explanation}");
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
                MessageBox.Show($"Error genérico: {ex.Message}");
            }
        }

        // Método para validar el formato de la fecha (YYYY-MM-DD)
        private bool ValidarFormatoFecha(string fecha)
        {
            DateTime fechaValida;
            return DateTime.TryParseExact(fecha, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fechaValida);
        }


        private async Task loadImages()
        {
            try
            {
                string fecha = txtFecha.Text.Trim();
                if (!ValidarFormatoFecha(fecha))
                {
                    MessageBox.Show("Las fechas deben estar en formato YYYY-MM-DD.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fechaSeleccionada = DateTime.Parse(fecha);

                // 🔹 Validar que la fecha no sea futura
                if (fechaSeleccionada > DateTime.Today)
                {
                    MessageBox.Show("No puedes elegir una fecha futura.");
                    return;
                }

                string endpoint = $"https://api.nasa.gov/planetary/apod?api_key={apiKey}&date={fecha}";

                HttpResponseMessage respuesta = await cliente.GetAsync(endpoint);
                respuesta.EnsureSuccessStatusCode();

                string respuestaBody = await respuesta.Content.ReadAsStringAsync();
                API resultado = JsonConvert.DeserializeObject<API>(respuestaBody);

                if (resultado != null)
                {
                    MessageBox.Show($"[IMAGEN DEL DÍA] Título: {resultado.Title}\nFecha: {resultado.Date}\nExplicación: {resultado.Explanation}");

                    if (!string.IsNullOrEmpty(resultado.Url))
                    {
                        if (resultado.MediaType == "image")
                        {
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen al tamaño del PictureBox
                            pictureBox1.Load(resultado.Url); // Carga la imagen en el PictureBox
                        }
                        else if (resultado.MediaType == "video")
                        {
                            MessageBox.Show("La NASA envió un video en lugar de una imagen. Abriendo en el navegador...");
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = resultado.Url,
                                UseShellExecute = true
                            });
                        }
                        else
                        {
                            MessageBox.Show("El formato de la media recibida no es compatible.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se recibió una URL válida.");
                    }
                }
                else
                {
                    MessageBox.Show("No se recibió la imagen del día.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
            }
        }
    }

}
