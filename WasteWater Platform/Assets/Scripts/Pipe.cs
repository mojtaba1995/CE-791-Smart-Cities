using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	public float pipeSlope;
	public float pipeDiameter;
	public float pipeVFCapacity;


	// Begining of the pipe //
	public float vfStart;
	public float velocityStart;

	public float vfEnd;
	public float velocityEnd;

    public float length;


	public GameObject firstJunction;
	public GameObject lastJunction;

	public float outFlow;

	public Color color;


    private float time;

	// Use this for initialization
	void Start () {
		//pipeSlope = 0.01f;

		vfStart = 2;
		velocityStart = 3;
		vfEnd = 1;
		velocityEnd = 2f;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("up")) {
			//gameObject.GetComponent<Renderer>().material.color = Color.blue;
			Junction j1 = firstJunction.GetComponent(typeof(Junction)) as Junction;
			Junction j2 = lastJunction.GetComponent(typeof(Junction)) as Junction;

            time += 600;

            if(time >= length / velocityStart)
            {
                vfEnd = vfStart ;
            }

            //vfEnd += (vfStart - vfEnd)/(velocityStart*length);

			vfStart = j1.cumVF + 2;


		}


	}
}
