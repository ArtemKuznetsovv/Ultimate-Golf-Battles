using UnityEngine;
using System.Collections;

public class ChangeBallLayer : MonoBehaviour {

    public int LayerOnEnter; // BallInHole
    public int LayerOnExit;  // BallOnTable
	
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Chang Ball layout");
            other.gameObject.layer = LayerOnEnter;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Exiting Collision");
            other.gameObject.layer = LayerOnExit;
        }
    }
}