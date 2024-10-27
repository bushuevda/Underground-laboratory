using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    CharacterController _characterController;
    public float gravity = -9.8f;
    RaycastHit hit;

    void Awake()
    {
        StaticPlayer.playerController = this;
    }

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        float deltaZ = Input.GetAxis("Vertical") * speed;
        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector3 moving = new Vector3(deltaX, 0 , deltaZ);
        moving = Vector3.ClampMagnitude(moving, speed);
        moving.y = gravity;
        moving *= Time.deltaTime;

        //Пребразование координат из локальных в глобальные
        moving = transform.TransformDirection(moving);
        _characterController.Move(moving);


        if (Input.GetKeyDown(KeyCode.T))
        {
            Items.Inventory.RemoveEquip();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Items.Inventory.equipItem != null)
            {
                Items.Inventory.equipItem.Use();
            }
        }
    }
}
