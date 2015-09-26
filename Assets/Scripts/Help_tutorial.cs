using UnityEngine;
using System.Collections;

public class Help_tutorial : MonoBehaviour {
	public Vector3 position;
	public GameObject gm1;
	public GameObject gm2;
	public GameObject gm3;
	public GameObject gm4;
	public int click;
	// Use this for initialization
	void Start () {
		click = 0;
	
	}
	
	// Update is called once per frame
	void OnClick (){
		click++;
	
		if(click==1)
			gm1.transform.position = new Vector3(0, 0, -10);

		if(click==2)
			gm2.transform.position = new Vector3(0, 0, -7);
		if(click==3)
			gm3.transform.position =new  Vector3(0, 0, -5);
		if(click==4)
			gm4.transform.position =new Vector3(0, 0, -2);
		if(click==5)
			Application.LoadLevel ("scene");



	}
}
