using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : Menu<HUD>
{
    public GameObject MainObjectAnimation;
    public GameObject[] LevelsAnimObject;
    public GameObject CurrentAnimObject;
    public Animator currentAnim;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableAnimObject(int level)
    {
        
       CurrentAnimObject =  LevelsAnimObject[level];
       currentAnim = CurrentAnimObject.GetComponent<Animator>();
        CurrentAnimObject.SetActive(true);
    }
    public void PlayAnimaitonClip(string animClipName)
    {
        if (currentAnim != null)
        {
            currentAnim.Play(animClipName);
        }
    }
    public void DisableCurrentObject()
    {
        if (CurrentAnimObject != null)
        {
            CurrentAnimObject.SetActive(false);
        }
        else {
        
        }
    }
    public void DisableParentAnimationObject()
    {
        if (MainObjectAnimation != null)
        {
            MainObjectAnimation.SetActive(false);
        }
    }




}
