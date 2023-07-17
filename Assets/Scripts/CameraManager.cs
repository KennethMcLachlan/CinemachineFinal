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

    private float _canStart = -1f;

    private float _startRate = 6f;

    private bool _coroutineActive;

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
            _masterBlend.SetActive(false);
            StopAllCoroutines();
            _keyIsPressed = true;
            _keyIsPressed = false;
        }
        else if (Input.GetKeyDown(KeyCode.R) && _POVActive == false)
        {
            _POVCamera.SetActive(true);
            _POVActive = true;
            StopAllCoroutines();
            _masterBlend.SetActive(false);
            _keyIsPressed = true;
            _keyIsPressed = false;
        }
        
        CinematicStart();

    }

    private void CinematicStart()
    {
        

        if (Input.anyKeyDown || Input.GetAxis("Mouse X") !=0 || Input.GetAxis("Mouse Y") != 0)
        {
            _canStart = Time.time + _startRate;
            _keyIsPressed = true;
            _masterBlend.SetActive(false);
            StopAllCoroutines();
            Debug.Log("Key has been pressed");
            _keyIsPressed = false;
        }

        if (_keyIsPressed == false)
        {
            Debug.Log("Master has initiated");

            StartCoroutine(StartCinema());
            

        }
    }

    private void ActivateMaster()
    {
        _masterBlend.SetActive(true);
    }

    IEnumerator StartCinema()
    {
        yield return new WaitForSeconds(5);

        if (_keyIsPressed == true)
        {
            StopAllCoroutines();
            _masterBlend.SetActive(false);
        }

        ActivateMaster();
        
        //CameraShake();

    }

    //public void CameraShake()
    //{
    //    GameObject.Find("ImpulseSource").GetComponent<CameraShake>().Impulse();
    //}

}
