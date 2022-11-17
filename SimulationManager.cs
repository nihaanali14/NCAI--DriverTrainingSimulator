using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum SimulationState { Setup, Running, Stop }


public class SimulationManager : MonoBehaviour
{

    public static SimulationManager Instance;


    // For Simulation State Control
    [Header("Simulation State")]
    [Tooltip("Used for checking either simulation is running or stop.")]
    public SimulationState simulationStateManager;

    #region Manager variables
    [Header("Managers")]
    [Tooltip("Used for managing levels.")]
    public LevelManager levelManager;
    [Tooltip("Used for saving user's data e.g how much levels have been completed.")]
    public UserProfileManager userProfileManager;
    [Tooltip("Used for managing sound.")]
    public SoundManager soundManager;
    public Observer observer;
    public UserDataRecording userDataRecording;
    [Tooltip("Used for saving, loading and exporting data.")]
    [HideInInspector]
    public DataManager dataManager;
    [HideInInspector]
    

    #endregion

    
    public GameObject[] players;
    private GameObject currentSelectedPlayer;
    public RCC_Camera rcc_Camera;
    //public GameObject simpleCamera;
    //public GameObject VrCamera;
    public Camera animationCamera;


    public GameObject[] cameras;
    private GameObject currentSelectedCamera;

    

    

    #region Unity cycle functions
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        dataManager = Object.FindObjectOfType<DataManager>();
        dataManager.Load();

        //print("After loading level the value of current level is "+ dataManager.CurrentSelectedLevel);

        HUD.Open();
       //ram currentSelectedPlayer = players[dataManager.CurrentSelectedPlayer];
      // ram observer.currentCarObject = currentSelectedPlayer.GetComponent<RCC_CarControllerV3>();
      // ram observer.vehicleDisplay = currentSelectedPlayer.GetComponent<VehicleDisplayViewer>();
     //ram   levelManager.SetUpLevel();
       // ram rcc_Camera.playerCar = currentSelectedPlayer.GetComponent<RCC_CarControllerV3>();


        currentSelectedCamera = cameras[dataManager.CameraType];
        

        

        //StartCoroutine(EnableUIAnimaiton());

    }  
    void Start()
    {
        simulationStateManager = SimulationState.Setup;
        // On Last Line 
        

        simulationStateManager = SimulationState.Running;
    }  
    void Update()
    {
        if (this.simulationStateManager == SimulationState.Running)
        {
            // Do Somthing 
        }
        else
        {
            // do nothing;
            return;
        }




    }
    private void FixedUpdate()
    {
     /*ram   if (currentSelectedPlayer.GetComponent<RCC_CarControllerV3>().speed < 5)
        {
            SimulationManager.Instance.GetCurrentPlayer().GetComponent<RCC_CarControllerV3>().StopReverseGearShift = false;
        }*/
    }
    void OnDestroy()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
    }
    void OnDisable()
    {
        if (Instance != null)
        {
            Destroy(Instance);

        }
    }
    void OnApplicationQuit()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
    }
    #endregion
    public void CheckForNext()
    {
        ///
        /// Need to reset this area of code for modulation of level loading control
        ///
        //levelManager.NextTask();

        dataManager.CurrentSelectedLevel = dataManager.CurrentSelectedLevel + 1;

        if (dataManager.CompletedLevels < dataManager.CurrentSelectedLevel)
        {
            dataManager.CompletedLevels++;
        }

        
        //dataManager.CurrentSelectedLevel = dataManager.CompletedLevels;

        //print("On Completing level before saving current Level Value is ::" + dataManager.CurrentSelectedLevel);
        
        dataManager.Save();
        
        if (dataManager.CurrentSelectedLevel <= levelManager.levels.Length - 1)
        {
            
            dataManager.Session++;
            dataManager.Save();

            LevelLoader.LoadLevel("CarController");
            //LoadScene("CarController");
        }
        else
        {
            LessonCompleted.Open();
        }

    }   
    public GameObject GetCurrentPlayer()
    {
       return players[dataManager.CurrentSelectedPlayer];
    }


    public GameObject GetCurrentCamera()
    {
        return cameras[dataManager.CameraType];
    }
    
    

    void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    IEnumerator EnableUIAnimaiton()
    {
        yield return new WaitForSeconds(2);
        if ((HUD.Instance.LevelsAnimObject.Length - 1) >= dataManager.CurrentSelectedLevel)
        {
            if (HUD.Instance.LevelsAnimObject[dataManager.CurrentSelectedLevel] != null)
            {
                //print("Current seleceted level " + dataManager.CurrentSelectedLevel);
                HUD.Instance.EnableAnimObject(dataManager.CurrentSelectedLevel);
            }
        }

    }




}
