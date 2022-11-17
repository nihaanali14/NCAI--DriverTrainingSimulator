using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

[Serializable]
public class UserDrivingData 
{
    
    //count of keeping right way
    public int right_way;

    public int acceleration_smoothness;
    
    public int sudden_brakes;

    //store how many times user maintained to steer smoothly
    public int steering_smoothness;
    public int parking;
    public int no_of_hits;

    


    //Constructor
    public UserDrivingData()
    {
        
        
        right_way = 1;
        acceleration_smoothness = 0;
        
        sudden_brakes = 0;
        steering_smoothness = 0;
        parking = 0;
        no_of_hits = 0;
        
        

    }

    

    public UserDrivingData(int _rightWay, int _acc, int _brakes, int _steering, int _parking, int _hits)
    {
        

        right_way = _rightWay;
        acceleration_smoothness = _acc;
        
        sudden_brakes = _brakes;
        steering_smoothness = _steering;
        parking = _parking;
        no_of_hits = _hits;
        
    }

    

    //getter to return specific user's data 
    public UserData getUser(int id, string UserName)
    {
        UserData temp = new UserData(id, UserName);
        return temp;
    }
    
    public UserData getUser(int id)
    {
        UserData temp = new UserData(id);
        return temp;
       
    }
    
}


public class UserData {

    public int Player_id = 0;
    public static string playerName;
    private readonly string defaultPlayerName = "Player";
    public int age;
    public int driving_experience;
    public string hashValue;

    public UserData()
    {
        Player_id = 0;
        playerName = defaultPlayerName;
        age = 0;
        driving_experience = 0;
        hashValue = String.Empty;
    }

    public UserData(int id)
    {
        Player_id = id;
        playerName = defaultPlayerName;
        age = 0;
        driving_experience = 0;
        hashValue = String.Empty;
    }

    public UserData(int id,string _name)
    {
        Player_id = id;
        //this.playerName = _name;
        age = 0;
        driving_experience = 0;
        hashValue = String.Empty;
    }

}
