using NUnit.Framework;
using TestApplication.Services;

namespace TestApplication.Tests
{
    [TestFixture]
    public class TextEditorServiceTests
    {
        private ITextEditorService textEditorService;

        [SetUp]
        public void Init()
        {
            textEditorService = new TextEditorService();
        }

        [Test]
        [TestCase("UA", "AU")]
        [TestCase("sometext", "tometexs")]
        public void SwapStartAndEndCharacters_NotEmptyText_ShouldBeSwapedFirstAndLastSymbols(string initialText, string expectedResult)
        {
            // act
            var result = textEditorService.SwapStartAndEndCharacters(initialText);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void SwapStartAndEndCharacters_OneCharInText_ShouldBeSameAsInitialText()
        {
            // arrange
            var initialText = "s";
            var expectedResult = "s";

            // act
            var result = textEditorService.SwapStartAndEndCharacters(initialText);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void SwapStartAndEndCharacters_EmptyText_ShouldBeEmptyText()
        {
            // arrange
            var initialText = string.Empty;
            var expectedResult = string.Empty;

            // act
            var result = textEditorService.SwapStartAndEndCharacters(initialText);

            // assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
