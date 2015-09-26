using UnityEngine;
using System.Collections;

public class share : MonoBehaviour {

	void OnClick (){
		Application.OpenURL("whatsapp://send?text=Can you beat my highscore? Check Out this Awesome Game CollisionX");
	}
}
