using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private int _cost;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private GameObject _gameObject;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    public event Action<int> OnCollect;

    public void Update()
    {
        transform.Rotate(0f, _rotationSpeed, 0f);
    }

    private void OnEnable()
    {
        _gameObject.SetActive(true);
    }

    public void Collect()
    {
        OnCollect?.Invoke(_cost);
        _audioSource.PlayOneShot(_audioClip);
        _gameObject.SetActive(false);
        OnCollect = null;
    }

    private void OnCollisionEnter(Collision collision) //по хорошему в левеле сделать
    {
        if (collision.gameObject.CompareTag("Walls"))
        {            
            Debug.Log("Deleted");
            gameObject.SetActive(false);
        }
    }
}
