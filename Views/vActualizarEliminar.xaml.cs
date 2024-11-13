using abustillosS6B.Models;
using System.Collections.Specialized;
using System.Net;

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

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string url = "http://192.168.100.71/wsestudiantes/estudiante.php";
            WebClient client = new WebClient();
            var parametros = new NameValueCollection();

            parametros.Add("codigo", txtCodigo.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            parametros.Add("_method", "PUT"); // Indicamos que es un método PUT

            client.UploadValues(url, "POST", parametros); // Usamos POST
            DisplayAlert("Actualización", "Estudiante actualizado correctamente", "OK");
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "Cerrar");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string url = "http://192.168.100.71/wsestudiantes/estudiante.php";
            WebClient client = new WebClient();
            var parametros = new NameValueCollection();

            parametros.Add("codigo", txtCodigo.Text);
            parametros.Add("_method", "DELETE"); // Indicamos que es un método DELETE

            client.UploadValues(url, "POST", parametros); // Usamos POST
            DisplayAlert("Eliminación", "Estudiante eliminado correctamente", "OK");
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "Cerrar");
        }
    }
}