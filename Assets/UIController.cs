using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public GameObject txtGoals;
   
    int goals=0;

    public void GoalAchieved()
    {

        goals++;

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        txtGoals.GetComponent<Text>().text = goals + " Goals";
	}
}
