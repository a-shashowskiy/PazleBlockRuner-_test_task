using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace BlockRuner
{
    public class MainMenuManager : MonoBehaviour
    {  
        public event Opened openLw;
        public event Closed closeLw;
        public UnityEngine.Audio.AudioMixer audioMixer;
        public CinemachineVirtualCamera vrCam;
        public Animator mainMenuAnimator;
        private bool inLevelMenu = false;
        public LevelWall lwall;
        
        
        public void Start()
        {
            //lwall = GameObject.Find("LevelWall").GetComponent<LevelWall>();
            lwall.Init(this);
            Debug.Log(("Start main menu "));
            if(GameObject.FindWithTag("Input"))GameObject.FindWithTag("Input").SetActive(false);
        }
        
        // UI CALL FUNCTION FOR BUTTON
        // MUTE OR UNMUTE AUDIO IN MASTER MIXER Part.
        // TO performe more level need add in mixer and cereate normal setting, now made as simpe as posible
        public void MuteUnmuteSound()
        {
            float curentV = 0;
            audioMixer.GetFloat("VolumeMain", out curentV);
            if (curentV == 0)
            {
                audioMixer.SetFloat("VolumeMain", -80);
            }

            if (curentV == -80)
            {
                audioMixer.SetFloat("VolumeMain", 0);
            }
        }

        
        public void ToLevelMenu()
        {
            vrCam.Priority = 11;
            mainMenuAnimator.ResetTrigger("Visible");
            mainMenuAnimator.SetTrigger("Invisible");
            inLevelMenu = true;
            openLw.Invoke();
        }

        public void BackToMain()
        {
            vrCam.Priority = 1;
            mainMenuAnimator.ResetTrigger("Invisible");
            mainMenuAnimator.SetTrigger("Visible");
            inLevelMenu = false;
            closeLw.Invoke();
        }
        
        
        //EXIT FOROM APLICATION
        public void Exit()
        {
            UnityEngine.Application.Quit();
        }
    }
}
