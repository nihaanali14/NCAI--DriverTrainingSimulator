using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingMenu : Menu<LoadingMenu>
{

    public Image fillBarr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBarValue(float value)
    {
        if (fillBarr != null)
        {
            fillBarr.fillAmount = value;
        }
    }

    public void SetBarValue(float value, float maxValue)
    {
        if (fillBarr != null)
        {
            fillBarr.fillAmount = value / maxValue;
        }
    }
}
