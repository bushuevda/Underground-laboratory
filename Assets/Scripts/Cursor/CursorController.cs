using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    /// <summary>
    /// �������� �������� �������.
    /// </summary>
    [SerializeField] Texture2D textureBegin;


    /// <summary>
    /// �������� ������� ��� ������ ��������.
    /// </summary>
    [SerializeField] Texture2D textureChange;


    /// <summary>
    /// ������-����� ������������� � ������.
    /// </summary>
    [SerializeField] Camera _camera;


    /// <summary>
    /// ��������� ��������� ��������
    /// </summary>
    bool changeTexture = false;


    /// <summary>
    /// ������ �������� size x size
    /// </summary>
    int size = 46;


    /// <summary>
    /// ��������� �������� ������� �� X
    /// </summary>
    float posX;


    /// <summary>
    /// ��������� �������� ������� �� Y
    /// </summary>
    float posY;


    void OnGUI()
    {
        if (!changeTexture) 
            GUI.DrawTexture(new Rect(posX, posY, size, size), textureBegin);
       else
            GUI.DrawTexture(new Rect(posX, posY, size, size), textureChange);
    }


    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        posX = _camera.pixelWidth / 2 - size / 4;
        posY = _camera.pixelHeight / 2 - size / 2;
     }


    void Update()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject != null && hitObject.GetComponent<Furniture>() != null ||
                hitObject.GetComponent<Items.Item>() != null)
            {
                changeTexture = true;
                if (hitObject.GetComponent<Furniture>() != null)
                    useForniture(hitObject);
                else if(hitObject.GetComponent<Items.Item>() != null)
                    takeItem(hitObject);
            }
            else
            {
                changeTexture = false;
            }
        }
    }


    /// <summary>
    /// ������� ������������� ��������� ���������.
    /// </summary>
    /// <param name="hitObject">
    /// ������, �� ������� ������� ��� �� ������ ������.
    /// </param>
    void useForniture(GameObject hitObject)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Open object");
            hitObject.GetComponent<Furniture>().Operate();

        }
    }


    /// <summary>
    /// ������� ������ ��������.
    /// </summary>
    /// <param name="hitObject">
    /// ������, �� ������� ������� ��� �� ������ ������.
    /// </param>
    void takeItem(GameObject hitObject)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Take item");
            hitObject.GetComponent<Items.Item>().Put();
        }
    }
}
