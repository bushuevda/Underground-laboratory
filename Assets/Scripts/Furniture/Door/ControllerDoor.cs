using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDoor : MonoBehaviour, Furniture
{
    bool enterDoor;
    enum door_mode
    {
        OPEN,
        CLOSE
    }

    door_mode modeDoor;
    void Start()
    {
        modeDoor = door_mode.CLOSE;
    }


    public void Operate()
    {
        StartCoroutine(ControllModeDoor());
    }

    IEnumerator ControllModeDoor()
    {

        if(!enterDoor)
        {
            enterDoor = true;

            Debug.Log(modeDoor);
            int angle = Mathf.FloorToInt(transform.eulerAngles.y);
            int angle_end = Mathf.FloorToInt(transform.eulerAngles.y) + 90;

            if (modeDoor == door_mode.CLOSE)
            {
                while (angle < angle_end)
                {
                    angle++;
                    Vector3 rotate = transform.eulerAngles;
                    rotate.y = angle;
                    transform.rotation = Quaternion.Euler(rotate);
                    yield return new WaitForSeconds(.01f);
                }
                modeDoor = door_mode.OPEN;

            }
            else if (modeDoor == door_mode.OPEN)
            {
                angle = Mathf.FloorToInt(transform.eulerAngles.y);
                angle_end = angle - 90;
                while (angle > angle_end)
                {
                    angle--;
                    Vector3 rotate = transform.eulerAngles;
                    rotate.y = angle;

                    transform.rotation = Quaternion.Euler(rotate);
                    yield return new WaitForSeconds(.01f);
                }
                modeDoor = door_mode.CLOSE;
            }
            else
                yield break;
            enterDoor = false;
        }
        
    }


}
