using TestApplication.Services;
using TestApplication.ViewModels;
using Xamarin.Forms;

namespace TestApplication
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel(DependencyService.Resolve<ITextEditorService>());
        }
    }
}