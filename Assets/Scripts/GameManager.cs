using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleInputNamespace;
using UnityEngine.PlayerLoop;

namespace  BlockRuner
{
    public delegate void Opened();

    public delegate void Closed(); 
    
    public class GameManager : MonoBehaviour
    {
        private int playerSave ;
        private AxisInputUIArrows input;
        public GameObject uiInput;
        private GameObject inputUI;
        private static GameManager instance; 
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                if (instance != this)
                {
                    Destroy(gameObject);
                    return;
                    
                }
            }

            UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            if (scene.buildIndex == 0) Init(); 
        } 

        /// <summary>
        /// Singletone part realisation one and only one
        /// </summary>
        public static GameManager Instanse 
        {
            get
            {
                if (instance == null)
                {
                    GameObject gm = GameObject.FindGameObjectWithTag("GM");
                    if (gm) { instance = gm.GetComponent<GameManager>(); }
                }  
                Debug.Log("Instanse GM =" + instance.name);
                return instance;
            }
        } 
        public  AxisInputUIArrows Input =>input; 
         
        public GameObject InputUI => inputUI;
        public int OpenedLevel => playerSave; 
        
        
        // Start is called before the first frame update
        void Init()
        {
            //Spawn ui input
            inputUI =  Instantiate(uiInput);
            DontDestroyOnLoad(inputUI); 
            //Set AxisInputUIArrows input to call from instanse 
            if(input == null) input = GameObject.FindWithTag("Input").GetComponentInChildren<AxisInputUIArrows>();
            Debug.Log(input);
            //IF tihs is menu make UI input is invisible
            InputUI.SetActive(false);
            
            if (PlayerPrefs.HasKey("openedLevel"))
            {
                if (PlayerPrefs.GetInt("openedLevel") != 0)
                {
                    playerSave = PlayerPrefs.GetInt("openedLevel");
                }
            }
            else
            {
                playerSave = 1;//open on start firs level
                PlayerPrefs.SetInt("openedLevel",playerSave);
                //And save this result
                PlayerPrefs.Save();
            }
            Debug.Log("GM INIT \n OpenedLevel= "+GameManager.Instanse.OpenedLevel);
        }

        public void Save(int levelID)
        {
            playerSave = levelID; //open on start firs level
            PlayerPrefs.SetInt("openedLevel",playerSave);
            //And save this result
            PlayerPrefs.Save();
        }
        
        // Update is called once per frame
        void Update()
        {
            
        }
        
        
        /// <summary>
        /// Load level from build scene in list  
        /// </summary>
        /// <param name="levelId">From scene in build list id, menu is 1 always 0 is start</param>
        public void LoadLevel(int levelId)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelId);
        }
 
    }

}
