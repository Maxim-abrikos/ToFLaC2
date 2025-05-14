
using System.Text.RegularExpressions;

namespace Compiler
{
    internal class Token
    {
        public string Text { get; }
        public int StartIndex { get; }
        public int EndIndex { get; }
        public int Code { get; }
        public string Category { get; }

        public Token(string text, int startIndex, int endIndex)
        {
            Text = text;
            StartIndex = startIndex;
            EndIndex = endIndex;
            Code = GetTokenCode(text);
            Category = GetTokenCategory(text);
        }

        public string IndexInfo => StartIndex == EndIndex ? $"{StartIndex}" : $"с {StartIndex} по {EndIndex}";

        private int GetTokenCode(string text)
        {
            switch (text)
            {
                case "Complex": return 1;
                case "new": return 2;
                case " ": return 3;
                case "=": return 5;
                case "(": return 7;
                case ")": return 8;
                case ",": return 9;
                case ";": return 10;
                default:
                    if (Regex.IsMatch(text, @"^[a-zA-Z_][a-zA-Z0-9_]*$")) return 4; // Идентификатор
                    if (Regex.IsMatch(text, @"^[+-]?\d+(\.\d+)?([eE][+-]?\d+)?$")) return 6; // Число
                    return -1; // Неизвестная лексема
            }
        }

        private string GetTokenCategory(string text)
        {
            switch (text)
            {
                case "Complex": return "Ключевое слово";
                case "new": return "Ключевое слово";
                case " ": return "Разделитель";
                case "=": return "Оператор присваивания";
                case "(": return "Ограничитель";
                case ")": return "Ограничитель";
                case ",": return "Разделитель";
                case ";": return "Конец оператора";
                default:
                    if (Regex.IsMatch(text, @"^[a-zA-Z_][a-zA-Z0-9_]*$")) return "Идентификатор";
                    if (Regex.IsMatch(text, @"^[+-]?\d+(\.\d+)?([eE][+-]?\d+)?$")) return "Число";
                    return "Неизвестная лексема";
            }
        }
    }
}
