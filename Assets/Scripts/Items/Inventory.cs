using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Items
{
    /// <summary>
    /// Статический класс, представляющий собой инвентарь.
    /// </summary>
    public static class Inventory
    {
        /// <summary>
        /// Список, хранящий информацию о предметах инвентаря.
        /// </summary>
        public static List<Item> inventoryContainer = new List<Item>();


        /// <summary>
        /// Экипированный предмет, находящийся в руках игрока.
        /// </summary>
        public static Item equipItem = null; 


        /// <summary>
        /// Максимальный размер инвентаря.
        /// </summary>
        public const int sizeInventory = 20;


        /// <summary>
        /// Функция добавления предмета в инвертарь.
        /// </summary>
        /// <param name="item">
        /// Предмет, добавляемый в инвентарь.
        /// </param>
        public static void AddToInventory(Item item)
        {
            if (inventoryContainer.Count < sizeInventory)
                inventoryContainer.Add(item);
        }


        /// <summary>
        /// /Функция извлечения предмета из инвертаря.
        /// </summary>
        /// <param name="item">
        /// Предмет, извлекаемый из инвентаря.
        /// </param>
        public static void RemoveFromInventory(Item item)
        {
            if (inventoryContainer.Contains(item))
                inventoryContainer.Remove(item);
        }


        /// <summary>
        /// Функция взятия предмета в руки.
        /// </summary>
        /// <param name="item">
        /// Экипируемый предмет.
        /// </param>
        public static void EquipItem(Item item)
        {
            if (inventoryContainer.Count < sizeInventory && inventoryContainer.Contains(item))
            {
                inventoryContainer.Add(equipItem);
                equipItem = item;
                inventoryContainer.Remove(equipItem);
            }
        }


        /// <summary>
        /// Функция бросания предмета из рук.
        /// </summary>
        public static void RemoveEquip()
        {
            if (equipItem != null)
            {
                equipItem.Toss();
                equipItem = null;
            }
        }
    }
}

