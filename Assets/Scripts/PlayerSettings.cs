using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player settings", menuName = "Configs/Player settings")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] private MovementSettings _movementSettings;
    [SerializeField] private List<PlayerUpgrade> _playerUpgrades;

    public MovementSettings MovementSettings => _movementSettings;
}

[System.Serializable]
public class MovementSettings
{
    [SerializeField] private float _speed;
    [SerializeField] private float _roadWidth;
    [SerializeField] private float _lerpSpeed;

    public float Speed => _speed;
    public float RoadWidth => _roadWidth;
    public float LerpSpeed => _lerpSpeed;
}

[System.Serializable]
public class PlayerUpgrade
{
    [SerializeField] private float _speed;
    [SerializeField] private float _multiplier;
}
