using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource_SFX;
    public AudioSource audioSource_Music;
    public AudioClip AC_click_btn;
    public AudioClip AC_add_point;
    public AudioClip AC_music;
    void Start()
    {
    }

    public void Audio_btn_click()
    {
        audioSource_SFX.PlayOneShot(AC_click_btn, 1.0f);
        Debug.Log(AC_click_btn);
    }
    public void Audio_AddPoint()
    {
        audioSource_SFX.PlayOneShot(AC_add_point, 1.0f);
        Debug.Log(AC_click_btn);
    }
    public void playMusic()
    {
        audioSource_Music.clip = AC_music;
        audioSource_Music.Play();
    }

    public void MuteSound()
    {
        audioSource_Music.mute = true;
        audioSource_SFX.mute = true;
    } 

}
