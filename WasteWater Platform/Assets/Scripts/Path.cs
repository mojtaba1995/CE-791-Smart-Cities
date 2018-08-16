using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Path : MonoBehaviour {
	public GameObject text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Application.persistentDataPath);
		Text t1 = text.GetComponent (typeof(Text)) as Text;

		t1.text = getPath();
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
}
