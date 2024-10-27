using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class FlashLight : MonoBehaviour, Item
    {
        /// <summary>
        /// Состояние предмета в руках.
        /// </summary>
        bool takeItem;

        /// <summary>
        /// Начальный масштаб предмета.
        /// </summary>
        Vector3 beginScale;

        private void Start()
        {
            beginScale = transform.localScale;
            GetComponentInChildren<Light>().enabled = false;
        }

        public void Use()
        {
            if (GetComponentInChildren<Light>().enabled)
                GetComponentInChildren<Light>().enabled = false;
            else
                GetComponentInChildren<Light>().enabled = true;
        }

        public void Put()
        {
            takeItem = ItemsController.Put(transform.gameObject, beginScale);
        }

        void Update()
        {
            if (takeItem)
                transform.localPosition = new Vector3(0, 0, 0);
        }

        public void Toss()
        {
            takeItem = ItemsController.Toss(transform.gameObject, beginScale);
        }

    }
}

