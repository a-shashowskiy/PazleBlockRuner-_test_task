using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockRuner
{
    public class GateInit : MonoBehaviour
    {
        public GameObject cubeRow;
        public bool[] leftRowActiveCube = new bool[8] {true, true, true, true, true, true, true, true};
        public bool[] left2RowActiveCube = new bool[8] {true, true, true, true, true, true, true, true};
        public bool[] left3RowActiveCube = new bool[8] {true, true, true, true, true, true, true, true};
        public bool[] rightRowActiveCube = new bool[8] {true, true, true, true, true, true, true, true};
        public bool[] right2RowActiveCube = new bool[8] {true, true, true, true, true, true, true, true};
        public bool[] right3RowActiveCube = new bool[8] {true, true, true, true, true, true, true, true};
         
        GameObject _leftRow;
        GameObject _left2Row;
        GameObject _left3Row;
        GameObject _rightRow;
        GameObject _righ2Row;
        GameObject _right3Row;

        public void Start()
        {
            if (cubeRow != null)
            {
                //Spawn copy of main body
                //Left side
                _leftRow = Instantiate(cubeRow, transform);
                _leftRow.transform.Translate(1, 0, 0);
                _leftRow.name = "_leftRow";
                _leftRow.GetComponent<RowInit>().Init(leftRowActiveCube);
                _left2Row = Instantiate(cubeRow, transform);
                _left2Row.transform.Translate(2, 0, 0);
                _left2Row.name = "_leftRow2";
                _left2Row.GetComponent<RowInit>().Init(left2RowActiveCube);
                _left3Row = Instantiate(cubeRow, transform);
                _left3Row.transform.Translate(new Vector3(3, 0, 0));
                _left3Row.name = "_frontRow";
                _left3Row.GetComponent<RowInit>().Init(left3RowActiveCube);
                //Right side
                _rightRow = Instantiate(cubeRow, transform);
                _rightRow.transform.Translate(new Vector3(-1, 0, 0));
                _rightRow.name = "_rightRow";
                _rightRow.GetComponent<RowInit>().Init(rightRowActiveCube);
                _righ2Row = Instantiate(cubeRow, transform);
                _righ2Row.transform.Translate(new Vector3(-2, 0, 0));
                _righ2Row.name = "_righRow2";
                _righ2Row.GetComponent<RowInit>().Init(right2RowActiveCube); 
                _right3Row = Instantiate(cubeRow, transform);
                _right3Row.transform.Translate(new Vector3(-3, 0, 0));
                _right3Row.name = "_frontRow2";
                _right3Row.GetComponent<RowInit>().Init(right3RowActiveCube);
                 
            }
        }
    }
}