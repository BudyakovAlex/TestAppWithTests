using Moq;
using NUnit.Framework;
using TestApplication.Services;
using TestApplication.ViewModels;

namespace TestApplication.Tests
{
    [TestFixture]
    public class MainPageViewModelTests
    {
        private MainPageViewModel mainPageViewModel;

        [SetUp]
        public void Init()
        {
            var mockTextEditorService = new Mock<ITextEditorService>();
            mockTextEditorService
                .Setup(editor => editor.SwapStartAndEndCharacters(It.IsAny<string>()))
                .Returns(It.IsAny<string>());

            mainPageViewModel = new MainPageViewModel(mockTextEditorService.Object);
        }

        [Test]
        public void SwapCharactersCommand_InitializedViewModel_ShouldBeNotNull()
        {
            // assert
            Assert.NotNull(mainPageViewModel.SwapCharactersCommand);
        }

        [Test]
        public void SwapCharactersCommand_InvokeCommand_ShouldNotThrowException()
        {
            // assert
            Assert.DoesNotThrow(() => mainPageViewModel.SwapCharactersCommand.Execute(null));
        }
    }
}