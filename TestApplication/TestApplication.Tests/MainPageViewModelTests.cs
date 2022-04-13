using System.Linq;
using NUnit.Framework;
using TestApplication.Services;
using TestApplication.ViewModels;

namespace TestApplication.Tests
{
    [TestFixture]
    public class MainPageViewModelTests
    {
        [Test]
        [TestCase("SomeText")]
        public void SwapCharactersCommand_TextNotEmpty_IsFirstCharMovedToEnd(string text)
        {
            // arrange
            var viewModel = new MainPageViewModel(new TextEditorService())
            {
                Text = text
            };
            var firtsCharacter = text.FirstOrDefault();

            // act
            viewModel.SwapCharactersCommand.Execute(null);

            // assert
            Assert.AreEqual(firtsCharacter, viewModel.Text.LastOrDefault());
        }

        [Test]
        [TestCase("SomeText")]
        public void SwapCharactersCommand_TextNotEmpty_IsLastCharMovedToStart(string text)
        {
            // arrange
            var viewModel = new MainPageViewModel(new TextEditorService())
            {
                Text = text
            };
            var lastCharacter = text.LastOrDefault();

            // act
            viewModel.SwapCharactersCommand.Execute(null);

            // assert
            Assert.AreEqual(lastCharacter, viewModel.Text.FirstOrDefault());
        }

        [Test]
        [TestCase("")]
        public void SwapCharactersCommand_TextIsEmpty_IsTextSameAsInitial(string text)
        {
            // arrange
            var viewModel = new MainPageViewModel(new TextEditorService())
            {
                Text = text
            };

            // act
            viewModel.SwapCharactersCommand.Execute(null);

            // assert
            Assert.AreEqual(text, viewModel.Text);
        }
    }
}