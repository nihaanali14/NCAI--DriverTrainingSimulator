using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class SessionData 
{
    // floats to store sound volume levels
    public float masterVolume;
    public float musicVolume;

    // hash value calculated from the contents of SaveData
    public string hashValue;
    public int completedLevels;
    public int currentSelectedPlayer;
   // public int currentSelectedLevel;
    public int currentSelectedCategory;
    public int currentSelectedSubCategory;
    public int session;
    public int controllerType;
    public int cameraType;


    //Constructor
    public SessionData()
    {

        masterVolume = 0f;
        musicVolume = 0f;
        hashValue = String.Empty;
        completedLevels = 0;
        currentSelectedPlayer = 0;
        //currentSelectedLevel = 0;
        currentSelectedCategory = 0;
        currentSelectedSubCategory = 0;
        session = 0;
        controllerType = 0; //0
        cameraType = 0;
    }
}
