using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RNP24_5_3.AppData
{
    /// <summary>
    /// Класс для работы с CSV файлами.
    /// </summary>
    internal class CSVHelper
    {
        /// <summary>
        /// Путь к CSV файлу.
        /// </summary>
        private static string _filePath = @"D:\Программирование\ДО\RNP24_5_3\AppData\data.csv";

        /// <summary>
        /// Считывает данные из CSV файла.
        /// </summary>
        /// <param name="fileName">Полный путь к файлу.</param>
        /// <returns>Данные из CSV файла.</returns>
        public static IEnumerable<User> Read()
        {
            string[] lines = File.ReadAllLines(_filePath);

            return lines.Select(line =>
            {
                string[] data = line.Split(';');

                return new User
                {
                    Name = data[0],
                    Login = data[1],
                    Password = data[2]
                };
            });
        }

        /// <summary>
        /// Обновляет данные в CSV файле.
        /// </summary>
        /// <param name="list">Список в который загружается CSV файл.</param>
        public static void Update(ListView list)
        {
            StreamWriter streamWriter = new StreamWriter(_filePath);

            foreach (User user in list.Items)
            {
                streamWriter.WriteLine(string.Format($"{user.Name};{user.Login};{user.Password}"));
                streamWriter.Flush();
            }
        }
    }
}
