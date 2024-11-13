using System.Net;

namespace abustillosS6B.Views;

public partial class vInsertar : ContentPage
{
	public vInsertar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{
			string url = "http://192.168.100.71/wsestudiantes/estudiante.php";
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

			cliente.UploadValues(url, "POST", parametros);
			Navigation.PushAsync(new vEstudiante());
        }
		catch (Exception ex)
		{
			DisplayAlert("ERROR", ex.Message, "Cerrar");
		}
    }
}