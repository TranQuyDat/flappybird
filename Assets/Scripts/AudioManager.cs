using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Struct_audioclip {
    public string name;
    public AudioClip audioClip;
}

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource_SFX;
    public AudioSource audioSource_Music;
    public List<Struct_audioclip> struct_Audioclips;
    private AudioClip audioClip;
    private AudioClip getAudioClip(string name)
    {
        
        for (int i = 0; i < struct_Audioclips.Count; i++)   
        {
            Debug.Log(struct_Audioclips[i].audioClip);
            if (struct_Audioclips[i].name == name) 
                audioClip = struct_Audioclips[i].audioClip;
        }
        return audioClip;
    }
    public void Audio_playoneshot(string nameAudioclip)
    {
       
        audioSource_SFX.PlayOneShot(getAudioClip(nameAudioclip), 1.0f);
    }
  
    public void Audio_playLoop(string nameAudioclip)
    {
        
        audioSource_Music.clip = getAudioClip(nameAudioclip);
        audioSource_Music.volume = 1.0f;
        audioSource_Music.Play();
    }

    public void MuteSound()
    {
        audioSource_Music.mute = true;
        audioSource_SFX.mute = true;
    } 

}
