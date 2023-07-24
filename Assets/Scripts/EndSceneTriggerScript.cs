using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class EndSceneTriggerScript : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _endSceneDirector;

    [SerializeField]
    private bool _sceneIsOver;

    public UIManager _uiManager;

    [SerializeField]
    private GameObject _endCamera;

    [SerializeField]
    private GameObject _followCam;

    [SerializeField]
    private GameObject _uiText;
    // Start is called before the first frame update
    void Start()
    {
     
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        //_endCamera = GetComponent<CinemachineVirtualCamera>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _endSceneDirector.Play();
            _uiText.SetActive(false);
            _followCam.SetActive(false);
            Invoke("RestartButtonBool", 15.0f);
            Invoke("FinalCamPriority", 10.0f);
        }
    }

    public void RestartButtonBool()
    {
        _sceneIsOver = true;

        if (_sceneIsOver == true)
        {
            _uiManager.ActivateButton();
        }
    }

    public void FinalCamPriority()
    {
        if (_endCamera.GetComponent<CinemachineVirtualCamera>())
        {
            _endCamera.GetComponent<CinemachineVirtualCamera>().Priority = 20;
        }
    }

}
