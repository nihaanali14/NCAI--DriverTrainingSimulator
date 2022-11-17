using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SpatialTracking;
using UnityEngine.Playables;
public class OneTimeTutorialManager : MonoBehaviour
{


    public GameObject CameraForVR;
    public PlayableDirector playableDirector;
    [SerializeField]
    private AudioSource InstAudio;
    [SerializeField]
    private Text InstText;

    public InstructionSet[] instructionSets;

    // Start is called before the first frame update
    void Start()
    {
        playableDirector.stopped += OnStopTimeLinePlaying;
        // Add Pose Tracking to camera object       
        // check the relation transform
        // set traking type to rotation only
        // Disable the TDP component
        //CameraForVR.AddComponent<TrackedPoseDriver>().UseRelativeTransform = true;
        //CameraForVR.GetComponent<TrackedPoseDriver>().trackingType = TrackedPoseDriver.TrackingType.RotationOnly;
        //CameraForVR.GetComponent<TrackedPoseDriver>().enabled = false;
        // Open HUD Canvas to remove Loading Screen
        HUD.Open();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        playableDirector.stopped -= OnStopTimeLinePlaying;
    }

    public void PlayInstAudio(int num)
    {
        InstAudio.PlayOneShot(instructionSets[num].audioEng);
    }

    public void ShowInstText(int num)
    {
        //InstText.text = instructionSets[num].instText;
    }

    public void ShowInstrution(int num)
    {
        object[] param = new object[1] { num };
        StartCoroutine("ShowInstruction",param);
    }

    IEnumerator ShowInstruction(object[] param)
    {
        int InstNum = (int)param[0];
        ShowInstText(InstNum);
        yield return new WaitForSeconds(0.15f);
        PlayInstAudio(InstNum);
    }
    void OnStopTimeLinePlaying(PlayableDirector obj)
    {
        // Enable Camera Tracing
        LoadingMenu.Open();
        LevelLoader.LoadLevel("CarController");
        //CameraForVR.GetComponent<TrackedPoseDriver>().enabled = true;
    }

}
[System.Serializable]
public class InstructionSet 
{
    public AudioClip audioEng;
    public string instText;
}
