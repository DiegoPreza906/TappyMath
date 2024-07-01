using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingCos : MonoBehaviour
{
   public Slider masterVol, musicVol, sfxVol;
   public AudioMixer mainAudio;

   public void ChangeMasterVol()
   {
    mainAudio.SetFloat("Master", masterVol.value);
   }

   public void ChangeMusicVol()
   {
    mainAudio.SetFloat("Music", musicVol.value);
   }

   public void ChangeSFXVol()
   {
    mainAudio.SetFloat("SFX", sfxVol.value);
   }
}
