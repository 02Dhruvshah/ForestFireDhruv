using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorexit : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
