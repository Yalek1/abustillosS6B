using abustillosS6B.Models;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace abustillosS6B.Views;

public partial class vActualizarEliminar : ContentPage
{
    public vActualizarEliminar(Estudiante datos)
    {
        InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string url = "http://192.168.100.71/wsestudiantes/estudiante.php";
            HttpClient client = new HttpClient();

            // Crear el contenido de la solicitud en formato JSON
            var jsonContent = new StringContent(
                "{\"codigo\": \"" + txtCodigo.Text + "\", \"nombre\": \"" + txtNombre.Text + "\", \"apellido\": \"" + txtApellido.Text + "\", \"edad\": \"" + txtEdad.Text + "\"}",
                Encoding.UTF8,
                "application/json");

            // Enviar la solicitud PUT
            var response = await client.PutAsync(url, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Actualización", "Estudiante actualizado correctamente", "OK");
                Navigation.PushAsync(new vEstudiante());
            }
            else
            {
                DisplayAlert("ERROR", "Error al actualizar el estudiante. Código de estado: " + response.StatusCode, "Cerrar");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "Cerrar");
        }
    }

    private void BtnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string url = "http://192.168.100.71/wsestudiantes/estudiante.php";
            WebClient client = new WebClient();
            var parametros = new NameValueCollection();

            // Añadir el código y el _method para emular DELETE
            parametros.Add("codigo", txtCodigo.Text);
            parametros.Add("_method", "DELETE"); // Indicamos que es un método DELETE

            // Usamos POST para emular DELETE
            client.UploadValues(url, "POST", parametros);

            DisplayAlert("Eliminación", "Estudiante eliminado correctamente", "OK");
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "Cerrar");
        }
    }
}