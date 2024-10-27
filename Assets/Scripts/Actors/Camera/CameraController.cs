using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Состояние основной камеры.
    /// </summary>
    enum modeCamera
    {
        PLAYER,
        BOARD
    }


    /// <summary>
    /// Камера-поток прикрепленная к игроку.
    /// </summary>
    [SerializeField] GameObject cameraPlayer;


    /// <summary>
    /// Камера-поток прикрепленная к доске.
    /// </summary>
    [SerializeField] GameObject cameraBoard;


    modeCamera mode;


    void Start()
    {
        cameraBoard.SetActive(false);
        cameraPlayer.SetActive(true);
        mode = modeCamera.PLAYER;
    }


}
