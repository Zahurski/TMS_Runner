using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [Header("Prefabs:")]
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _levelPrefab;

    [Header("Positions:")]
    [SerializeField] private Transform _startPosition;

    [SerializeField] private UIManager _uiManager;
    private GameObject _level;
    private Level _currentLevel;
    private int _levelIndex;

    private PlayerController _player = null;
    private PlayerData _playerData;

    private int _coin;
    private int _seedValue = 123123;

    private void Start()
    {
        LoadLevelIndex();
        _uiManager.ShowStartScreen();        
        CreateLevel(_levelIndex);
        GeneratePlayer();
    }

    private void UpdateSeedValue()
    {
        _seedValue++;
        UnityEngine.Random.InitState(_seedValue);
    }

    private void LoadLevelIndex()
    {
        _levelIndex = PlayerPrefs.GetInt("LevelIndex", 1);
        _coin = PlayerPrefs.GetInt("Coin", 0);
        _uiManager.ShowCoins(_coin);
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("PlayerData") == false)
        {
            _playerData = new PlayerData();
            return;
        }

        string playerDataString = PlayerPrefs.GetString("PlayerData");
        _playerData = JsonUtility.FromJson<PlayerData>(playerDataString);
    }

    private void SaveData()
    {
        string stringData = JsonUtility.ToJson(_playerData);
        PlayerPrefs.SetString("PlayerData", stringData);
    }

    private void CreateLevel(int level)
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
            _currentLevel = null;
        }

        _level = Instantiate(_levelPrefab, _startPosition.position, Quaternion.identity);

        _currentLevel = _level.GetComponent<Level>();
        _currentLevel.Generate(_levelIndex);
        _currentLevel.CoinsAction(GoldIncrease);
    }

    private void GeneratePlayer()
    {
        if (_player != null)
        {
            Destroy(_player.gameObject);
            _player = null;
        }

        GameObject player = Instantiate(_playerPrefab, transform);
        player.transform.localPosition = new Vector3(0f, 0.5f, 0f);

        _player = player.GetComponent<PlayerController>();
        _player.Initialize();
    }

    public void StartPlayer()
    {
        _player = FindObjectOfType<PlayerController>();
        _player.IsAlive = true;
    }

    private void Finish()
    {
        if (_player.IsFinish)
        {
            _uiManager.ShowWinScreen();
        }
        else
        {
            _uiManager.ShowLoseScreen();
        }
    }

    public void StartGame()
    {
        _uiManager.ShowGameScreen();
        StartCoroutine(StartDelay());
        _uiManager.TextToStart();
        _player.OnStop += StopGame;
    }

    public void Replay()
    {
        GeneratePlayer();
        StartGame();
    }

    public void NextLevel()
    {
        _levelIndex++;
        PlayerPrefs.SetInt("LevelIndex", _levelIndex);
        PlayerPrefs.SetInt("Coin", _coin);
        CreateLevel(_levelIndex);
        GeneratePlayer();        
        StartGame();
    }

    public void StopGame()
    {
        Finish();
        _currentLevel.OnComplete -= StopGame;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoldIncrease(int value)
    {
        _coin += value;
        _uiManager.ShowCoins(_coin);
    }

    IEnumerator StartDelay()
    {
        float startTime = Time.time;

        while (Time.time < startTime + 2)
        {
            yield return new WaitForSeconds(0.75f);
        }

        StartPlayer();
    }
}
