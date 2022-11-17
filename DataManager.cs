using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private SaveData _saveData;
    //ram
   // private SessionData _sessionData;
    private JsonSaver _jsonSaver;
    public  static DataManager _instance;
    public int currentSelectedLevel, completedLevels, currentSelectedPlayer;
    public int currentSelectedCategory;
    public int currentSelectedSubCategory;
    public int currentLesson;

    // public properties to set and get values from the SaveData object
    public float MasterVolume
    {
        get { return _saveData.sessionData.masterVolume; }
        set { _saveData.sessionData.masterVolume = value; }
    }

   
    public float MusicVolume
    {
        get { return _saveData.sessionData.musicVolume; }
        set { _saveData.sessionData.musicVolume = value; }
    }

    public int CompletedLevels
    {
        get
        {
            return PlayerPrefs.GetInt("completedLevels");
        }
        set
        {
            PlayerPrefs.SetInt("completedLevels", value);
            PlayerPrefs.Save();
        }
    }

    
    public int CurrentSelectedPlayer
    {
        get
        {
            return PlayerPrefs.GetInt("currentSelectedPlayer");
        }
        set
        {
            PlayerPrefs.SetInt("currentSelectedPlayer", value);
            PlayerPrefs.Save();
        }
    }

    public int CurrentSelectedLevel
    {
        get 
        {
            return PlayerPrefs.GetInt("currentSelectedLevel"); 
        }
        set 
        {
            PlayerPrefs.SetInt("currentSelectedLevel", value);
            PlayerPrefs.Save();
        }
    }
    //ram
    public int noOfLevels = 10;
    public int noOfInstructions = 10;
    public  static int[,] LvlInstruction;
   public   void LoadArrayData()
    {
        LvlInstruction = new int[noOfLevels, noOfInstructions];
     //  UnityEngine.Debug.Log("Load Data "+ " currentLevelNo " + noOfLevels + " instruction " + noOfInstructions);
        for (int c = 0; c < noOfLevels; c++)
        {
            for (int d = 0; d <noOfInstructions; d++)
            {
                //  UnityEngine.Debug.Log( "c "+   c +  "d "+ d);
                //result[c, d] = PlayerPrefs.GetInt("_Mode_" + c + "_Level_" + d, 0);
                LvlInstruction[c, d] = PlayerPrefs.GetInt("level" + c + "instruction" + d, 0);
               // LvlInstruction.Debug.Log(result[c, d] + "c " + "d ");
            }
       
        }
    }
   public  void SaveArrayData() 
    {
        for (int c = 0; c < noOfLevels; c++)
        {
            for (int d = 0; d < noOfInstructions; d++)
            {
                
                PlayerPrefs.SetInt("level" + c + "instruction" + d, LvlInstruction[c, d]);
                PlayerPrefs.Save();

            }
        }

    } 
   

  

    private string _currentLevelNoPrefKey = "CurrentLevelNo";
    public int CurrentLevelNo
    {
        get
        {
            return PlayerPrefs.GetInt(_currentLevelNoPrefKey, 0);
        }
        set
        {
            PlayerPrefs.SetInt(_currentLevelNoPrefKey, value);
            PlayerPrefs.Save();
        }
    }


    public int CurrentSelectedCategory
    {
        get { return currentSelectedCategory; }
        set {currentSelectedCategory = value; }
    }

    public int CurrentSelectedSubCategory
    {
        get { return currentSelectedSubCategory; }
        set { currentSelectedSubCategory = value; }
    }


    public int Session
    {
        get { return _saveData.sessionData.session; }
        set { _saveData.sessionData.session = value; }
    }

    public int CameraType
    {
        get { return _saveData.sessionData.cameraType; }
        set { _saveData.sessionData.cameraType = value; }
    }

    public int ControllerType
    {
        get { return _saveData.sessionData.controllerType; }
        set { _saveData.sessionData.controllerType = value; }
    }

    //user data getters setters

    public int playerId
    {
        get { return _saveData.userData.Player_id; }
        set { _saveData.userData.Player_id = value; }
    
    }

    //public string PlayerName
    //{
    //    get { return _saveData.userData.playerName; }
    //    set { _saveData.userData.playerName = value; }
    //}

    public int PlayerAge
    {
        get { return _saveData.userData.age; }
        set { _saveData.userData.age = value; }
    }

    public int drivingExperience
    {
        get { return _saveData.userData.driving_experience; }
        set { _saveData.userData.driving_experience = value; }
    }

    

    public int right_way
    {
        get { return _saveData.userDrivingData.right_way; }
        set { _saveData.userDrivingData.right_way = value; }
    }

    public int acceleration_smoothness
    {
        get { return _saveData.userDrivingData.acceleration_smoothness; }
        set { _saveData.userDrivingData.acceleration_smoothness = value; }
    }

    

    public int sudden_brakes
    {
        get { return _saveData.userDrivingData.sudden_brakes; }
        set { _saveData.userDrivingData.sudden_brakes = value; }
    }

    public int steering_smoothness
    {
        get { return _saveData.userDrivingData.steering_smoothness; }
        set { _saveData.userDrivingData.steering_smoothness = value; }
    }

    public int parking
    {
        get { return _saveData.userDrivingData.parking; }
        set { _saveData.userDrivingData.parking = value; }
    }

    public int no_of_hits
    {
        get { return _saveData.userDrivingData.no_of_hits; }
        set { _saveData.userDrivingData.no_of_hits = value; }
    }

    // initialize SaveData and JsonSaver objects
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        _saveData = new SaveData();
        _jsonSaver = new JsonSaver();
    }
    // save the data using the JsonSaver
    public void Save()
    {
        _jsonSaver.Save(_saveData);
     }

    //aimen
    

    // load the data using the JsonSaver
    public void Load()
    {
        _jsonSaver.Load(_saveData);
    }

    //aimen
    

  



}

