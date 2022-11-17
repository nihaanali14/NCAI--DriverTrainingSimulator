using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    #region INPUTAXIS
    [HideInInspector] public  float accInput;
    [HideInInspector] public  float brakeInput;
    [HideInInspector] public  float clutchInput;
    [HideInInspector] public  float steeringInput;
    #endregion

    #region KEYCODE
    public KeyCode currentKeyPressed;
    [HideInInspector] public bool AButton;
    [HideInInspector] public bool BButton;
    [HideInInspector] public bool XButton;
    [HideInInspector] public bool YButton;
    [HideInInspector] public bool RightIndicatorButton;
    [HideInInspector] public bool LeftIndicatorButton;
    [HideInInspector] public bool FirstGearButton;
    [HideInInspector] public bool SecondGearButton;
    [HideInInspector] public bool ThirdGearButton;
    [HideInInspector] public bool FourthGearButton;
    [HideInInspector] public bool FifthGearButton;
    [HideInInspector] public bool ReverseGearButton;
    [HideInInspector] public bool _4X4Button;
    #endregion

    public string[] ListOffPossibleInputAxis;   
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        CheckButtonDown();
        CheckButtonUp();
        HandleKeyboardInputs(currentKeyPressed);
        // Handling Axis based input
        CheckForLogitechInput();
        CheckGearInput();


    }
    private void OnGUI()
    {
        // Handling keyCode based input handling
        Event e = Event.current;
        if (e.isKey)
        {
            currentKeyPressed = e.keyCode;            
        }
    }
    void CheckButtonDown()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            AButton = true;
          //  print("A");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            BButton = true;
            print("B");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            XButton = true;
            print("X");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            YButton = true;
            print("");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            // Right Side indecator
            RightIndicatorButton = true;
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            // LeftSideIndecator
            LeftIndicatorButton = true;
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            //"6666666666666"
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            //"77777777777777"
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton8))
        {
            //"88888888"
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton9))
        {
            //"999999999999"
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton10))
        {
            //"10101010101010101010"
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton11))
        {
            // Push Gear for 4X4 mode of vehicle
            _4X4Button = true;
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton12))
        {
            // First Gear
            FifthGearButton = true;
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton13))
        {
            // Second Gear
            SecondGearButton = true;
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton14))
        {
            // Third Gear
            ThirdGearButton = true;
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton15))
        {
            // Forth Gear
            FourthGearButton = true;
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton16))
        {
            // Fifth Gear
            FifthGearButton = true;
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton17))
        {
            // Reverse Gear
            ReverseGearButton = true;
        }
    }
    void CheckButtonUp()
    {
        if (Input.GetKeyUp(KeyCode.JoystickButton0))
        {
            AButton = false;
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton1))
        {
            BButton = false;
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton2))
        {
            XButton = false;
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton3))
        {
            YButton = false;
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton4))
        {
            // Right Side indecator
            RightIndicatorButton = false;
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton5))
        {
            // LeftSideIndecator
            LeftIndicatorButton = false;
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton6))
        {
            //"6666666666666"
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton7))
        {
            //"77777777777777"
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton8))
        {
            //"88888888"
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton9))
        {
            //"999999999999"
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton10))
        {
            //"10101010101010101010"
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton11))
        {
            // Push Gear for 4X4 mode of vehicle
            _4X4Button = false;
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton12))
        {
            // First Gear
            FirstGearButton = false;
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton13))
        {
            // Second Gear
            SecondGearButton = false;
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton14))
        {
            // Third Gear
            ThirdGearButton = false;
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton15))
        {
            // Forth Gear
            FourthGearButton = false;
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton16))
        {
            // Fifth Gear
            FifthGearButton = false;
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton17))
        {
            // Reverse Gear
            ReverseGearButton = false;
        }
    }
    void HandleKeyboardInputs(KeyCode keyCode)
    {
        // need to work on use cases
    }
    /// <summary>
    /// Funtion will record inputs of logitech steering wheel but in normalized form.
    /// Acceleration range is from [0-1 normlized value]
    /// Brake range is from [0-1 normlized value]
    /// Clutch range is from [1-0(***** reversed value used as multiplier with gas input to control speed*****) normlized value]
    /// Steering range is from [-1,1 normlized value] 
    /// </summary>
    void CheckForLogitechInput()
    {
        if (LogitechGSDK.LogiIsConnected(0)) 
        {
            
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);
            steeringInput = rec.lX / 32767f;
            brakeInput = 1f - (rec.lRz + 32768) / 65536f;
            accInput = 1f - (rec.lY + 32768f) / 65536f;
            clutchInput = ((rec.rglSlider[0] / 32768f) + 1.0f) / 2.0f;

        }
    }
    void CheckGearInput()
    {


        if (Input.GetKeyDown(KeyCode.Joystick1Button12))
            FifthGearButton = true;
        else if (Input.GetKeyDown(KeyCode.Joystick1Button13))
            SecondGearButton = true;
        else if (Input.GetKeyDown(KeyCode.Joystick1Button14))
            ThirdGearButton = true;
        else if (Input.GetKeyDown(KeyCode.Joystick1Button15))
            FourthGearButton = true;
        else if (Input.GetKeyDown(KeyCode.Joystick1Button16))
            FifthGearButton = true;
        else if (Input.GetKeyDown(KeyCode.Joystick1Button17))
            ReverseGearButton = true;

        if (Input.GetKeyUp(KeyCode.Joystick1Button12))
            FifthGearButton = false;
        if (Input.GetKeyUp(KeyCode.Joystick1Button13))
            SecondGearButton = false;
        if (Input.GetKeyUp(KeyCode.Joystick1Button14))
            ThirdGearButton = false;
        if (Input.GetKeyUp(KeyCode.Joystick1Button15))
            FourthGearButton = false;
        if (Input.GetKeyUp(KeyCode.Joystick1Button16))
            FifthGearButton = false;
        if (Input.GetKeyUp(KeyCode.Joystick1Button17))
            ReverseGearButton = false;






      /*  if (clutchInput < 0.5)
        {
            // Reverse with Moving Car
            if (SimulationManager.Instance.GetCurrentPlayer().GetComponent<RCC_CarControllerV3>().speed > 5)
            {
                SimulationManager.Instance.GetCurrentPlayer().GetComponent<RCC_CarControllerV3>().StopReverseGearShift = true;
            }



        }
        else
        {
            // Any gear change 
            




        }*/
    }

    
}
