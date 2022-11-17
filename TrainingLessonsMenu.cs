using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
public class TrainingLessonsMenu : Menu<TrainingLessonsMenu>
{
    // Start is called before the first frame update
   // public ScrollRect scroll;
    public bool isRight;
    public  bool isLeft;
    private int speed = 2;
    public Transform rect;
  //  public static  TrainingLessonsMenu instance;
    Vector3 temp;
    void Awake()
    {
      //  instance=this;
       
    }
    void Start()
    {
        isRight = false;
        isLeft = false;
        temp = rect.transform.localPosition;
        UnityEngine.Debug.Log("temp " + temp);
    }

    // Update is called once per frame
    void Update()
    {

       
        if (isRight)
        {

            if (temp.x <=785)
            {
                temp.x += 50 * Time.deltaTime;
                rect.transform.localPosition = temp;
                temp = rect.transform.localPosition;
                Invoke("StopMovement", 2f);
            }
            
            /*float contentWidth= scroll.content.sizeDelta.x;
            float contentShift = speed * 5 * Time.deltaTime;
            scroll.horizontalNormalizedPosition += contentShift / contentWidth;*/
        }
        if (isLeft)
        {

          
            if (temp.x >= -785)
            {
                temp.x -= 50 * Time.deltaTime;
                rect.transform.localPosition = temp;
                temp = rect.transform.localPosition;
                // rect.transform.position.x -= 5;
                Invoke("StopMovement", 2f);
            }

            /* float contentWidth = scroll.content.sizeDelta.x;
            float contentShift = speed * 5 * Time.deltaTime;
            scroll.horizontalNormalizedPosition -= contentShift / contentWidth;
           */
        }
    }

    private void StopMovement()
    {
        if (isRight)
            isRight = false;
        if (isLeft)
            isLeft = false;
        CancelInvoke();
    }
    public void OnRightClick()
    {
        isRight = true;
        isLeft = false;
    }

    public void OnLeftClick()
    {
        isRight = false;
        isLeft = true;
    }
}
