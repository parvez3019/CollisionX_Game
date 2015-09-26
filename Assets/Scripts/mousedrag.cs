using UnityEngine;
using System.Collections;

public class mousedrag : MonoBehaviour 
{
	
	private Vector3 screenPoint;
	public Vector3 offset;


	/*void Start()
	{
		Debug.Log ("Start ho gya");
		gameObject.transform.position = Camera.main.WorldToScreenPoint(new Vector3(0,0,0));

	}*/

	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		curScreenPoint.x = Mathf.Clamp (curScreenPoint.x, 10.5f, Screen.width-10.5f);
		curScreenPoint.y = Mathf.Clamp(curScreenPoint.y, 10.5f, Screen.height-10.5f);

		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
		transform.position = curPosition;


		
	}
	
}