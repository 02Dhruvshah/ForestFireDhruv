using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//By Using XR we can use the code which works better with VR 
using UnityEngine.XR;

public enum HandType
{
    //Creating ENUM values to set up different Hands 
    Left,
    Right
}

public class XRHandController : MonoBehaviour
{
    public HandType handType;
    //Setting the thumb speed to a Realistic value so the movement feels natural
    public float thumbMoveSpeed = 0.1f;

    private Animator animator;
    //By using Inputdevice we can retrieve a specific input device from the VR headset
    private InputDevice inputDevice;

    //Predefining float values for different hand animations for the quest 2 controller 
    private float indexValue;
    private float thumbValue;
    private float threeFingersValue;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        inputDevice = GetInputDevice();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }

    InputDevice GetInputDevice()
    {
        //Held in Hand is a inputdevice type for XR rig to retrieve a specific input from the controller
        InputDeviceCharacteristics controllerCharacteristic = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller;

        //For left hand animation we can use the previously defined "left" hand type to get the input from the controller
        if (handType == HandType.Left)
        {
            controllerCharacteristic = controllerCharacteristic | InputDeviceCharacteristics.Left;
        }
        else
        {
            // by using 'Else' statement we can use the same data from the controller for the right hand
            controllerCharacteristic = controllerCharacteristic | InputDeviceCharacteristics.Right;
        }

        List<InputDevice> inputDevices = new List<InputDevice>();
        //This function retrieves the data that is required previously to provide function to both the hands
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristic, inputDevices);

        return inputDevices[0];
    }

    void AnimateHand()
    {
        //gets the input values from the triiger button to animate the index finger with the amount of the trigger being touched depending full or none
        inputDevice.TryGetFeatureValue(CommonUsages.trigger, out indexValue);


        //retrieves the input values from the grip button to animate three fingers to perform a grip animation
        inputDevice.TryGetFeatureValue(CommonUsages.grip, out threeFingersValue);


        //we can use the data from the buttons to determine if the buttons are pressed to animate the thumbs on both the hands
        inputDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouched);
        inputDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouched);

        if (primaryTouched || secondaryTouched)
        {
            //if any button is touched the thumb animation plays
            thumbValue += thumbMoveSpeed;
        }
        else
        {
            thumbValue -= thumbMoveSpeed;
        }

        thumbValue = Mathf.Clamp(thumbValue, 0, 1);

        //these functions calls the animation to animate each specific hand movement
        animator.SetFloat("Index", indexValue);
        animator.SetFloat("ThreeFingers", threeFingersValue);
        animator.SetFloat("Thumb", thumbValue);
    }
}
