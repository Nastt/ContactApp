using System;

namespace ContactApp
{
    /// <summary>
    /// Класс номера телефона
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Номер телефона
        /// </summary>
        private long _number;

        /// <summary>
        /// Свойство номера телефона
        /// Поле должно быть числовым и содержать ровно 11 цифр. Первая цифра должна быть ‘7’.
        /// </summary>
        public long Number
        {
            get
            {
                return _number;
            }
            set
            {
                if ((value.ToString().Length == 11) && (value.ToString()[0] == '7'))
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException(message: "Phone number should begin with 7 and contain 11 digits");
                }
            }
        }
    }
}
