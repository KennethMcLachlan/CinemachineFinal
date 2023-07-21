using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class CinemaManager : MonoBehaviour
{

    [SerializeField]
    private PlayableDirector _director;

    // Start is called before the first frame update
    void Start()
    {
        _director = GetComponent<PlayableDirector>();
        _director.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
