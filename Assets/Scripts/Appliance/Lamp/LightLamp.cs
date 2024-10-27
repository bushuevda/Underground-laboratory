using System.Collections;
using System.Drawing;
using UnityEngine;

public class LightLamp : MonoBehaviour
{
    private Light _lamp;
    bool _changeColor;
    // Start is called before the first frame update
    void Start()
    {
        _lamp = GetComponent<Light>();
        _changeColor = false;
    }

    // Update is called once per frame
    void Update()
    {

     //.   StartCoroutine(ChangeMode());
    }
    IEnumerator ChangeMode()
    {
        int ch = 130;
        int n = 1;
        while (true)
        {
            if (ch == 181 || ch == 129)
                n *= -1;
            ch += n;
            _lamp.color = new UnityEngine.Color(111,ch,145);
            yield return null;
        }


    }

}
