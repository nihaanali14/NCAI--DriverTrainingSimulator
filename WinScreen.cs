using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    // shown when player completes the level
    public class WinScreen : Menu<WinScreen>
    {

    public MaskableGraphic[] graphicsToFade;
    [SerializeField] private ScreenFader screenFader;
    [SerializeField] private Image faderObject;


    public void Start()
    {
        if (screenFader != null)
        {
            screenFader = GetComponent<ScreenFader>();
        }
    }


    private void OnDisable()
    {
        //if (faderObject.gameObject.activeInHierarchy)
        //{
        //    screenFader.FadeOn();
        //    Color tempColor = new Color(0, 0, 0, 0);
        //    faderObject.color = tempColor;
        //    faderObject.gameObject.SetActive(true);
        //}
    }

    private void OnEnable()
    {
        if (faderObject.gameObject.activeInHierarchy)
        {
            faderObject.gameObject.SetActive(false);
            screenFader.FadeOn();
            Color tempColor = new Color(0, 0, 0, 255);
            faderObject.color = tempColor;
            
        }
    }


    // advance to the next level
    public void OnNextLevelPressed()
        {
        EnableFaderObjectAndFade();
        //LoadingMenu.Open();
        //SimulationManager.Instance.CheckForNext();
        //LevelLoader.LoadNextLevel();
        }

        // restart the current level
        public void OnRestartPressed()
        {
            base.OnBackPressed();
            LevelLoader.ReloadLevel();
        }

        // return to MainMenu scene
        public void OnMainMenuPressed()
        {
            LevelLoader.LoadMainMenuLevel();
            MainMenu.Open();
        }

    public void EnableFaderObjectAndFade()
    {
        if (faderObject != null)
        {
            faderObject.gameObject.SetActive(true);
            StartCoroutine(FadeAndLoadRoutine());
        }
    }

    private IEnumerator FadeAndLoadRoutine()
    {
        // wait for a delay
        yield return new WaitForSeconds(1);


        // fade off
        if (!faderObject.gameObject.activeInHierarchy)
        {
            faderObject.gameObject.SetActive(true);
            Color tempColor = new Color(0, 0, 0, 255);
            faderObject.color = tempColor;
        }
        screenFader.FadeOff();
        print("fadding offf");
        
        // wait for fade to complete
        yield return new WaitForSeconds(screenFader.FadeOffDuration);
        SimulationManager.Instance.CheckForNext();
    }

    private void Fade(float targetAlpha, float duration)
    {
        foreach (MaskableGraphic graphic in graphicsToFade)
        {
            if (graphic != null)
            {
                graphic.CrossFadeAlpha(targetAlpha, duration, true);
            }
        }
    }

}

