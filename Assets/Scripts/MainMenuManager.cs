using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public UnityEngine.Audio.AudioMixer audioMixer;
    /// <summary>
    /// Load level from build scene in list  
    /// </summary>
    /// <param name="levelID"></param>
    public void LoadLevel(int levelID)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelID);
    }
    //MUTE OR UNMUTE AUDIO IN MASTER MIXER Part.
    // TO performe more level need add in mixer and cereate normal setting, now made as simpe as posible
    public void MuteUnmuteSound()
    {
        float curentV = 0;
        audioMixer.GetFloat("VolumeMain", out curentV);
        if (curentV == 0){ audioMixer.SetFloat("VolumeMain", -80);}
        if (curentV == -80){ audioMixer.SetFloat("VolumeMain", 0); }
    }
    //EXIT FOROM APLICATION
    public void Exit()
    {
        UnityEngine.Application.Quit();
    }
}
