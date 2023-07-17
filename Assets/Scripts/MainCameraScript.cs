using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _POVCamera;

    private bool _POVActive;

    void Start()
    {
        
    }

    void Update()
    {
        MainCameraSwitch();
    }

    public void MainCameraSwitch()
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
