using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
   public Sounds[] musicSounds, sfxSounds;
   public AudioSource musicSources, sfxSources;

   private string currentTheme = "Theme2"; // Cambia esto por el nombre de tu primer tema
   private string nextTheme = "Theme";

   private void Awake()
   {
    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Destroy(gameObject);
    }
   }

   private void Start()
   {
    Debug.Log("MusicPlaying");
    MusicPlay(currentTheme);
   }

   public void MusicPlay (string name)
   {
    Sounds S = Array.Find (musicSounds, x => x.soundname == name);

    if (S == null)
    {
        Debug.Log("Sound Not Found");
    }
    else
    {
        musicSources.clip = S.clip;
        musicSources.Play();
    }
   }

   public void MusicStop ()
   {
    if (musicSources.isPlaying)
    {
        musicSources.Stop();
    }
   }

   public void ToggleMusic()
    {
        MusicStop();

        // Swap themes
        string temp = currentTheme;
        currentTheme = nextTheme;
        nextTheme = temp;

        // Play new theme
        MusicPlay(currentTheme);
    }

   public void SFXPlay(string name)
   {
    Sounds S = Array.Find (sfxSounds, x => x.soundname == name);

    if (S == null)
    {
        Debug.Log("Sound Not Found");
    }
    else
    {
        sfxSources.PlayOneShot(S.clip);
    }
   }
}
