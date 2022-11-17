using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;
public class Mediator : Menu<Mediator>
{
    public static Mediator _instance;

    public Text txt;
    
    public GameObject virtualCamera;
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
      
    }

    void Update()
    {
        txt.text = CurvedUI.CurvedUIRaycaster.test;
    }
    public void SelectLevel(int lvl)
    {

    }
    public void CheckCurrentCategory(string name)
    {
      //  UnityEngine.Debug.Log("object name " + name);

        if (!CurvedUI.CurvedUIRaycaster.stopgaze)
        {
            if (name == "basic dt")
            {
                BasicDrivingMenu.Open();


                // DataManager._instance.CurrentSelectedCategory = 1;
                //  DataManager._instance.CurrentSelectedSubCategory = 1;
            }

            else if (name == "basiccontrols")
            {

                //Camera.main.transform.GetComponent<CinemachineBrain>().enabled = true;
                // virtualCamera.SetActive(true);
                BasicControlsMenu.Open();

            }
            else if (name == "cockpitdrill")
                CockpitDrillMenu.Open();
            else if (name == "Right")
                LessonsMenu.instance.OnRightClick();
            else if (name == "Left")
            {
                UnityEngine.Debug.Log("left clicked ");
                LessonsMenu.instance.OnLeftClick();

            }
            else if (name == "traininglessons")
                LessonsMenu.Open();
            else if (name == "footcontrols" || name == "handcontrols" || name == "dashboard")
            {
                VideosMenu.Open();
                PlayerPrefs.SetString("videoName", name);
                PlayerPrefs.Save();
                MenuManager.isPlayVideo = true;
            }

            else if(name=="Test")
            {
                SceneManager.LoadScene("CarController");
            }

            /*else if (name == "lvl1" || name == "lvl2" || name == "lvl3" || name == "lvl4" || name == "lvl5" || name == "lvl6" || name == "lvl7" || name == "lvl8" || name == "lvl9" || name == "lvl10")
            {
                VideosMenu.Open();
                PlayerPrefs.SetString("videoName", name);
                PlayerPrefs.Save();
                MenuManager.isPlayVideo = true;
            }*/
            else if (name == "Start")
                ControlsChecking.Open();
            else if (name == "Right")
                LessonsMenu.instance.OnRightClick();
            else if (name == "Left")
            {
                UnityEngine.Debug.Log("left clicked ");
                LessonsMenu.instance.OnLeftClick();

            }
            else if (name == "Back")
            {
                MenuManager.Instance.CloseMenu();
                VideosMenu.Instance.StopVideo();
            }
            }
    }


    public void OnBackPressed()
    {
        MenuManager.Instance.CloseMenu();
    }
}
