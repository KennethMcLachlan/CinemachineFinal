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

    void Start()
    {

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
        }
        else if (Input.GetKeyDown(KeyCode.R) && _POVActive == false)
        {
            _POVCamera.SetActive(true);
            _POVActive = true;
        }

    }

}
