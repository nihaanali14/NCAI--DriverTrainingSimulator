using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfileManager : MonoBehaviour
{
    public UserData userData;
    

    int id = 0;

    public UserProfileManager()
    {
        id = userData.Player_id;
        
    }

    //public void RecordOfUser()
    //{
    //    userData.getUser(id);
    //}
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
