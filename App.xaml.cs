using abustillosS6B.Views;

namespace abustillosS6B
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new vEstudiante());
        }
    }
}
