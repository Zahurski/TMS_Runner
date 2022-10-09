using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _gameScreen;

    [SerializeField] private Text _coinsText;
    [SerializeField] private Text _timeText;

    private GameObject _currentScreen;

    private void Awake()
    {
        _currentScreen = _startScreen;
    }

    public void ShowStartScreen()
    {
        _currentScreen.SetActive(false);
        _startScreen.SetActive(true);
        _currentScreen = _startScreen;
    }

    public void ShowGameScreen()
    {
        _currentScreen.SetActive(false);
        _gameScreen.SetActive(true);
        _currentScreen = _gameScreen;        
    }

    public void ShowWinScreen()
    {
        _currentScreen.SetActive(false);
        _winScreen.SetActive(true);
        _currentScreen = _winScreen;
    }

    public void ShowLoseScreen()
    {
        _currentScreen.SetActive(false);
        _loseScreen.SetActive(true);
        _currentScreen = _loseScreen;
    }

    public void ShowCoins(int coin)
    {
        _coinsText.text = coin.ToString();
    }

    public void TextToStart()
    {
        _timeText.gameObject.SetActive(true);
        StartCoroutine(SecondsToStart());
    }

    IEnumerator SecondsToStart()
    {
        float updateTime = 3f;

        while (updateTime >= 0)
        {
            if (updateTime == 0)
            {
                _timeText.text = "GO!";
            }
            else
            {
                _timeText.text = updateTime.ToString();
            }

            updateTime--;
            yield return new WaitForSeconds(0.75f);
        }

        _timeText.gameObject.SetActive(false);
    }

}
