using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriger : MonoBehaviour, Furniture
{

    public void Operate()
    {
        GameObject deviceDoor = transform.parent.gameObject;
        deviceDoor.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);

    }
}
