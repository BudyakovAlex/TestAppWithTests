using System;
using System.Linq;

namespace TestApplication.Services
{
    public class TextEditorService : ITextEditorService
    {
        public string? SwapStartAndEndCharacters(string? text)
        {
            if (string.IsNullOrEmpty(text) || text.Length == 1)
            {
                return text;
            }

            return $"{text.Last()}{text.Substring(1, Math.Max(0, text.Length - 2))}{text.First()}";
        }
    }
}
