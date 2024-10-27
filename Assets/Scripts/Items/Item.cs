
using UnityEngine;

namespace Items
{
    /// <summary>
    /// ��������� ������� ���������.
    /// </summary>
    public interface Item
    {
        /// <summary>
        /// ������� ������������ ��������.
        /// </summary>
        void Use();

        /// <summary>
        /// ������� ������ ��������
        /// </summary>
        void Put();

        /// <summary>
        /// ������� ������������ ��������.
        /// </summary>
        void Toss();
    }
   
}


