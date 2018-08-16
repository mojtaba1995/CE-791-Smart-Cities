using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Database : MonoBehaviour {

    private char lineSeperater = '\n';
    private char fieldSeperator = ',';

    public GameObject JunctionPrefab;
    public Vector3 Scale;
    public GameObject JunctionParent;

	public GameObject text;
	public GameObject input;

    // Use this for initialization
    void Start()
    {

        string csv = System.IO.File.ReadAllText(getPath()+"/Database" + "/Database.csv");
        //	String[] values = csv.Split(',');

		Debug.Log (getPath());
		Text t1 = text.GetComponent (typeof(Text)) as Text;

		t1.text = getPath();

        int i;
        i = 0;

        string[] names = new string[100];
        float[] X_Coordinate = new float[100]; ;
        float[] Y_Coordinate = new float[100]; ;

        string[] records = csv.Split(lineSeperater);
        foreach (string record in records)
        {
            string[] fields = record.Split(fieldSeperator);
            foreach (string field in fields)
            {
                if (i % 3 == 0)
                {
                    names[i / 3] += field ;
                }
                if (i % 3 == 1)
                {
                    X_Coordinate[(i - 1) / 3] += float.Parse(field) ;
                }
                if (i % 3 == 2)
                {
                    Y_Coordinate[(i - 2) / 3] += float.Parse(field) ;
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
            //GameObject temp = new GameObject(names[j]);
            
            GameObject temp = Instantiate(JunctionPrefab, new Vector3(X_Coordinate[j], 0.0f, Y_Coordinate[j]) , new Quaternion());
            temp.transform.name = names[j];
            

			temp.transform.Rotate (new Vector3 (0,0,0));
			temp.transform.localScale = Scale;
            temp.transform.parent = JunctionParent.transform;
			temp.transform.position += new Vector3 (0, -10, 0);


			// JUNCTION CODE //
            Junction sc = temp.AddComponent(typeof(Junction)) as Junction;



            j++;
            if (names[j] == null)
            {
                LoopEnd = false;
            }
        }



		DatabasePipe dp =gameObject.GetComponent (typeof(DatabasePipe)) as DatabasePipe;
		dp.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private static string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath+"/" ;
#elif UNITY_ANDROID
		return Application.persistentDataPath;// +fileName;
#elif UNITY_IPHONE
		return GetiPhoneDocumentsPath();// +"/"+fileName;
#else
		return Application.persistentDataPath ;
        
#endif
    }


		public void loadPathDatabase(){
	
		Text t = input.GetComponent (typeof(Text)) as Text;

		}

		public void useDefaultPath(){

		Text t = input.GetComponent (typeof(Text)) as Text;
		t.text = "asdasd";
		Debug.Log ("asdasd");
		}

}
