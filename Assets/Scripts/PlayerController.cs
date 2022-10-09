using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private bool _isAlive;
    private bool _isFinish;

    [SerializeField] private AnimationController _animationController;
    [SerializeField] private ParticleSystem _playerPS;

    private IInputHandler _inputHandler = null;
    private IMoveController _moveController = null;

    public event Action OnStop;

    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            if (value == true) _animationController.SetRunTrigger();
            _isAlive = value;
        }
    }

    public bool IsFinish
    {
        get
        {
            return _isFinish;
        }
    }

    private void Update()
    {
        if (_isAlive == false) return;
        if (_isFinish == true) return;
        _moveController.Move(_inputHandler.GetHorizontalAxis());
    }

    public void Initialize()
    {
        _inputHandler = GetComponent<IInputHandler>();
        _moveController = GetComponent<IMoveController>();
    }

    private const string _wallsTag = "Walls";
    private const string _finishTag = "Finish";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ICollectable collectable))
        {
            collectable.Collect();
        }

        if (collision.gameObject.CompareTag(_wallsTag))
        {
            _playerPS.Play();
            Died();            
        }

        if (collision.gameObject.CompareTag(_finishTag))
        {
            Finish();
        }
    }

    private void Died()
    {
        _isAlive = false;
        _isFinish = false;
        _animationController.SetFallTrigger();
        OnStop?.Invoke();        
    }

    private void Finish()
    {
        _isAlive = false;
        _isFinish = true;
        _animationController.SetWinTrigger();
        OnStop?.Invoke();
    }
}
