using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusicValume : MonoBehaviour
{
    private MusicVolume _setMusicVolume;
    private float _volume;
    void Start()
    {
        BildMusicVolume();
        CheckVolume();
    }
    private void BildMusicVolume()
    {
        _setMusicVolume = GameObject.FindGameObjectWithTag("MusicObject").GetComponent<MusicVolume>();
        _volume = _setMusicVolume.Music.volume;
    }
    private void CheckVolume()
    {
        if (_volume == PlayerPrefs.GetFloat("MusicVolume"))
            return;
        _volume = PlayerPrefs.GetFloat("MusicVolume", 1);
        _setMusicVolume.ChangeVolume(_volume);
    }
}
