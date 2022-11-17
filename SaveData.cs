using System.Collections;
using System.Collections.Generic;
using System;


// to convert to JSON, the class must be tagged with System.Serializable
[Serializable]
public class SaveData
{
    public UserData userData;
    public SessionData sessionData;
    public UserDrivingData userDrivingData;
    public SaveData()
    {
        userData = new UserData();
        sessionData = new SessionData();
        userDrivingData = new UserDrivingData();
    }

}

