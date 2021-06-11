using System.Collections;
using System.Collections.Generic;
using BlockRuner;
using UnityEngine;
using UnityEngine.UI;
using SimpleInputNamespace;

namespace BlockRuner.Player
{ 
public class PlayerManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI levelName; 
    public TMPro.TextMeshProUGUI scoreText; 
    public Transform startMouve;
    public Transform finishMouve;
    [Range(0,100)]
    public float speed;
    public float muveDelay = 5f;
    bool _canMove = false;
    bool _fallBack = false;
    public float falBackTime = 1f;
    float _falBackTimer = 0;
    [Range(0, 100)]
    public float turnDelay = 0.5f;//block any turn to this valua 0.5 this is half secon aproximetly;
    bool _canTurn = true;
    float _timeTurnBlock = 0;
    Vector3 _movePos;
    float _distanse = 0;
    float _timeStartDelay = 0;
    Rigidbody _rigB;
    int _score = 0;
    AudioSource _asr;
    private GameManager gm;
    private bool _waitToNext = false;

    // Start is called before the first frame update
    void Start()
    {  
        _rigB =  GetComponent<Rigidbody>();
        _distanse = finishMouve.position.y;
        _movePos = startMouve.position;
        scoreText.text = _score.ToString();
        _asr = GetComponent<AudioSource>();  
        gm = GameManager.Instanse;
        levelName = GameObject.Find("Level name").GetComponent<TMPro.TextMeshProUGUI>();
        levelName.text = "Level " + UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        gm.InputUI.SetActive(false); 
     }
 
    //Can use lerp Motion or Animation hear as simple as posible
    //Two turn function to call from button click
    public void TurnLeft()
    {
        if (_canTurn)
        { 
           transform.Rotate(Vector3.up, 90);
            _canTurn = false;//Block turn to avoid fast spam on button and change turn angle
        }
    } 
    public void TurnRight()
    {
        if (_canTurn)
        {
            transform.Rotate(Vector3.up, -90);
            _canTurn = false;//Block turn to avoid fast spam on button and change turn angle
        }
    }
    void MuvePlayer()
    {
        if (!_waitToNext &&_canMove && !_fallBack)
        { 
            float zDeltaMuve = _distanse / ((_distanse / speed) / Time.deltaTime);
            _movePos = new Vector3(_movePos.x, _movePos.y, _movePos.z + zDeltaMuve);
            _score += 1;
            transform.position = _movePos;
        }
        if (_fallBack)
        {
            float zDeltaMuve = _distanse / ((_distanse / speed) / Time.deltaTime);
            _movePos = new Vector3(_movePos.x, _movePos.y, _movePos.z - zDeltaMuve);
            transform.position = _movePos;
        }
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = _score.ToString();
        
        if (!_canMove)
        {
            _timeStartDelay += Time.deltaTime;
            if(_timeStartDelay >= muveDelay)
            {
                _timeStartDelay = 0;
                _canMove = true;
                gm.InputUI.SetActive(true); 
            }
        }
        if (!_canTurn)
        {
            _timeTurnBlock += Time.deltaTime;
            if(_timeTurnBlock >= turnDelay)
            {
                _canTurn = true;
                _timeTurnBlock = 0;
                //reset value to next turn
            }
        }
        if (_fallBack)
        {
            _falBackTimer += Time.deltaTime;
            if(_falBackTimer >= falBackTime)
            {
                _fallBack = false;
                _falBackTimer = 0;
            }
        }

        if (_waitToNext)
        {
            _timeStartDelay += Time.deltaTime;
            if (_timeStartDelay >= muveDelay)
            {  
                int next = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
                if(next > UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings) ToMenu();
                else
                {
                    gm.Save(next);
                    gm.LoadLevel(next);
                }
            }
        }

        MuvePlayer(); //Call function to muve play from A to B point by speed from settings
        
        RotateTroughtSelectable();
        
    }

    void RotateTroughtSelectable()
    { 
        //Debug.Log("input x is ="+ gm.Input.Value.x);
        if( gm.Input.Value.x == 1f )
        {
            TurnLeft();
        }
        if( gm.Input.Value.x  == -1f )
        {
            TurnRight();
        }
    }
    private void OnTriggerEnter(Collider other)    
    {
        if(other.tag == "Cube")
        {
            _asr.Play();
            _fallBack = true;
            _score -= 10; 
        }
        if(other.tag == "Finish")
        { 
            _waitToNext = true;
            gm.InputUI.SetActive(false); 
        }
    }
    public void ToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

}
