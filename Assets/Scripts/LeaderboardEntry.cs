using UnityEngine;
using System.Collections;

public class LeaderboardEntry : MonoBehaviour {
	//creating the public variables that we can pass the GameSparks information to
	public string rankString, usernameString, scoreString,facebookID = "";

	public UITexture profilePic;

	public UILabel rank, username, score;
	
	// Use this for initialization. The NGUI Labels will update 
	//with the information we pass to them later
	void Start()
	{
		rank.text = rankString;
		username.text = usernameString;
		score.text = scoreString;
		// Defines when the image will be pulled
		if (facebookID != "")
		{
			StartCoroutine(getFBPicture());
		}
	}

     public IEnumerator getFBPicture()
	{
		var www = new WWW("http://graph.facebook.com/" + facebookID + "/picture?type=square");
		
		yield return www;
		
		//make sure the dimensions of the new texture match what we set                 
		//up in the Leaderboard Entry prefab
		Texture2D tempPic = new Texture2D(25, 25);
		
		www.LoadImageIntoTexture(tempPic);
		profilePic.mainTexture = tempPic;
		
	}

}
