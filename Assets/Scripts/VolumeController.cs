using UnityEngine.Audio;
using UnityEngine;

/*
 * Sets the music or sfx level based on options sliders
 * Learned how to do this from https://www.youtube.com/watch?v=xNHSGMKtlv4
 */
public class VolumeController : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetMusicLevel (float sliderValue)
    {
        // Adjusts for decibel levels being in a log scale
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSFXLevel(float sliderValue)
    {
        // Adjusts for decibel levels being in a log scale
        mixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }
}
