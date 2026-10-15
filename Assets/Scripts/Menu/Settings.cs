using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Settings : MonoBehaviour
{
    public Slider VolumeSlider;
    public float Mastervolume = 0.25f;
    public AudioSource MenuMusicPlayer;
    public bool Mute;

    public void SetVolume()
    {
        Mastervolume = VolumeSlider.value;
        MenuMusicPlayer.volume = Mastervolume;

    }

    public void MuteToggle(bool mute)
    {
        Mute = mute;

        if (!Mute)
        {
            MenuMusicPlayer.volume = 0;
            return;
        }
        else
        {
            MenuMusicPlayer.volume = Mastervolume;
            return;
        }
    }

}
