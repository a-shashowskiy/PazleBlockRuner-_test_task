using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
 public class ResetSave : MonoBehaviour 
{ 
    [MenuItem("PuzleRun/ClearSave")]
    static void ClearSave()
    {
        PlayerPrefs.SetInt("openedLevel", 1);
    }
    [MenuItem("PuzleRun/OpenAllSave")]
    static void OpenSave()
    {
        PlayerPrefs.SetInt("openedLevel",20);
    }
}