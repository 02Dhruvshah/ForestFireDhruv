using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthscript : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public healthbar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
  //          TakeDamage(5);
        }
    }
  //  void TakeDamage(int damage);
  //  { 

   // currentHealth -= damage;
   // healthbar.SetHealth(currentHealth);
    }        
//}
