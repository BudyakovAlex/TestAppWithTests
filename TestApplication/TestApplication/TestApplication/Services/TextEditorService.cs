﻿namespace TestApplication.Services
{
    public class TextEditorService : ITextEditorService
    {
        public string? SwapStartAndEndCharacters(string? text)
        {
            if (string.IsNullOrEmpty(text) || text!.Length == 0)
            {
                return text;
            }

            return $"{text[text.Length - 1]}{text.Substring(1, text.Length - 2)}{text[0]}";
        }
    }
}