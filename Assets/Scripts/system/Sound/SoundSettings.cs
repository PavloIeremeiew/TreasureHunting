using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Slider _musicStats;
    private float _volume;
    private void Start()
    {
        _musicStats.value = PlayerPrefs.GetFloat("SoundVolume", 1);
    }
    private void LateUpdate()
    {
        CheckSlider();
    }
    private void CheckSlider()
    {
        if (_musicStats.value == PlayerPrefs.GetFloat("SoundVolume", 1))
            return;
        PlayerPrefs.SetFloat("SoundVolume", _musicStats.value);
        PlayerPrefs.Save();
    }
}
