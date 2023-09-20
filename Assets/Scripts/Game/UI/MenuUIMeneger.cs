using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIMeneger : MonoBehaviour
{
    [SerializeField] private Text _coinCounter;
    [SerializeField] private GameObject _Settings;
    private void Start()
    {
        SetCoinCounter();
    }
    private void SetCoinCounter()
    {
        int coin = LoadMeneger.Load().Coin;
        _coinCounter.text = $":{coin}";
    }
    public  void ToPlay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Constants.GAME_SCANE_NAME);
    }
    public void Settings(bool activ)
    {
        _Settings.SetActive(activ);
    }

}
