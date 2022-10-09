using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _roadLength;
    [SerializeField] private float _minObstacleOffsetZ;
    [SerializeField] private float _maxObstacleOffsetZ;
    [SerializeField] private float _startPlayerOffsetZ;

    [Header("Elements settings")]
    [SerializeField] private float _roadPartLength;
    [SerializeField] private float _roadPartWidth;

    [Header("Prefab")]
    [SerializeField] private GameObject _finishPrefab;
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private GameObject _roadPartPrefab;
    [SerializeField] private GameObject _coinPrefab;

    public event Action OnComplete;

    private List<Coin> _coins = new List<Coin>();


    public void CoinsAction(Action<int> action)
    {
        _coins.AddRange(GetComponentsInChildren<Coin>());

        foreach (var coin in _coins)
        {
            coin.OnCollect += action;
        }
    }

    [ContextMenu("Road")]
    public void Generate(int levelIndex)
    {
        UnityEngine.Random.InitState(levelIndex);

        GenerateRoad();
        GenerateObstacle();
        GenerateCoin();
    }

    private void GenerateRoad()
    {
        Vector3 localPosition = Vector3.zero;
        int partsCount = Mathf.CeilToInt(_roadLength / _roadPartLength); //сколько у нас блоков дороги будет построено

        for (int i = 0; i < partsCount; i++)
        {
            GameObject roadPart = Instantiate(_roadPartPrefab, transform);
            roadPart.transform.localPosition = localPosition;
            localPosition.z += _roadPartLength;
        }

        GameObject finishPart = Instantiate(_finishPrefab, transform);
        finishPart.transform.localPosition = localPosition;
    }

    private void GenerateObstacle()
    {
        float roadlength = _roadLength;
        float currentLength = _startPlayerOffsetZ;
        float startX = -_roadPartWidth / 2f;
        float xOffset = _roadPartWidth / 4f;

        while (currentLength < roadlength)
        {
            int intPosition = UnityEngine.Random.Range(0, 4);
            float positionX = startX + intPosition * xOffset;

            Vector3 localPosition = new Vector3(positionX, 0f, currentLength);
            GameObject obstacle = Instantiate(_obstaclePrefab, transform);
            obstacle.transform.localPosition = localPosition;

            currentLength += UnityEngine.Random.Range(_minObstacleOffsetZ, _maxObstacleOffsetZ);
        }
    }

    private void GenerateCoin()
    {
        float roadlength = _roadLength;
        float currentLength = _startPlayerOffsetZ;
        float startX = -_roadPartWidth / 2f;
        float xOffset = _roadPartWidth / 4f;

        //GameObject gem = Pool.Instance.Get();

        while (currentLength < roadlength)
        {
            int intPosition = UnityEngine.Random.Range(0, 4);
            float positionX = startX + intPosition * xOffset + 1;

            Vector3 localPosition = new Vector3(positionX, 1.5f, currentLength);
            GameObject coin = Instantiate(_coinPrefab, transform);
            coin.transform.localPosition = localPosition;

            currentLength += UnityEngine.Random.Range(_minObstacleOffsetZ, _maxObstacleOffsetZ);
        }
    }
}
