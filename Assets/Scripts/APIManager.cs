using UnityEngine;
using System.Collections;
using Facebook;
using GameSparks.Api.Requests;

public class APIManager : MonoBehaviour {
	
	//Initialization
	void Awake () {
		//If facebook is not Initialized
		if (!FB.IsInitialized)
		{
			//Call FB.Init and once that's complete we'll call 
			//Facebook Login
			FB.Init(FacebookLogin);
		}
		//Otherwise if we already initialized call Facebook Login
		else
		{
			FacebookLogin();
		}
	}
	
	public void FacebookLogin()
	{
		//If we aren't logged in
		if (!FB.IsLoggedIn)
		{
			//Call FB.Login, tell it to call GameSparksLogin
			//when done
			FB.Login("", GameSparksLogin);
		}
	}
	
	//GameSparksLogin takes FBResult from FB.Login but we don't use it 
	//for anything
	public void GameSparksLogin(FBResult result) 
	{
		//double check it you are logged into Facebook                
		//before trying to log into GameSparks with Facebook
		if (FB.IsLoggedIn)
		{
			//This is the standard FacebookConnectRequest. This will                        
			//log into GameSparks with your Facebook Profile.
			new FacebookConnectRequest().SetAccessToken(FB.AccessToken).Send((response) =>
		    {
				if (response.HasErrors)
				{
					Debug.Log("Something failed with connecting with Facebook");
				}
				else
				{
					Debug.Log("successfully logged in");
				}
			});
		}
	}
	
}

