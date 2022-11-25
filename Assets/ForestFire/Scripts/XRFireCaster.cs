using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRFireCaster : MonoBehaviour
{
    private InputDevice targetDevice;

    // Start is called before the first frame update
    void Start()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>(); 
        InputDevices.GetDevices(inputDevices); 
        foreach (var device in inputDevices) 
        { 
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.characteristics.ToString())); 
        }

        var leftHandedControllers = new List<InputDevice>(); 
        var desiredCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller; 
        InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, leftHandedControllers); 
        foreach (var device in leftHandedControllers) 
        { 
            Debug.LogError(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString())); 
        }

    }

    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripButtonValue);
        if (gripButtonValue)
        {
            Debug.Log(gripButtonValue);
        }
    }
}
