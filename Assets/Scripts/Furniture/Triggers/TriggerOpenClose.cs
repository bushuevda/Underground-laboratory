using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerOpenClose : MonoBehaviour
{
    [SerializeField] public Text hintOpenClose;
    void Start()
    {
        hintOpenClose.enabled = false;
    }
  
    private void OnTriggerEnter(Collider other)
    {
        hintOpenClose.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        hintOpenClose.enabled = false;
    }
}
