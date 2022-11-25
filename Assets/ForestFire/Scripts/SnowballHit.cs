using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SnowballHit : MonoBehaviour
{
    //set up array for the snowballs
    //have this script find all snowballs and add it to the array
    //set up rigidbodies and sphere colliders on the snowballs - make sure they are set the same as what we added for the xr rig
    //make sure the tags are on snowballs


    //public GameObject[] Snowball;
    public ForestFireCell forestFireCellScript;
    // Start is called before the first frame update
    void Start()
    {
        forestFireCellScript = this.GetComponent<ForestFireCell>();
    }

    public void OnTriggerEnter(Collider other)


    {
        if(other.tag == "Snowball")
        {
            Debug.Log("Snowball hit");
          //  [SerializeField] VisualEffect _fireVisualEffect;
            forestFireCellScript._fireVisualEffect.Stop();
            forestFireCellScript.cellFuel = 0;
            forestFireCellScript.cellState = ForestFireCell.State.Burnt;
        }
    }
}
