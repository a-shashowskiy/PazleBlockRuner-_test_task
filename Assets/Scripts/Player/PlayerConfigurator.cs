using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace  BlockRuner.Player
{  
    public class PlayerConfigurator : MonoBehaviour
    {
        public GameObject rowBodyPrefab;
        public bool[] leftRowActiveCube = new bool[8] { true,true,true,true,true,true,true,true};
        public bool[] left2RowActiveCube = new bool[8] { true,true,true,true,true,true,true,true};
        public bool[] rightRowActiveCube = new bool[8] { true,true,true,true,true,true,true,true};
        public bool[] right2RowActiveCube = new bool[8] { true,true,true,true,true,true,true,true};
        public bool[] frontRowActiveCube = new bool[8] { true,true,true,true,true,true,true,true};
        public bool[] front2RowActiveCube = new bool[8] { true,true,true,true,true,true,true,true};
        public bool[] backRowActiveCube = new bool[8] { true,true,true,true,true,true,true,true};
        public bool[] back2RowActiveCube = new bool[8] { true,true,true,true,true,true,true,true};
        GameObject _leftRow;
        GameObject _leftRow2;
        GameObject _rightRow;
        GameObject _righRow2;
        GameObject _frontRow;
        GameObject _frontRow2;
        GameObject _backRow;
        GameObject _backRow2; 
        
        
        
        // Start is called before the first frame update
        void Start()
        { 
            //Spawn raw body to all side
            //Init and move them to position 
            
            if(rowBodyPrefab != null)
            {//Spawn copy of main body
                //Left side
                _leftRow = Instantiate(rowBodyPrefab, transform);
                _leftRow.transform.Translate(1,0,0); 
                _leftRow.name = "_leftRow";
                _leftRow.GetComponent<RowInit>().Init(leftRowActiveCube);
                _leftRow2 =  Instantiate(rowBodyPrefab, transform);
                _leftRow2.transform.Translate(2,0,0);
                _leftRow2.name = "_leftRow2";
                _leftRow2.GetComponent<RowInit>().Init(left2RowActiveCube);
                //Right side
                _rightRow = Instantiate(rowBodyPrefab, transform);
                _rightRow.transform.Translate(new Vector3(-1, 0, 0)); 
                _rightRow.name = "_rightRow";
                _rightRow.GetComponent<RowInit>().Init(rightRowActiveCube);
                _righRow2 =  Instantiate(rowBodyPrefab, transform);
                _righRow2.transform.Translate(new Vector3(-2, 0, 0) );
                _righRow2.name = "_righRow2";
                _righRow2.GetComponent<RowInit>().Init(right2RowActiveCube);
                //Front side
                _frontRow =  Instantiate(rowBodyPrefab, transform);
                _frontRow.transform.Translate(new Vector3(0 ,0, 1));
                _frontRow.name = "_frontRow";
                _frontRow.GetComponent<RowInit>().Init(frontRowActiveCube);
                _frontRow2 =  Instantiate(rowBodyPrefab, transform);
                _frontRow2.transform.Translate(new Vector3(0, 0, 2));
                _frontRow2.name = "_frontRow2";
                _frontRow2.GetComponent<RowInit>().Init(front2RowActiveCube);
                //Back side
                _backRow = Instantiate(rowBodyPrefab, transform);
                _backRow.transform.Translate(new Vector3(0, 0, -1) );
                _backRow.name = "_backRow";
                _backRow.GetComponent<RowInit>().Init(backRowActiveCube);
                _backRow2 =  Instantiate(rowBodyPrefab, transform);
                _backRow2.transform.Translate(new Vector3(0, 0, -2) ); 
                _backRow2.name = "_backRow2";
                _backRow2.GetComponent<RowInit>().Init(back2RowActiveCube);
            }
        } 
    } 
}
