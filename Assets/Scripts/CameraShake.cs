using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineImpulseSource _source;
    void Start()
    {
        Impulse();
    }

    void Update()
    {
        
    }

    public void Impulse()
    {
        _source = GetComponent<CinemachineImpulseSource>();
        _source.GenerateImpulse();
    }
}
