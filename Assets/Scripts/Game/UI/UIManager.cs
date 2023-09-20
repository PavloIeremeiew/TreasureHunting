using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel, _pauseButton, _pauseMenu, _endMenu;
    [SerializeField] private Text _coinCounter, _bombCounter, _winCounter;


    private void OnEnable()
    {
        Player.OnShowCoin += ShowCoin;
        ChekCell.OnShowBombNumber += ShowBombCount;
        Player.OnEnd += ShowEndMenu;

    }
    private void OnDisable()
    {
        Player.OnShowCoin -= ShowCoin;
        ChekCell.OnShowBombNumber -= ShowBombCount;
        Player.OnEnd -= ShowEndMenu;

    }


    public void Pause()
    {
        Time.timeScale = 0f;
        _pauseButton.SetActive(false);
        _menuPanel.SetActive(true);
        _pauseMenu.SetActive(true);
        _endMenu.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        _pauseButton.SetActive(true);
        _menuPanel.SetActive(false);
        _pauseMenu.SetActive(false);
        _endMenu.SetActive(false);
    }
    private void ShowCoin(int number)
    {
        if (number < 0)
            return;
        _coinCounter.text = $":{number}";
    }
    private void HideCoin()
    {
        _coinCounter.text = "";
    }
    private void ShowBombCount(int number)
    {

        _bombCounter.text = $"{((number > 0) ? number : "")}";
    }
    public void ShowEndMenu(bool win, int number)
    {
        Time.timeScale = 0f;
        ShowBombCount(0);
        HideCoin();
        _pauseButton.SetActive(false);
        _menuPanel.SetActive(true);
        _endMenu.SetActive(true);
        if (number > 0)
            _winCounter.text = $"{((win) ? "+" : "-")}{number}";
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Constants.MENU_NAME);
    }
    
}
