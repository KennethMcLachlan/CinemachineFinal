using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.IO.LowLevel.Unsafe;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _POVCamera;

    [SerializeField]
    private GameObject _rearCamera;

    private bool _POVActive;

    [SerializeField]
    private GameObject[] _manager;

    [SerializeField]
    private GameObject _masterBlend;

    private bool _keyIsPressed;

    void Start()
    {
        CinematicStart();
    }

    void Update()
    {
        CameraSwitch();

    }

    private void CameraSwitch()
    {

        if (Input.GetKeyDown(KeyCode.R) && _POVActive == true)
        {
            _POVCamera.SetActive(false);
            _POVActive = false;
            _masterBlend.SetActive(false);
            _keyIsPressed = true;
            _keyIsPressed = false;
        }
        else if (Input.GetKeyDown(KeyCode.R) && _POVActive == false)
        {
            _POVCamera.SetActive(true);
            _POVActive = true;
            _masterBlend.SetActive(false);
            _keyIsPressed = true;
            _keyIsPressed = false;
        }

    }

    private void CinematicStart()
    {
        if (Input.anyKeyDown)
        {
            _keyIsPressed = true;
            _masterBlend.SetActive(false);
            Debug.Log("Key has been pressed");
            _keyIsPressed = false;
        }

        if (_keyIsPressed == false)
        {
            Invoke("ActivateMaster", 5.0f);
            Debug.Log("Master has initiated");
        }

    }

    private void ActivateMaster()
    {
        _masterBlend.SetActive(true);
    }


}
