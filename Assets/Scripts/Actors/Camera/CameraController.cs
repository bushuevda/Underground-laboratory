using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// ��������� �������� ������.
    /// </summary>
    enum modeCamera
    {
        PLAYER,
        BOARD
    }


    /// <summary>
    /// ������-����� ������������� � ������.
    /// </summary>
    [SerializeField] GameObject cameraPlayer;


    /// <summary>
    /// ������-����� ������������� � �����.
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
