using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junction : MonoBehaviour {

	public float upstreamVF;

	public List<GameObject> pipeIn = new List<GameObject>();
	public List<GameObject> pipeOut = new List<GameObject>();

	public float vfIn; 
	public float cumVF;

    public bool color;

	// Use this for initialization
	void Start () {
		vfIn = 0.0f;
		cumVF = 0.0f;
        color = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(color ==true) { 
        foreach (var renderer in GetComponentsInChildren<Renderer>())
        {
            foreach (var material in renderer.materials)
            {
                // material.shader = blood of the nonbelievers
                material.color = Color.red;
            }
        }

        }


        //if (Input.GetKeyDown ("up")) {
        //	cumVF = 0;
        //	foreach (GameObject go in pipeIn) {
        //		Pipe p1 = go.GetComponent(typeof(Pipe)) as Pipe;
        //		cumVF += p1.vfEnd; 
        //	}

        //	if (cumVF >= 30) {
        //		//gameObject.GetComponent<Renderer>().material.color = Color.blue;

        //                  foreach (var renderer in GetComponentsInChildren< Renderer > ())
        //                  {
        //                  foreach(var material in renderer.materials)
        //                      {
        //                      // material.shader = blood of the nonbelievers
        //                      material.color = Color.blue;
        //                  }
        //              }


        //              if (cumVF >= 60) {
        //                  foreach (var renderer in GetComponentsInChildren<Renderer>())
        //                  {
        //                      foreach (var material in renderer.materials)
        //                      {
        //                          // material.shader = blood of the nonbelievers
        //                          material.color = Color.red;
        //                      }
        //                  }

        //              }




        //          }

        //      }
    }

    

}
