using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class Detectors : MonoBehaviour {


    public string name;
    public GameObject textObject;
    public GameObject car;

    float correctionDistance = 0f;
    float finalDistance = 0f;
    public float distanceTruncated = 99f;

    public float maxDistanceDetection = 10f;

    public Material whiteMat;
    public Material redMat;


    public float distance;
    RaycastHit hit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        Ray detectorRay = new Ray(this.transform.position, this.transform.localPosition + this.transform.forward*1000);
        Debug.DrawRay(detectorRay.origin, detectorRay.origin + detectorRay.direction * 1000, Color.green);

        if (Physics.Raycast(detectorRay.origin, detectorRay.direction, out hit, maxDistanceDetection, 1 << 9))
        {


            if (hit.collider.tag == "Obstacle")
            {
                GameObject sp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sp.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
                sp.transform.position = hit.point;
                Destroy(sp, 0.03f);
                ShowDistances(hit.point);
                if (distanceTruncated < 1f)
                {
                    textObject.GetComponent<TextMeshPro>().color = new Color(1, 0, 0);
                    sp.GetComponent<MeshRenderer>().material = redMat;

                }
                else
                {
                    textObject.GetComponent<TextMeshPro>().color = new Color(1, 1, 1);
                    sp.GetComponent<MeshRenderer>().material = whiteMat;
                }


            }
        
        }
        else
        {
            textObject.GetComponent<TextMeshPro>().text = "";
        }
    }

  

    private void ShowDistances(Vector3 point)
    {
      
            string tag = "";
      
            finalDistance = (point - this.transform.position).magnitude;

            Debug.Log(tag + " " + name + " side at " + finalDistance + " meters ");
            distanceTruncated = Mathf.Floor(finalDistance * 100) / 100;
            textObject.GetComponent<TextMeshPro>().text = distanceTruncated + "m";
            
    }
    

  
        

   }
    

