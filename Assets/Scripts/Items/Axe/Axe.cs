using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class Axe : MonoBehaviour, Item
    {

        /// <summary>
        /// Аниматор предмета.
        /// </summary>
        Animator animator;


        /// <summary>
        /// Начальный масштаб предмета.
        /// </summary>
        Vector3 beginScale;


        void Start()
        {
            animator = GetComponent<Animator>();
            animator.enabled = false;
        }

        public void Use()
        {
            StartCoroutine(AnimationUse());
        }

        /// <summary>
        /// Функция воспроизведения анимации предмета.
        /// </summary>
        IEnumerator AnimationUse()
        {
            animator.SetBool("attack", true);
            yield return new WaitForSeconds(.1f);
            animator.SetBool("attack", false);
            yield return null;
        }

        public void Put()
        {
            if (Inventory.equipItem == null)
            {
                animator.enabled = true;
                beginScale = transform.localScale;
                GetComponent<Rigidbody>().detectCollisions = false;
                GetComponent<Rigidbody>().useGravity = false;
                Inventory.AddToInventory(this);
                Inventory.EquipItem(this);
                GameObject player = StaticPlayer.playerController.gameObject;
                Camera camera = player.GetComponentInChildren<Camera>();
                HandPlayer hand = camera.GetComponentInChildren<HandPlayer>();

                transform.SetParent(hand.transform);
                transform.localPosition = new Vector3(0, 0, 0);
                transform.localEulerAngles = new Vector3(-25, -25, 60);
                //Debug.Log(Inventory.inventoryContainer.Count);
            }


        }

        public void Toss()
        {
            animator.enabled = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().detectCollisions = true;
            transform.parent = null;
            transform.localScale = beginScale;
            transform.SetParent(GameObject.Find("Items").transform);
        }

    }
}

