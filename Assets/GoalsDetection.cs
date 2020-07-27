using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoalsDetection : MonoBehaviour {

    public GameObject car;
    UIController uiCon;
    // Use this for initialization
    void Start () {
        uiCon = car.GetComponent<UIController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            uiCon.GoalAchieved();
        }
    }
}
