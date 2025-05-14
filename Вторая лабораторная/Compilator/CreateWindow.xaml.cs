using System.Windows;
using System;
using System.IO;
using Path = System.IO.Path;

namespace Compilator
{
    public partial class CreateWindow : Window
    {
        public string FileName { get; set; }
        public CreateWindow()
        {
            InitializeComponent();
        }

        private void MegaButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = TBFileName.Text.Trim();

            // Проверка имени файла (допустимые символы, длина, и т.д.)
            if (IsValidFileName(fileName))
            {
                FileName = fileName; // Сохраняем имя файла
                DialogResult = true;  // Закрываем окно с результатом "OK"
                Close();
            }
            else
            {
                MessageBox.Show("Недопустимое имя файла.");
            }
        }

        private bool IsValidFileName(string fileName)
        {
            // Пример: проверяем, что имя файла не пустое и не содержит недопустимых символов
            if (string.IsNullOrEmpty(fileName)) return false;
            if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0) return false;
            return true;
        }


    }
}
