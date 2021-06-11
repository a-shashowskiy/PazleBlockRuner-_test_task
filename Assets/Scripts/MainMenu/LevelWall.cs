using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockRuner
{
    public class LevelWall : MonoBehaviour
    {
        private List<LevelWallKnob> lwK;
        // Start is called before the first frame update
        public void Init(MainMenuManager mmg)
        {
            
            mmg.openLw+=Open;
            mmg.closeLw += Close;
            lwK = new List<LevelWallKnob>();
            Transform[] t =  GetComponentsInChildren<Transform>();
            if (t.Length > 0)
            {
                for (int i = 0; i < t.Length; i++)
                {
                    if (t[i].GetComponent<LevelWallKnob>())
                    {
                        lwK.Add(t[i].GetComponent<LevelWallKnob>());
                    }else continue;
                } 
            }

            if (lwK.Count > 0)
            {
                foreach (LevelWallKnob v in lwK)
                {
                    if (v.loadLevelID <= GameManager.Instanse.OpenedLevel)
                    {
                        v.Init(true);
                    }
                    else v.Init(false); 
                } 
            }
        }
 
        void Open(){Debug.Log("Open level menue");}
        void Close(){Debug.Log("Open level menue");}
    }
}
