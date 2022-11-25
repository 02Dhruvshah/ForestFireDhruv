using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdamage : MonoBehaviour
{
    public playerhealth playerHealthScript;         //reference to our player health script

    public float damageValue;                       //creates a variable to carry our damage value


    // Start is called before the first frame update
    void Start()
    {
        playerHealthScript = GameObject.FindGameObjectWithTag("PlayerTag").GetComponent<playerhealth>();        //find the gameobject with the tag ("PlayerTag") and get the component we are looking for
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)                                                                  //when an object collides with our trigger
    {
        if (other.tag == "PlayerTag")                                                                            //if the other collider has tag == "PlayerTag"...
        {
            playerHealthScript.playerCurrentHealth = playerHealthScript.playerCurrentHealth - damageValue;      //remoce health from our player health script by damage value
            Debug.Log("The players current health is " + playerHealthScript.playerCurrentHealth);               //debug log out the current player health
        }
        else
        {
            Debug.LogError("NOT THE PLAYER");
        }

    }
}