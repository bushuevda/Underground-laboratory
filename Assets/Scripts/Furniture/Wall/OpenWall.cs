using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWall : MonoBehaviour, Furniture
{
    enum wall_mode
    {
        OPEN,
        CLOSE
    }
    [SerializeField] float widthtWall;
    wall_mode modeWall; 
    
    void Start()
    {
        modeWall = wall_mode.OPEN;
        widthtWall = transform.localScale.x;
    }


    public void Operate()
    {
        StartCoroutine(ControllerModeWall());
    }



    IEnumerator ControllerModeWall()
    {
        float incr = (Mathf.Abs(transform.position.x - widthtWall)) / transform.position.x;
        float end = transform.position.x - widthtWall;
        float begin = transform.position.x;
        if(modeWall == wall_mode.CLOSE)
        {
            while (begin > end)
            {
                begin -= incr;
                Vector3 pos = transform.position;
                pos.x = begin;
                transform.position = pos;
                yield return new WaitForSeconds(.1f);
            }
            modeWall = wall_mode.OPEN;
        }
        else if (modeWall == wall_mode.OPEN)
        {
            begin = transform.position.x;
            end = begin + widthtWall;
            while (begin < end)
            {
                begin += incr;
                Vector3 pos = transform.position;
                pos.x = begin;
                transform.position = pos;
                yield return new WaitForSeconds(.1f);
            }
            modeWall = wall_mode.CLOSE;
        }
        yield break;
    }
}
