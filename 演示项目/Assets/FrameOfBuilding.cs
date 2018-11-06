using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameOfBuilding : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        print("Collider: " + other.tag);
        if (other.tag.Equals("Road"))
        {
            print("-- HIT ROAD --");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Collision: "+collision.collider.tag);
        if (collision.collider.tag.Equals("Road"))
        {
            print("-- HIT ROAD --");
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
