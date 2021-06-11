using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockRuner 
{ 
    public class RowInit : MonoBehaviour
    {
        public string goName;
        [SerializeField]
        private List<GameObject> rowCube;
        private bool isInit = false; 
        
       
        public void Init(bool[] state)
        {  
            rowCube = new List<GameObject>();
            Transform[] t = transform.GetComponentsInChildren<Transform>();
             
            if (t.Length > 0)
            {
                for (int i = 0; i < t.Length; i++)
                {
                    if (t[i].name == goName)
                    {
                        if (rowCube.Contains(t[i].gameObject) == false)
                        {
                            rowCube.Add(t[i].gameObject);
                        }
                        else continue;
                    } 
                    else continue;
                }
            } 
            
            if (rowCube.Count > 0)
            {
                for (int i = 0; i < state.Length; i++)
                {
                    rowCube[i].SetActive(state[i]);
                }
            }
            isInit = true;
        }

    }
}
