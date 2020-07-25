using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectors : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        Debug.Log(other.transform.position);


    }
    private void OnTriggerStay(Collider other)
    {
        Vector3 distanceVector = (other.transform.position + new Vector3(0f, 0f, 2.1f)) - this.transform.position;

        Debug.Log("There is an "+other.tag + " at "+ distanceVector.z);
       


    }
}
