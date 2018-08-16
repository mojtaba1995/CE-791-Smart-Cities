using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabasePipe : MonoBehaviour {

    private char lineSeperater = '\n';
    private char fieldSeperator = ',';

    public GameObject PipePrefab;
    public Vector3 Scale;
    public GameObject PipeParent;

    // Use this for initialization
    void Start()
    {
        
        string csv = System.IO.File.ReadAllText(getPath() + "Database" + "/Database2.csv");
        //	String[] values = csv.Split(',');
        int i;
        i = 0;

        string[] names = new string[100];
        string[] StartJunction = new string[100];
        string[] EndJunction  = new string[100];
        string[] Shape = new string[100];

        float[] Length = new float[100]; 
        float[] ManningCoefficient = new float[100]; ;

        float[] geo1 = new float[100]; 
        float[] geo2 = new float[100]; 
        float[] geo3 = new float[100];
        float[] slope = new float[100];

        string[] records = csv.Split(lineSeperater);
        foreach (string record in records)
        {
            string[] fields = record.Split(fieldSeperator);
            foreach (string field in fields)
            {
                if (i % 10 == 0)
                {
                    names[i / 10] += field ;
                }
                if (i % 10 == 1)
                {
                    StartJunction[(i - 1) / 10] += field ;
                }
                if (i % 10 == 2)
                {
                    EndJunction[(i - 2) / 10] += field ;
                }
                if (i % 10 == 3)
                {
                    Length[(i - 3) / 10] += float.Parse(field);
                }
                if (i % 10 == 4)
                {
                    ManningCoefficient[(i - 4) / 10] += float.Parse(field);
                }
                if (i % 10 == 5)
                {
                    Shape[(i - 5) / 10] += field + "\t";

                }
                if (i % 10 == 6)
                {
                    geo1[(i - 6) / 10] += float.Parse(field);
                }
                if (i % 10 == 7)
                {
                    geo2[(i - 7) / 10] += float.Parse(field);
                }
                if (i % 10 == 8)
                {
                    geo3[(i - 8) / 10] += float.Parse(field);
                }
                if (i % 10 == 9)
                {
                    slope[(i - 9) / 10] += float.Parse(field);
                }
                
                i++;
                //contentArea.text += field + "\t";
            }



        }
        
        bool LoopEnd;
        LoopEnd = true;
        int j = 0;

        while (LoopEnd)
        {
            //Debug.Log(StartJunction[j]);
            //Debug.Log("123");
            //GameObject temp = new GameObject(names[j]);
            GameObject firstJunction = GameObject.Find(StartJunction[j]);
            GameObject endJunction = GameObject.Find(EndJunction[j]);
            
           //Debug.Log(endJunction.transform.position);
           


           Vector3 middle;
           middle = firstJunction.transform.position + endJunction.transform.position;
           middle = middle / 2;

           Vector3 size;
           size = endJunction.transform.position - firstJunction.transform.position;
           
          // Debug.DrawRay(firstJunction.transform.position, endJunction.transform.position , Color.black);

           GameObject temp = Instantiate(PipePrefab, new Vector3(0,0,0), new Quaternion());
           temp.transform.name = names[j];
           temp.transform.position = middle;
			temp.transform.parent = PipeParent.transform;
			float xMid, zMid, y2, y1, x1, x2, alpha,yMid;
			Vector3 elementRotate = new Vector3(0,0,0);
			y2 = endJunction.transform.position.z;
			y1 = firstJunction.transform.position.z;
			x2 = endJunction.transform.position.x;
			x1 = firstJunction.transform.position.x;

			xMid = y2 - y1;

			zMid = x2 - x1;
			//Debug.Log (x1 );
			//Debug.Log (x2 );
			alpha = Mathf.Atan2 (xMid, zMid);
			alpha = alpha * 180 / Mathf.PI;

			//alpha=180*alpha/Mathf.PI;
			//alpha = -1 / alpha;
			//alpha = Mathf.Atan2 (Mathf.Abs (y2 - y1), Mathf.Abs (x2 - x1));
			//alpha = Mathf.Atan (alpha);
			elementRotate = new Vector3 (90, 0,alpha+90);

			temp.transform.Rotate (elementRotate);

			//element.transform.position = elementPos;
			yMid = Mathf.Sqrt ((Mathf.Pow((y2 - y1),2)) + (Mathf.Pow((x2 - x1) , 2))) / 2.0F;

			temp.transform.localScale = new Vector3(20, yMid, 20);


           //temp.transform.localScale = size;
           


			// PIPE CODE //
            Pipe sc = temp.AddComponent(typeof(Pipe)) as Pipe;
			sc.firstJunction = firstJunction;
			sc.lastJunction = endJunction;
			sc.pipeDiameter = geo1 [j];
			sc.pipeSlope = slope [j];
            sc.length = Length[j];
			//Debug.Log (slope [j]);

			//JUNCTION CODES//

			Junction j1 = firstJunction.GetComponent (typeof(Junction)) as Junction;
			Junction j2 = endJunction.GetComponent (typeof(Junction)) as Junction;

			j2.pipeIn.Add (temp);
			j1.pipeOut.Add (temp);



            j++;
            if (names[j] == null)
            {
                LoopEnd = false;
            }
            
        }





    }

    // Update is called once per frame
    void Update()
    {

    }

    private static string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/";
#elif UNITY_ANDROID
		return Application.persistentDataPath;// +fileName;
#elif UNITY_IPHONE
		return GetiPhoneDocumentsPath();// +"/"+fileName;
#else
		return Application.persistentDataPath ;
#endif
    }


}
