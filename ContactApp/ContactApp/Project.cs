using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
    }
}
