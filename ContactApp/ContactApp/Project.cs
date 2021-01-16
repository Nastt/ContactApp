using System.Collections.Generic;
using System.Linq;

namespace ContactApp
{
    /// <summary>
    /// Класс логики проекта
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Динамическая коллекция контактов проекта
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Индекс текущей заметки.
        /// </summary>
        public int SelectedIndex { get; set; }

        /// <summary>
        /// Сортировка списка заметок по дате изменения.
        /// </summary>
        public List<Contact> SortContacts(List<Contact> contact)
        {
            return contact.OrderByDescending(item => item.Surname).ToList();
        }
    }
}


