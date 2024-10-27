using UnityEngine;

namespace Items
{
    /// <summary>
    /// ����������� �����, �������������� ��������� ��������� � ���������� �� ���.
    /// </summary>
    public static class ItemsController
    {
        /// <summary>
        /// �������� ������� �������, ��������� ��������.
        /// </summary>
        public const string space = "Items";


        /// <summary>
        /// ������� ������������ �������� � ���������� �� ���.
        /// </summary>
        /// <param name="animator">
        /// �������� ��������.
        /// </param>
        /// <param name="gameObject">
        /// �������, ������������� �� ����.
        /// </param>
        /// <param name="beginScale">
        /// ��������� ������� ��������.
        /// </param>
        public static void TossWithAnimator(Animator animator, GameObject gameObject, Vector3 beginScale)
        {
            animator.enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().detectCollisions = true;
            gameObject.transform.parent = null;
            gameObject.transform.localScale = beginScale;
            gameObject.transform.SetParent(GameObject.Find("Items").transform);
        }


        /// <summary>
        /// ������� ������ � ���� �������� � ����������.
        /// </summary>
        /// <param name="animator">
        /// �������� ��������
        /// </param>
        /// <param name="gameObject">
        /// �������, ������������� �� ����.
        /// </param>
        /// <param name="beginScale">
        /// ��������� ������� ��������.
        /// </param>
        public static void PutWithAnimator(Animator animator, GameObject gameObject, Vector3 beginScale)
        {
            if (Inventory.equipItem == null)
            {
                animator.enabled = true;
                gameObject.GetComponent<Rigidbody>().detectCollisions = false;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                Inventory.AddToInventory(gameObject.GetComponent<Item>());
                Inventory.EquipItem(gameObject.GetComponent<Item>());
                GameObject player = StaticPlayer.playerController.gameObject;
                Camera camera = player.GetComponentInChildren<Camera>();
                HandPlayer hand = camera.GetComponentInChildren<HandPlayer>();

                gameObject.transform.SetParent(hand.transform);
                gameObject.transform.localPosition = new Vector3(0, 0, 0);
                gameObject.transform.localEulerAngles = new Vector3(-25, -25, 60);
                gameObject.transform.localScale = beginScale;

            }
        }


        /// <summary>
        /// ������� ������ � ���� �������� ��� ��������
        /// </summary>
        /// <param name="gameObject">
        /// �������, ������� ������� � ����
        /// </param>
        /// <param name="beginScale">
        /// ��������� ������� ��������
        /// </param>
        /// <returns>��������� �������� � �����.</returns>
        public static bool Put(GameObject gameObject, Vector3 beginScale)
        {
            if (Inventory.equipItem == null)
            {

                gameObject.GetComponent<Rigidbody>().detectCollisions = false;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                Inventory.AddToInventory(gameObject.GetComponent<Item>());
                Inventory.EquipItem(gameObject.GetComponent<Item>());
                GameObject player = StaticPlayer.playerController.gameObject;
                Camera camera = player.GetComponentInChildren<Camera>();
                HandPlayer hand = camera.GetComponentInChildren<HandPlayer>();

                gameObject.transform.SetParent(hand.transform);
                gameObject.transform.localPosition = new Vector3(0, 0, 0);
                gameObject.transform.localEulerAngles = new Vector3(-25, -25, 60);
                gameObject.transform.localScale = beginScale;

                //Debug.Log(Inventory.inventoryContainer.Count);
                return true;
            }
            return false;
        }


        /// <summary>
        /// ������� ������������ �������� �������� �� ���
        /// </summary>
        /// <param name="gameObject">
        /// �������, ������������� �� ����
        /// </param>
        /// <param name="beginScale">
        /// ��������� ������� ��������
        /// </param>
        /// <returns>��������� �������� � �����.</returns>
        public static bool Toss(GameObject gameObject, Vector3 beginScale)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().detectCollisions = true;
            gameObject.transform.parent = null;
            gameObject.transform.localScale = beginScale;
            gameObject.transform.SetParent(GameObject.Find(space).transform);
            return false;
        }

    }
}