using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _startCount;

    private Stack<GameObject> _objects;

    public static Pool Instance;
    
    public void Initialize()
    {
        if(Instance == null)

        for (int i = 0; i < _startCount; i++)
        {
            GameObject newGO = Instantiate(_prefab, transform);
            newGO.gameObject.SetActive(false);
        }
    }

    public void Add(GameObject go)
    {
        go.SetActive(false);
        _objects.Push(go);
    }

    public GameObject Get()
    {
        return _objects.Pop();
    }
}
