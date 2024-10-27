using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Items
{
    /// <summary>
    /// �����, �������������� ����� �������.
    /// </summary>
    public class Hammer : MonoBehaviour, Item
    {
        /// <summary>
        /// �������� ��������.
        /// </summary>
        Animator animator;


        /// <summary>
        /// ��������� ������� ��������.
        /// </summary>
        Vector3 beginScale; 


        void Start()
        {
            animator = GetComponent<Animator>();
            animator.enabled = false;
            beginScale = transform.localScale;
        }


        public void Use()
        {
            StartCoroutine(AnimationUse());
        }


        /// <summary>
        /// ������� ��������������� �������� ��������.
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
            ItemsController.PutWithAnimator(animator, transform.gameObject, beginScale);
        }

        public void Toss()
        {
            ItemsController.TossWithAnimator(animator, transform.gameObject, beginScale);
        }


    }
}

