using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockRuner
{
    public class LevelWallKnob : MonoBehaviour
    {
        public int loadLevelID;
        private bool levelOpened = false;
        private bool isInit = false;
        public Material active;
        public Material disable;
        private MeshRenderer mr;
        public void Init(bool isOpened)
        {
            mr = GetComponent<MeshRenderer>();
            levelOpened = isOpened;
            isInit = true;
            if (!isOpened)
            {
                mr.sharedMaterial = disable;
            }
            else
            {
                mr.sharedMaterial = active;
            }
        }

        public void OnMouseDown()
        { 
            if (!isInit) { return; }
            else
            if (!levelOpened) { return; }
            else
            if (levelOpened) { GameManager.Instanse.LoadLevel(loadLevelID);}
           
        } 
    }
}
