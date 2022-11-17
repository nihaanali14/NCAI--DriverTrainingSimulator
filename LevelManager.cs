using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Playables;
using UnityEngine.SpatialTracking;
public class LevelManager : MonoBehaviour
{

    [Header("Hierarchy of Levels")]
    public Levels[] levels;
    public GameObject[] myLevels;

    public GameObject levelCompletionObject;
    //public myLevels[] mylvl;

    #region Private Variables

    private Levels currentLevel;
    //type of the nature of the task
    public static int levelsCompleted;   
    private Task nextTask;
    private float time = 0.0f;
    internal int taskInvokedCount = 0;
    private DataManager _dataManager;
    private PlayableDirector currentPlayableDirector;

    private GameObject animationCamera;

    #endregion

   
    #region Unity cycle funtions
    /// <summary>
    ///  
    /// </summary>

    void Awake()
    {


        /// Get Data past data of player completed levels
        /// Get level data from simulation manager list of levels
        /// setup currentLevel Data to hold reference of currently loaded scene data
        /// spawn levels objects and player
        /// play animation of current level
        /// wait until the length of animation
        /// on animation end setup user controll for driving


        _dataManager = GameObject.FindObjectOfType<DataManager>();
        if (_dataManager != null)
        {
            //_dataManager.Load();
        }



    }

    void Start()
    {


        SetUpLevel();



    }

    void Update()
    {
    //    print("CURRENT LEVEL " + _dataManager.CurrentSelectedLevel);

    }

    #endregion

   
    
    private void SetUpLevel()
    {

        try
        {


            if (_dataManager != null)
            {
               // print("CURRENT LEVEL " + _dataManager.CurrentSelectedLevel);
                currentLevel = levels[_dataManager.CurrentSelectedLevel];
                // Dummy Object
                //currentLevel.DummyObject.SetActive(true);
                myLevels[_dataManager.CurrentSelectedLevel].SetActive(true);
                // currentPlayableDirector = currentLevel.playableDirector;
                //  currentPlayableDirector.stopped += CurrentPlayableDirector_stopped;
                // Instantiate(myLevels[_dataManager.CurrentSelectedLevel], myLevels[_dataManager.CurrentSelectedLevel].transform.position, myLevels[_dataManager.CurrentSelectedLevel].transform.rotation);

            }
            else
            {

            }


            // Enable Animation Object
            if (currentLevel._animObject != null)
            {
                currentLevel._animObject.SetActive(true);
            }


            
            // Player spawing on position
            GameObject currentPlayer = SimulationManager.Instance.GetCurrentPlayer();
            currentPlayer.transform.position = currentLevel.spawnPoint.position;
            currentPlayer.transform.rotation = currentLevel.spawnPoint.rotation;
            currentPlayer.SetActive(true);
           // currentPlayableDirector.Play();
          //ram   animationCamera = SimulationManager.Instance.animationCamera.gameObject;
            //aimen
            //SimulationManager.Instance.rcc_Camera.gameObject.SetActive(true);
           // ram  animationCamera.SetActive(true);
            // ram animationCamera.GetComponent<TrackedPoseDriver>().enabled = false;
      

        }
        catch (Exception ex)
        {
            Debug.Log("SETTING UP SCENE DATA :::: LEVEL MANAGER ::: " + ex);
        }



    }

    public Levels GetCurrentLevel()
    {
        return currentLevel;
    }

    private void CurrentPlayableDirector_stopped(PlayableDirector obj)
    {
        // switch camera from cinemachien to player control

        if (animationCamera.activeInHierarchy)
        {
            animationCamera.SetActive(false);
            SimulationManager.Instance.rcc_Camera.gameObject.SetActive(true);
            //if (_dataManager.CameraType == 0)
            //{
            //    SimulationManager.Instance.VrCamera.SetActive(true);
            //}
            //else
            //{
            //    SimulationManager.Instance.simpleCamera.SetActive(true);
            //}

            //aimen 
            SimulationManager.Instance.GetCurrentCamera().SetActive(true);
        }
    }

    private void OnDisable()
    {
       //ram  currentPlayableDirector.stopped -= CurrentPlayableDirector_stopped;   
    }

}






