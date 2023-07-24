using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PriorityManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _blendBackPan;

    [SerializeField]
    private GameObject _vcFarGrain;

    [SerializeField]
    private GameObject _vcMultiFX;

    //[SerializeField]
    //private GameObject _vcFrontPan;

    //[SerializeField]
    //private GameObject _blendMotion;

    [SerializeField]
    private GameObject[] _cameras;

    [SerializeField]
    private GameObject _POVCamera;

    [SerializeField]
    private GameObject _thirdPerCam;

    public int _currentCamera;

    private bool _POVActive;

    private bool _keyIsPressed;

    private bool _cinemaRestart;

    private bool _cinemaActive;

    private bool _coroutineEnded;

    
    void Start()
    {
        SetLowCamPriorities();
        _coroutineEnded = true;
    }

    
    void Update()
    {
        CinematicStart();
        MainCameraSwitch();
        //ControllerCameraSwitch();


    }

    public void MainCameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.R) && _POVActive == true)
        {
            _POVCamera.SetActive(false);
            _POVActive = false;
            EndCoroutine();

        }
        else if (Input.GetKeyDown(KeyCode.R) && _POVActive == false)
        {
            _POVCamera.SetActive(true);
            _POVActive = true;
            EndCoroutine();
        }


    }

    //private void ControllerCameraSwitch()
    //{
    //    if (Input.GetKeyDown(KeyCode.R) && _POVActive == true)
    //    {
    //        _POVCamera.GetComponent<CinemachineVirtualCamera>().Priority = 20;
    //        _thirdPerCam.GetComponent<CinemachineVirtualCamera>().Priority = 0;
    //        _POVActive = false;
    //        _cinemaActive = false;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.R) && _POVActive == false)
    //    {
    //        _POVCamera.GetComponent<CinemachineVirtualCamera>().Priority = 0;
    //        _thirdPerCam.GetComponent<CinemachineVirtualCamera>().Priority = 20;
    //        _POVActive = true;
    //        _cinemaActive = false;
    //    }


    //}

    public void CinematicStart()
    {
        if (Input.anyKeyDown || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            _keyIsPressed = true;
            EndCoroutine();
            _keyIsPressed = false;
            _coroutineEnded = true;
        }

        if (_keyIsPressed == false)
        {
            StartCoroutine(CinematicSequence());
            //_corutineEnded = false;
        }

        //if (_cinemaActive == true)
        //{
        //    _POVCamera.GetComponent<CinemachineVirtualCamera>().Priority = 5;
        //    _thirdPerCam.GetComponent<CinemachineVirtualCamera>().Priority = 5;
        //}
    }

    public void SetLowCamPriorities()
    {
        foreach (var cam in _cameras)
        {
            if (cam.GetComponent<CinemachineVirtualCamera>())
            {
                cam.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            }

            if (cam.GetComponent<CinemachineBlendListCamera>())
            {
                cam.GetComponent<CinemachineBlendListCamera>().Priority = 1;
            }
        }
    }

    public void SetCurrentCamera()
    {
        if (_cameras[_currentCamera].GetComponent<CinemachineVirtualCamera>())
        {
            _cameras[_currentCamera].GetComponent<CinemachineVirtualCamera>().Priority = 15;
        }

        if (_cameras[_currentCamera].GetComponent<CinemachineBlendListCamera>())
        {
            _cameras[_currentCamera].GetComponent<CinemachineBlendListCamera>().Priority = 15;
        }

    }


    public void EndCoroutine()
    {
        StopAllCoroutines();
        SetLowCamPriorities();
        StartCoroutine(CinematicSequence());

    }

    IEnumerator CinematicSequence()
    {
        if (_coroutineEnded == true)
        {
            yield return new WaitForSeconds(15);
        }

        _coroutineEnded = false;

        _currentCamera = 0;
        SetCurrentCamera();

        yield return new WaitForSeconds(8);

        _currentCamera = 1;
        SetCurrentCamera();

        yield return new WaitForSeconds(8);

        _currentCamera = 2;
        SetCurrentCamera();

        yield return new WaitForSeconds(8);


        //_currentCamera = 3;
        //SetCurrentCamera();

        //yield return new WaitForSeconds(8);

        //_currentCamera = 4;
        //SetCurrentCamera();

        //yield return new WaitForSeconds(8);

        SetLowCamPriorities();

        EndCoroutine();

        _keyIsPressed = false;

        //_coroutineEnded = false;


    }

}
