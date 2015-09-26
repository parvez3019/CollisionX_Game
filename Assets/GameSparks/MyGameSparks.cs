using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Requests{
	public class LogEventRequest_postscore : GSTypedRequest<LogEventRequest_postscore, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_postscore() : base("LogEventRequest"){
			request.AddString("eventKey", "postscore");
		}
		public LogEventRequest_postscore Set_score( long value )
		{
			request.AddNumber("score", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_postscore : GSTypedRequest<LogChallengeEventRequest_postscore, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_postscore() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "postscore");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_postscore SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_postscore Set_score( long value )
		{
			request.AddNumber("score", value);
			return this;
		}			
	}
	
}
	
	
	
namespace GameSparks.Api.Requests{
	
	public class LeaderboardDataRequest_highscore : GSTypedRequest<LeaderboardDataRequest_highscore,LeaderboardDataResponse_highscore>
	{
		public LeaderboardDataRequest_highscore() : base("LeaderboardDataRequest"){
			request.AddString("leaderboardShortCode", "highscore");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaderboardDataResponse_highscore (response);
		}		
		
		/// <summary>
		/// The challenge instance to get the leaderboard data for
		/// </summary>
		public LeaderboardDataRequest_highscore SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public LeaderboardDataRequest_highscore SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_highscore SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public LeaderboardDataRequest_highscore SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public LeaderboardDataRequest_highscore SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// The offset into the set of leaderboards returned
		/// </summary>
		public LeaderboardDataRequest_highscore SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_highscore SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public LeaderboardDataRequest_highscore SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public LeaderboardDataRequest_highscore SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
		
	}

	public class AroundMeLeaderboardRequest_highscore : GSTypedRequest<AroundMeLeaderboardRequest_highscore,AroundMeLeaderboardResponse_highscore>
	{
		public AroundMeLeaderboardRequest_highscore() : base("AroundMeLeaderboardRequest"){
			request.AddString("leaderboardShortCode", "highscore");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AroundMeLeaderboardResponse_highscore (response);
		}		
		
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public AroundMeLeaderboardRequest_highscore SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_highscore SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public AroundMeLeaderboardRequest_highscore SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public AroundMeLeaderboardRequest_highscore SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_highscore SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_highscore SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_highscore SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
	}
}

namespace GameSparks.Api.Responses{
	
	public class _LeaderboardEntry_highscore : LeaderboardDataResponse._LeaderboardData{
		public _LeaderboardEntry_highscore(GSData data) : base(data){}
		public long? score{
			get{return response.GetNumber("score");}
		}
	}
	
	public class LeaderboardDataResponse_highscore : LeaderboardDataResponse
	{
		public LeaderboardDataResponse_highscore(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_highscore> Data_highscore{
			get{return new GSEnumerable<_LeaderboardEntry_highscore>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_highscore(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_highscore> First_highscore{
			get{return new GSEnumerable<_LeaderboardEntry_highscore>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_highscore(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_highscore> Last_highscore{
			get{return new GSEnumerable<_LeaderboardEntry_highscore>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_highscore(data);});}
		}
	}
	
	public class AroundMeLeaderboardResponse_highscore : AroundMeLeaderboardResponse
	{
		public AroundMeLeaderboardResponse_highscore(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_highscore> Data_highscore{
			get{return new GSEnumerable<_LeaderboardEntry_highscore>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_highscore(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_highscore> First_highscore{
			get{return new GSEnumerable<_LeaderboardEntry_highscore>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_highscore(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_highscore> Last_highscore{
			get{return new GSEnumerable<_LeaderboardEntry_highscore>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_highscore(data);});}
		}
	}
}	

namespace GameSparks.Api.Messages {


}
