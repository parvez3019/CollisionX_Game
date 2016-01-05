using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class toggle : MonoBehaviour {


	public Toggle musicToggle;


	public void SetMusic()
	{
		if(musicToggle.isOn) {
			// Set music On
			AudioListener.volume = 1.0f;

		} else {
			// Set music Off
			AudioListener.volume = 0.0f;

		}
	}


	/*private bool unmute = true;  
	//public Texture aTexture;
	void OnGUI()  
	{  
		//Render the toggle normally  
		this.unmute= GUILayout.Toggle(this.unmute, "Music");  
	
		if (this.unmute == false)
			AudioListener.volume = 0.0f;
		else if (this.unmute == true)
			AudioListener.volume = 1.0f;
	}
*/

}

