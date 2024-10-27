using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTombe : MonoBehaviour, Furniture
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Operate()
    {
        Vector3 pos = transform.position;
        pos.z += 0.1f;
        transform.position = pos;
    }
}
