using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    /// <summary>
    /// Основная текстура курсора.
    /// </summary>
    [SerializeField] Texture2D textureBegin;


    /// <summary>
    /// Текстура курсора для выбора предмета.
    /// </summary>
    [SerializeField] Texture2D textureChange;


    /// <summary>
    /// Камера-поток прикрепленная к игроку.
    /// </summary>
    [SerializeField] Camera _camera;


    /// <summary>
    /// Состояния изменения текстуры
    /// </summary>
    bool changeTexture = false;


    /// <summary>
    /// Размер текстуры size x size
    /// </summary>
    int size = 46;


    /// <summary>
    /// Положение текстуры курсора по X
    /// </summary>
    float posX;


    /// <summary>
    /// Положение текстуры курсора по Y
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
    /// Функция использования предметов форнитуры.
    /// </summary>
    /// <param name="hitObject">
    /// Объект, на который исходит луч из центра камеры.
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
    /// Функция взятия предмета.
    /// </summary>
    /// <param name="hitObject">
    /// Объект, на который исходит луч из центра камеры.
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
