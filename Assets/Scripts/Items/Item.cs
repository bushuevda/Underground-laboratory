
using UnityEngine;

namespace Items
{
    /// <summary>
    /// Интерфейс игровых предметов.
    /// </summary>
    public interface Item
    {
        /// <summary>
        /// Функция использовния предмета.
        /// </summary>
        void Use();

        /// <summary>
        /// Функция взятия предмета
        /// </summary>
        void Put();

        /// <summary>
        /// Функция выбрасывания предмета.
        /// </summary>
        void Toss();
    }
   
}


