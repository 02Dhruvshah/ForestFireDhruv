using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by using scene management we can open different scenes by calling them and loading them
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
   public void PlayGame()
    {
        //here scene '1' is the forest fire scene which is being called by the button on the main menu scene which is scene '0'
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quitgame()
    {
        //Adding the function of quiting the game to close the application
        Debug.Log("Quit!");
        Application.Quit();
    }
}
