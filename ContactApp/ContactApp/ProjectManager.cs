using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс менеджера проекта
    /// </summary>
    public static class ProjectManager
    {

        /// <summary>
        /// Путь до папки сохранения "ContactsApp".
        /// </summary>

        public static string PathToFolder = "C:\\Users\\mapki\\OneDrive\\Рабочий стол\\Contact";
       // public static string PathToFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Contact/";
        /// <summary>
        /// Полный путь до файла "ContactsApp.notes".
        /// </summary>

        private static string PathToFile = PathToFolder+"/ContactsApp.notes";

        /// <summary>
        /// Метод сохранения данных путем сериализации.
        /// </summary>
        /// <param name="project">Данные для сериализации.</param>
        /// <param name="filepath">Путь до файла</param>
        public static void SaveToFile(Project project, string filepath)
        {
            Directory.CreateDirectory(filepath);
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(PathToFile))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Метод загрузки данных путем десериализации.
        /// </summary>
        public static Project LoadFromFile(string filepath)
        {
            Project project;
            JsonSerializer serializer = new JsonSerializer();
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                using (JsonReader reader = new JsonTextReader(sr))
                    project = serializer.Deserialize<Project>(reader);
            }
            catch
            {
                return new Project();
            }
            return project;
        }
    }
}