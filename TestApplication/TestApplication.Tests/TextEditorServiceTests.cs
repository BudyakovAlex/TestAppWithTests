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
        public void SwapStartAndEndCharacters_NotEmptyText_FirstAndLastSymbolsSwaped()
        {
            // arrange
            var initialText = "sometext";
            var expectedResult = "tometexs";

            // act
            var result = textEditorService.SwapStartAndEndCharacters(initialText);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void SwapStartAndEndCharacters_EmptyText_FirstAndLastSymbolsSwaped()
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
