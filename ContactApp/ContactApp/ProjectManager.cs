using System;
using System.IO;
using Newtonsoft.Json;

namespace ContactApp
{
    /// <summary>
    /// Класс менеджера проекта
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Путь до папки сохранения "ContactsApp".
        /// </summary>
        public static string PathToFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Contact\\";

        /// <summary>
        /// Полный путь до файла "ContactsApp.notes".
        /// </summary>
        public static string PathToFile = PathToFolder + "\\ContactsApp.notes";
        /// <summary>
        /// Метод сохранения данных в файл.
        /// </summary>
        /// <param name="data">Данные для сериализации.</param>
        /// <param name="filePath">Путь до файла.</param>
        /// <param name="directoryPath">Путь до папки.</param>
        /// <summary>
        /// Метод сериализации данных проекта.
        /// </summary>
        public static void SaveToFile(Project project, string savefile, string folderpath)
        {
            if (!Directory.Exists(savefile))
            {
                Directory.CreateDirectory(savefile);
            }
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(folderpath))
            using (JsonTextWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Метод десериализации данных проекта.
        /// </summary>
        public static Project LoadFromFile(string path)
        {
            Project project;
            JsonSerializer serializer = new JsonSerializer();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    project = serializer.Deserialize<Project>(reader);
                }
            }
            catch
            {
                project = new Project();
            }
            return project;
        }
    }
}