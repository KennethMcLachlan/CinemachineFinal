using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class PortalTriggerScript : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _portalDirector;

    [SerializeField]
    private GameObject _dreadnaught;

    [SerializeField]
    private GameObject _warpAudio;

    private void Start()
    {
        //_portalDirector = GetComponent<PlayableDirector>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Trigger has been hit");
            _dreadnaught.SetActive(true);
            _warpAudio.SetActive(true);
            _portalDirector.Play();
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
}
