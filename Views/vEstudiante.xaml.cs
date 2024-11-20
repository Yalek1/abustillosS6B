using abustillosS6B.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace abustillosS6B.Views;

public partial class vEstudiante : ContentPage
{
    private const string Url = "http://192.168.100.71/wsestudiantes/estudiante.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estud;
	public vEstudiante()
	{
		InitializeComponent();
		Listar();
	}

	public async void Listar()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Estudiante> listaEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud =new ObservableCollection<Estudiante>(listaEst);
		lvEstudiantes.ItemsSource = estud;
	}

    private void btnAbrir_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new vInsertar());
    }

    private void lvEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new vActualizarEliminar(objEstudiante));
    }
}