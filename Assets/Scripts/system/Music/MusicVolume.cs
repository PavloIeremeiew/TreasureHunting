using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    public AudioSource Music { get => _music; private set => _music = value; }
    [SerializeField] private AudioSource _music;
    public void ChangeVolume(float volume)
    {
        if (volume < 0 || volume > 1)
            return;
        _music.volume = volume;
    }
}
