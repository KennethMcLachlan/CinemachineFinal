using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _restartButton;

    [SerializeField]
    public EndSceneTriggerScript _endTrigger;

    [SerializeField]
    public Button _buttonClicker;
    // Start is called before the first frame update
    void Start()
    {
        _endTrigger = GameObject.Find("EndSceneCubeTrigger").GetComponent<EndSceneTriggerScript>();

        Button btn = _buttonClicker.GetComponent<Button>();
        btn.onClick.AddListener(RestartBuild);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndSceneButton()
    {
        _endTrigger.RestartButtonBool();
        //_restartButton.SetActive(true);
    }

    public void RestartBuild()
    {
        SceneManager.LoadScene(0);
    }

    public void ActivateButton()
    {
        _restartButton.SetActive(true);
    }

}

    
