using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс контакта
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Фамилия контакта
        /// </summary>
        private string _surname;

        /// <summary>
        /// Имя контакта
        /// </summary>
        private string _name;

        /// <summary>
        /// День рождения контакта
        /// </summary>
        private DateTime _birthday;

        /// <summary>
        /// e-mail контакта
        /// </summary>
        private string _email;

        /// <summary>
        /// ID страницы Вконтакте.
        /// </summary>
        private string _idVk;

        /// <summary>
        /// Номер телефона контакта
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// Свойство фамилии
        /// Если длина фамилии не превышает 50 символов, первая буква преобразовывается к верхнему регистру.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (value.Length < 50)
                {
                    _surname = char.ToUpper(value[0]).ToString() + value.Substring(1);
                }
                else
                {
                    throw new ArgumentException("Фамилия не должна превышать 50 символов");
                }
            }
        }

        /// <summary>
        /// Свойство имени
        /// Если длина имени не превышает 50 символов, первая буква преобразовывается к верхнему регистру.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length < 50)
                {
                    _name = char.ToUpper(value[0]).ToString() + value.Substring(1);
                }
                else
                {
                    throw new ArgumentException("Имя не должно превышать 50 символов");
                }
            }
        }

        /// <summary>
        /// Свойство E-mail
        /// E-mail не должен превышать 50 символов.
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value.Length < 50)
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Е-mail не должен превышать 50 символов");
                }
            }
        }

        /// <summary>
        /// Свойство ID Вконтакте
        /// ID Вконтакте не должно превышать 15 символов и должно начинаться с символа _
        /// </summary>
        public string IdVk
        {
            get
            {
                return _idVk;
            }
            set
            {
                if ((value.Length < 15) && (value[0] == '_'))
                {
                    _idVk = value;
                }
                else
                {
                    throw new ArgumentException("ID_vk не должен превышать 15 символов и начинаться с символа _");
                }
            }
        }

        /// <summary>
        /// Свойство даты рождения
        /// Дата рождения не может быть менее 1900 года и меньше текущей даты.
        /// </summary>
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                DateTime minData = new DateTime(1900, 1, 1);
                if ((value < DateTime.Now) && (value > minData))
                {
                    _birthday = value;
                }
                else
                {
                    throw new ArgumentException("Дата рождения не может быть больше текущей даты или быть менее 1900 года");
                }
            }
        }

        /// <summary>
        /// Метод клонирования объекта данного класса.
        /// </summary>
        /// <returns>Возвращает копию данного класса.</returns>
        public object Clone()
        {
            var phoneNumber = new PhoneNumber { Number = this.PhoneNumber.Number };
            return new Contact
            {
                Surname = this.Surname,
                Name = this.Name,
                Birthday = this.Birthday,
                Email = this.Email,
                IdVk = this.IdVk,
                PhoneNumber = phoneNumber
            };
        }
    }
}