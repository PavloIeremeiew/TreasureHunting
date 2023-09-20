using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]private AudioSource _source;


    public void PlaySound(AudioClip audio)
    {
        _source.volume = PlayerPrefs.GetFloat("SoundVolume", 1f);
        _source.PlayOneShot(audio);
    }
}
