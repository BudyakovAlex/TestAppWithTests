using System.Windows.Input;
using TestApplication.Services;
using TestApplication.ViewModels.Base;
using Xamarin.Forms;

namespace TestApplication.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly ITextEditorService textEditorService;

        public MainPageViewModel(ITextEditorService textEditorService)
        {
            this.textEditorService = textEditorService;

            SwapCharactersCommand = new Command(SwapCharacters);
        }

        public ICommand SwapCharactersCommand { get; }

        public string? Text
        {
            get => Get<string?>(() => null);
            set => Set(value);
        }

        private void SwapCharacters()
        {
            Text = textEditorService.SwapStartAndEndCharacters(Text);
        }
    }
}