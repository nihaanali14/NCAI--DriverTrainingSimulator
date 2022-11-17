 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

// controls the MainMenu screen
public class MainMenu : Menu<MainMenu>
    {
        // delay before we play the game
        [SerializeField]
        private float _playDelay = 15f;

        // reference to transition prefab
        [SerializeField]
        private TransitionFader startTransitionPrefab;

        // reference to DataManager
        private DataManager _dataManager;

        // reference to UI.InputField for PlayerName
        [SerializeField]
        private InputField _inputField;

        Transform temp;
        public GameObject mark, mark1, Controltxt;
        SteamVR_Events.Action deviceConnectedAction;

    protected override void Awake()
		{
            base.Awake();
            _dataManager = Object.FindObjectOfType<DataManager>();
           
    }

        

    private void Start()
		{
        if (LogitechGSDK.LogiIsConnected(0))
        {
            mark.GetComponent<Image>().sprite = Resources.Load<Sprite>("TICK");
        }
        else
        {
            mark.GetComponent<Image>().sprite = Resources.Load<Sprite>("TICK");
        }
        if (SteamVR.isVRConnected)
            mark1.GetComponent<Image>().sprite = Resources.Load<Sprite>("TICK");
        else
            mark1.GetComponent<Image>().sprite = Resources.Load<Sprite>("CROSS");

        InvokeRepeating("CheckControls", 0f, 5f);
    }
      
    private  void CheckControls()
    {
     /*  if (!LogitechGSDK.LogiIsConnected(0) || !SteamVR_RenderModel.isDeviceConnected)
          Controltxt.transform.GetComponent<Text>().text = "CONNECT YOUR DEVICE";
       else
       {

        Debug.Log("check controls ");*/

        Controltxt.transform.GetComponent<Text>().text = "CONNECTED";
        CancelInvoke();
        UnityEngine.Debug.Log("check controls cancelled");
      //  yield return new WaitForSeconds(1);
        StartCoroutine(OnPlayPressedRoutine());
     // }
    }


    // load the saved data and retrieve the PlayerName
    private void LoadData()
        {
            if (_dataManager != null && _inputField != null)
            {
                _dataManager.Load();
            }
        }

        // save the PlayerName as we type into the InputField
        public void OnPlayerNameValueChanged(string name)
        {
            //if (_dataManager != null)
            //{
            //    _dataManager.PlayerName = name;
            //}
        }

        // save the data to disk when done editing
        public void OnPlayerNameEndEdit()
        {
            if (_dataManager != null)
            {
                _dataManager.Save();
            }
        }

        // launch the first game level
		public void OnPlayPressed()
        {
            CategoriesMenu.Open();
        
        //MapSelectionMenu.Open();

    }
        public void OnBTDPressed()
        {
            BasicDrivingMenu.Open();
        }
         public void onBasicControlPressed()
         {
            LoadingMenu.Open();
            LevelLoader.LoadNextLevel();
         }
        // start the transition and play the first level
        private IEnumerator OnPlayPressedRoutine()
        {
            TransitionFader.PlayTransition(startTransitionPrefab);
          //ram  LevelLoader.LoadNextLevel();
            yield return new WaitForSeconds(_playDelay);
        CategoriesMenu.Open();
       // ram  GameMenu.Open();
        }

        // open the SettingsMenu
        public void OnSettingsPressed()
        {

            SettingsMenu.Open();
        }

        // open the Credits Screen
        public void OnCreditsPressed()
        {
            CreditsScreen.Open();
        }

        // quit the application
        public override void OnBackPressed()
        {
            Application.Quit();
        }

    }
