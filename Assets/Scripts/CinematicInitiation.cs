using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinematicInitiation : MonoBehaviour
{
    [SerializeField] private GameObject _cameras;

    [SerializeField]
    private GameObject _vc01;

    [SerializeField]
    private GameObject _vc02;

    [SerializeField]
    private GameObject _vc03;

    [SerializeField]
    private GameObject _vc04;

    [SerializeField]
    private GameObject _vc05;

    void Start()
    {
        //StartCoroutine(CameraChange());
    }

    void Update()
    {
        
    }

    //private void CinematicStart()
    //{
    //    if (Input.anyKey)
    //    {
    //        Invoke("Camera", 5.0f);
    //    }
    //}

    //private void Camera()
    //{
    //    _cameras.SetActive(true);
    //}

    IEnumerator CameraChange()
    {
        _vc01.SetActive(true);

        yield return new WaitForSeconds(8);

        _vc01.SetActive(false);

        _vc02.SetActive(true);

        yield return new WaitForSeconds(8);

        _vc02.SetActive(false);
        _vc03.SetActive(true);

        yield return new WaitForSeconds(8);

        _vc03.SetActive(false);
        _vc04.SetActive(true);

        yield return new WaitForSeconds(8);

        _vc04.SetActive(false);
        _vc05.SetActive(true);

        yield return new WaitForSeconds(8);

        _vc05.SetActive(false);

        StopCoroutine(CameraChange());
    }
}
