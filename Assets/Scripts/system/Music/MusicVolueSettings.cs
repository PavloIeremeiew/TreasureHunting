using UnityEngine;
using UnityEngine.UI;

public class MusicVolueSettings : MonoBehaviour
{
    [SerializeField] private Slider _musicStats;
    private MusicVolume _setMusicVolume;
    private float _volume;
    void Start()
    {
        BildMusicVolume();
    }
    private void LateUpdate()
    {
        CheckSlider();
        CheckVolume();
    }

    private void BildMusicVolume()
    {
        _setMusicVolume = GameObject.FindGameObjectWithTag("MusicObject").GetComponent<MusicVolume>();
        _volume = _setMusicVolume.Music.volume;
        _musicStats.value = PlayerPrefs.GetFloat("MusicVolume",1);
    }
    private void CheckSlider()
    {
        if (_musicStats.value == PlayerPrefs.GetFloat("MusicVolume",1))
            return;
        PlayerPrefs.SetFloat("MusicVolume", _musicStats.value);
        PlayerPrefs.Save();
    }
    private void CheckVolume()
    {
        if (_volume == _musicStats.value)
            return;
        _volume = _musicStats.value;
        _setMusicVolume.ChangeVolume(_volume);
    }
}
