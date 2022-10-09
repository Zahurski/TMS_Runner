using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Finish : MonoBehaviour, ICollectable
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    [SerializeField] private ParticleSystem _finishPS;

    private event Action OnFinish;
    public void Collect()
    {
        OnFinish?.Invoke();
        _finishPS.Play();
        _audioSource.PlayOneShot(_audioClip);
        OnFinish = null;
    }
}
