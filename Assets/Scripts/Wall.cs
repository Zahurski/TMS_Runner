using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wall : MonoBehaviour, ICollectable
{
    [SerializeField] private AudioSource _audioSourceObstacle;
    [SerializeField] private AudioClip _audioClipObstacle;

    private event Action OnObstacle;
    public void Collect()
    {
        OnObstacle?.Invoke();
        _audioSourceObstacle.PlayOneShot(_audioClipObstacle);
        OnObstacle = null;
    }
}
