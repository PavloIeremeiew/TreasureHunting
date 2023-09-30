using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel, _pauseButton, _pauseMenu, _endMenu, _exitBar,_exitBarValue,_secondTryButton;
    [SerializeField] private Text _coinCounter, _bombCounter, _winCounter, _secondTryIndexText;


    private void OnEnable()
    {
        Player.OnShowCoin += ShowCoin;
        ChekCell.OnShowBombNumber += ShowBombCount;
        Player.OnEnd += ShowEndMenu;
        HowFarExit.OnSetExitBarValue += SetExitBarValue;
    }
    private void OnDisable()
    {
        Player.OnShowCoin -= ShowCoin;
        ChekCell.OnShowBombNumber -= ShowBombCount;
        Player.OnEnd -= ShowEndMenu;
        HowFarExit.OnSetExitBarValue -= SetExitBarValue;
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
        _exitBar.SetActive(true);
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
        _exitBar.SetActive(false);
        if (number > 0)
            _winCounter.text = $"{((win) ? "+" : "-")}{number}";
        if (!win)
            ShowLoseMenu();
    }

    private void ShowLoseMenu()
    {
        int trys = LoadMeneger.Load().SecondTrys;
        _secondTryIndexText.text = "x" + trys;
        if(trys <= 0)
            _secondTryIndexText.color = Color.red;
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
    private void SetExitBarValue(float value)
    {
        _exitBarValue.transform.localScale= new Vector3 (value,1,1);
    }
    public void SecondTry()
    {
        int trys = LoadMeneger.Load().SecondTrys;
        if (trys > 0)
        {
            _secondTryButton.SetActive(false);
            SaveMeneger.AddToSave(MainSave.SecondTrysSet(-1));
            Continue();
        }
        
    }
}
