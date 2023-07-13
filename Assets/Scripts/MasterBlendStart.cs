using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBlendStart : MonoBehaviour
{
    [SerializeField]
    private GameObject _masterBlend;

    private bool _keyIsPressed;
    void Start()
    {
        //_keyIsPressed = true;

        CinematicStart();
    }

    void Update()
    {
       
    }

    private void CinematicStart()
    {
        
        if (Input.anyKey)
        {
            _keyIsPressed = true;
            Debug.Log("Key has been pressed");
            _keyIsPressed = false;
        }

        if (_keyIsPressed == false)
        {
            Invoke("ActivateMaster", 5.0f);
            Debug.Log("Master has initiated");
        }



        //else _keyIsPressed &= !Input.anyKey;
    }

    private void ActivateMaster()
    {
        _masterBlend.SetActive(true);
    }
}
