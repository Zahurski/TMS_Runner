using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;

    public void SetIdleTrigger()
    {
        SetTrigger("Idle");
    }

    public void SetRunTrigger()
    {
        SetTrigger("Run");
    }
    public void SetFallTrigger()
    {
        SetTrigger("Fall");
    }
    public void SetWinTrigger()
    {
        SetTrigger("Dance");
    }

    public void SetTrigger(int id) => _animator.SetTrigger(id);
    public void SetTrigger(string triggerName) => _animator.SetTrigger(triggerName);
    public void SetFloat(float value, string name) => _animator.SetFloat(name, value);
}
