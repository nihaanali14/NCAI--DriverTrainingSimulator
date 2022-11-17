using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MapSelectionMenu : Menu<MapSelectionMenu>
{

    public GameObject[] Levels;
    public Button leftButton;
    public Button rightButton;
    public Button SelectButton;
    public Toggle VrController;
    public Toggle LogitecCotroller;
    public ScrollRect scrollView;
    private int currentLevelOnScreenNumber = 0;
    public float UnitMovement = 350;

    private DataManager _dataManager;


    float lerpDuration = 1;
    float startValue = 0;
    float endValue = 10;
    float valueToLerp;

    // Start is called before the first frame update
    void Start()
    {
        if (_dataManager == null)
        {
            _dataManager = Object.FindObjectOfType<DataManager>();
            _dataManager.Load();

            // Reset Controls Detail

            _dataManager.ControllerType = -1;
            _dataManager.CameraType = -1;

            UnitMovement = 1.0f / (Levels.Length-1);
            print(UnitMovement);

            print("Session::" + _dataManager.Session);
        }
        startValue = scrollView.horizontalNormalizedPosition;
        CheckLeftRightControls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckLeftRightControls()
    {
        if (currentLevelOnScreenNumber >= (Levels.Length-1))
        {
            
            rightButton.gameObject.SetActive(false);
        }
            
        
        if (currentLevelOnScreenNumber <= 0)
        {
            leftButton.gameObject.SetActive(false);
        }


        if (currentLevelOnScreenNumber > 0)
        {
            leftButton.gameObject.SetActive(true);
        }

        if (currentLevelOnScreenNumber < (Levels.Length-1))
        {
            rightButton.gameObject.SetActive(true);
        }

        if (_dataManager != null)
        {

            if (currentLevelOnScreenNumber <= _dataManager.CompletedLevels)
            {
                //print("Current Selected Level ::::" + currentLevelOnScreenNumber);
                //print("Completed Level are :::" + _dataManager.CompletedLevels);
                //SelectButton.gameObject.SetActive(true);
            }
            else
            {
                print("NOTTT SELECTABLE Level:::::: Completed levels are ::::" + _dataManager.CompletedLevels);
                //SelectButton.gameObject.SetActive(false);
            }
        }
    }

    public void LeftButton()
    {
        //if (currentLevelOnScreenNumber >= Levels.Length)
        //{
        //    leftButton.gameObject.SetActive(false);
        //}

        if (scrollView != null)
        {
            
            startValue = scrollView.horizontalNormalizedPosition;
            endValue = startValue - UnitMovement;
            //scrollView.horizontalNormalizedPosition -= UnitMovement;
            StartCoroutine(Lerp(leftButton));
            //scrollView.position = new Vector3(scrollView.position.x + UnitMovement,scrollView.position.y,scrollView.position.z);
            currentLevelOnScreenNumber--;
        }

        CheckLeftRightControls();
    }
    public void RightButton()
    {
        //if (currentLevelOnScreenNumber <= 0)
        //{
        //    rightButton.gameObject.SetActive(false);
        //}

        if (scrollView != null)
        {
            startValue = scrollView.horizontalNormalizedPosition;
            endValue = startValue + UnitMovement;
            //scrollView.horizontalNormalizedPosition += UnitMovement;
            StartCoroutine(Lerp(rightButton));
            //scrollView.position = new Vector3(scrollView.position.x - UnitMovement, scrollView.position.y, scrollView.position.z);
            currentLevelOnScreenNumber++;
        }

        CheckLeftRightControls();
    }
    public void SelectLevel()
    {
        if (_dataManager != null)
        {
            _dataManager.CurrentSelectedLevel = currentLevelOnScreenNumber;
            _dataManager.Save();
            //LoadingMenu.Open();            
            LevelLoader.LoadNextLevel();
            
        }
    }
    public void SelectLevel(int num)
    {
        if (_dataManager != null)
        {

            _dataManager.CurrentSelectedLevel = num;
            _dataManager.Save();
            if (num == 0 && _dataManager.Session < 1)
            {
                _dataManager.Session++;
                LoadingMenu.Open(); 
                LevelLoader.LoadLevel("OneTimeTutorial");   
              
            }
            else
            {
                _dataManager.Session++;
                LoadingMenu.Open();
                LevelLoader.LoadNextLevel();
                
            }//StartCoroutine(LevelLoader.LoadAsyncNextScene("CarSelection"));
        }
    }  
    void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void SubmitControlsDetail()
    {
        if (VrController.isOn)
        {
            _dataManager.CameraType = 0;
        }
        else {
            _dataManager.CameraType = 1;
        }

        if (LogitecCotroller.isOn)
        {
            _dataManager.ControllerType = 0;
        }
        else
        {
            _dataManager.ControllerType = 1;
        }

        _dataManager.Save();


        print("Camera Type::: " + _dataManager.CameraType + " Controller Type::: "+_dataManager.ControllerType); 
    }
    
    IEnumerator Lerp(Button button)
    {
        float timeElapsed = 0;
        button.interactable = false;
        while (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            scrollView.horizontalNormalizedPosition = valueToLerp;
            yield return null;
        }

        valueToLerp = endValue;
        button.interactable = true;
    }
}
