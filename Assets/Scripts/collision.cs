using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D ball)
	{

		Debug.Log (ball.gameObject.name);
		if (ball.gameObject.name.IndexOf("Ball")!=-1){
			Application.LoadLevel ("gameover");	
		}

	}
	

}
