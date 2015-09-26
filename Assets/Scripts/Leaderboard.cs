using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameSparks.Api.Requests;

//the prefab we are going to instantiate 

public class Leaderboard : MonoBehaviour
{
	
	public GameObject leaderboardEntryPrefab;
	
	//NGUI grid, this will re-organise the leaderboard whenever 
	//a new entry is added
	public UIGrid leaderboardGrid;
	
	//creates a list of GameObjects. whenever the leaderboard is called it will clear out the old enteries and pull in the new.
	public List<GameObject> entries = new List<GameObject>();
	
	void Start()
	{
		//re-arranges all currently stored game objects that are 
		//children of the leaderboard grid
		leaderboardGrid.Reposition();
		GetLeaderboard ();
	}
	
	public void GetLeaderboard()
	{
		//the leaderboard entries could contain old data. 
		//First destroy all existing Leaderboard objects
		for (int i = 0; i < entries.Count; i++)
		{
			Destroy(entries[i]);
		}
		
		//because we deleted the objects contained on the list, the list                
		//now contains nulL references and has to be cleared so the new 
		//high score objects can be added
		entries.Clear();
		
		//pulls in the Leaderboard information from Gamesparks, 
		//identified by the short code added when setting up the 
		//Leaderboard in the Gamesparks portal
		//SetEntryCount() will define how many entries you want to pull in one go


		new LeaderboardDataRequest_highscore().SetEntryCount(10).Send((response) => 
		  {
					
			Debug.Log("Leaderboard data log");

			//what we will do with the information given by GameSparks
			foreach (var entry in response.Data)
			{
				Debug.Log("Leaderboard1");
				//only children of the NGUI grid will be added 
				//to the grid. We make new objects with our
				//LeaderboardEntry script and add them as 
				//children to the NGUI Leaderboard Grid
				GameObject go = NGUITools.AddChild(leaderboardGrid.gameObject, leaderboardEntryPrefab);
				Debug.Log("Leaderboard2");
				
				go.GetComponent<LeaderboardEntry>().rankString = entry.Rank.ToString();
				go.GetComponent<LeaderboardEntry>().usernameString = entry.UserName.ToString();
				//the score string has to be added as a number value 
				//based on the short code used for the attributed 
				//to the leaderboard we are pulling from
				Debug.Log("Leaderboard4");
				
				go.GetComponent<LeaderboardEntry>().scoreString = entry.GetNumberValue("score").ToString();
				go.GetComponent<LeaderboardEntry>().facebookID = entry.ExternalIds.GetString("FB");

				//adds the gameobject to the list of entries
				entries.Add(go);
				
				//repositions the new object so it isn't stacked over existing objects
				//created by the loop
				leaderboardGrid.Reposition();
				
			}
			
		});
		
		
	}
}