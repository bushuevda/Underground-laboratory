using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Items
{
    /// <summary>
    /// ����������� �����, �������������� ����� ���������.
    /// </summary>
    public static class Inventory
    {
        /// <summary>
        /// ������, �������� ���������� � ��������� ���������.
        /// </summary>
        public static List<Item> inventoryContainer = new List<Item>();


        /// <summary>
        /// ������������� �������, ����������� � ����� ������.
        /// </summary>
        public static Item equipItem = null; 


        /// <summary>
        /// ������������ ������ ���������.
        /// </summary>
        public const int sizeInventory = 20;


        /// <summary>
        /// ������� ���������� �������� � ���������.
        /// </summary>
        /// <param name="item">
        /// �������, ����������� � ���������.
        /// </param>
        public static void AddToInventory(Item item)
        {
            if (inventoryContainer.Count < sizeInventory)
                inventoryContainer.Add(item);
        }


        /// <summary>
        /// /������� ���������� �������� �� ���������.
        /// </summary>
        /// <param name="item">
        /// �������, ����������� �� ���������.
        /// </param>
        public static void RemoveFromInventory(Item item)
        {
            if (inventoryContainer.Contains(item))
                inventoryContainer.Remove(item);
        }


        /// <summary>
        /// ������� ������ �������� � ����.
        /// </summary>
        /// <param name="item">
        /// ����������� �������.
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
        /// ������� �������� �������� �� ���.
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

