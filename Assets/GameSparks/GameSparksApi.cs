using System;
using System.Collections.Generic;
using GameSparks;

namespace GameSparks{
	
	public partial class GameSparksApi
	{

		public static GameSparksSender getSender(IDictionary<string, object> data){
			return new GameSparksSender(data);
		}

		public static void DebugMsg(String message){
			GameSparks.Core.GS.GSPlatform.DebugMsg(message);
		}

		public static void beginDisconnect(){
			GameSparks.Core.GS.Disconnect();
		}

		public static void disconnect(){
			GameSparks.Core.GS.Disconnect();
		}

		public static void beginConnect(){
			GameSparks.Core.GS.Reconnect();		
		}

		public static void connect(){
			GameSparks.Core.GS.Reconnect();		
		}

		public static void beginLogout(){
			GameSparks.Core.GS.Reset();				
		}

		public static void logout(){
			GameSparks.Core.GS.Reset();				
		}

		private static EventHandler<GameSparksMessageReceivedEventArgs> m_MessageReceived;
		
		public static event EventHandler<GameSparksMessageReceivedEventArgs> GameSparksMessageReceived {
			add { 
				GameSparks.Api.GSMessageHandler._AllMessages = MessageReceived;
				m_MessageReceived += value; 
			}
			remove {
				m_MessageReceived -= value; 
			}
		}
		
		public static void MessageReceived (GameSparks.Api.Messages.GSMessage message){
			
			if (m_MessageReceived == null)
				return;
			try{
				m_MessageReceived (null, new GameSparksMessageReceivedEventArgs (message.JSONData));
			}catch(Exception e){
				DebugMsg(e.ToString());
			}
		}

		private static EventHandler<GameSparksAvailabilityEventArgs> m_Available;
		
		public static event EventHandler<GameSparksAvailabilityEventArgs> GameSparksAvailable {
			add { m_Available += value; }
			remove { m_Available -= value; }
		}
		
		public static bool isAuthenticated(){
			return GameSparks.Core.GS.Authenticated;
		}

		public static bool isAvailable {
			get {return GameSparks.Core.GS.Available;}
		}

		#region Analytic Methods

		/**
	     * Provides authentication using a username/password combination. The username will have been previously created using a RegistrationRequest.
	     * 
	     * @param userName
	     * @param password
	     * @return the GameSparks server response
	     */
		public static GameSparksSender authenticationRequest(String userName, String password) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".AuthenticationRequest");
			data.Add("userName", userName);
			data.Add("password", password);
			return getSender(data);
		}

		/*		*
	     * Allows a new user to be created using with a username, password and (optional) display name.
	     * 
	     * @param userName
	     * @param password
	     * @param displayName
	     * @return the GameSparks server response
	     */
		public static GameSparksSender registrationRequest(String userName, String password, String displayName) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".RegistrationRequest");
			data.Add("userName", userName);
			data.Add("password", password);
			data.Add("displayName", displayName);
			return getSender(data);
		}

		/*		*
	     * Allows either a Facebook access token, or a Facebook authorization code to be used as an authentication mechanism. Once authenticated the platform can
	     * determine the current players details from the Facebook platform and store them within GameSparks. GameSparks will determine the player friends and
	     * whether any of them are currently registered with the game.
	     * 
	     * @param accessToken
	     * @return the GameSparks server response
	     */
		public static GameSparksSender facebookConnectRequest(String accessToken) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".FacebookConnectRequest");
			data.Add("accessToken", accessToken);
			return getSender(data);
		}

		/*		*
	     * Registers the current device for push notifications. Currently GameSparks supports iOS, GCM & Microsoft Push notifications. Supply the device type, and
	     * the push notification identifier for the device.
	     * 
	     * @param pushId
	     * @return the GameSparks server response
	     */
		public static GameSparksSender pushRegistrationRequest(String pushId) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".PushRegistrationRequest");
			data.Add("deviceOS", GameSparks.Core.GS.GSPlatform.DeviceOS);
			data.Add("pushId", pushId);
			return getSender(data);
		}

		/*		*
     * Returns the list of configured virtual goods.
     * 
     * @return the GameSparks server response
     */
		public static GameSparksSender listVirtualGoodsRequest() {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".ListVirtualGoodsRequest");
			return getSender(data);
		}

		/*		*
     * Purchases a virtual good with an in game currency. Once purchased the virtual good will be added to the players account.
     * 
     * @param shortCode
     * @param quantity
     * @param currencyType
     * @return the GameSparks server response
     */
		public static GameSparksSender buyVirtualGoodsRequest(String shortCode, int quantity, int currencyType) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".BuyVirtualGoodsRequest");
			data.Add("shortCode", shortCode);
			data.Add("quantity", quantity);
			data.Add("currencyType", currencyType);
			return getSender(data);
		}

		/*		*
     * Processes the response from a Google Play in app purchase flow. The GameSparks platform will validate the signature and signed data with the Google Play
     * Public Key configured against the game.
     * 
     * @param signature
     * @param signedData
     * @return the GameSparks server response
     */
		public static GameSparksSender googlePlayBuyGoodsRequest(String signature, String signedData) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".GooglePlayBuyGoodsRequest");
			data.Add("signature", signature);
			data.Add("signedData", signedData);
			return getSender(data);
		}


		/*		*
     * Records the end of the current users active session. The SDK will automatically create a new session ID when the app is started, this method can be
     * useful to call when the app goes into the background to allow reporting on player session length.
     * 
     * @return the GameSparks server response
     */
		public static GameSparksSender endSessionRequest() {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".EndSessionRequest");
			return getSender(data);
		}

		/*		*
     * Allows a user defined event to be triggered. The event will be posted to the challenge specified.
     * 
     * @param eventKey
     * @param challengeInstanceId
     * @return the GameSparks server response
     */
		public static GameSparksSender logChallengeEventRequest(String eventKey, String challengeInstanceId) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".LogChallengeEventRequest");
			data.Add("eventKey", eventKey);
			data.Add("challengeInstanceId", challengeInstanceId);
			return getSender(data);
		}

		/*		*
     * Allows a user defined event to be triggered.
     * 
     * @param eventKey
     * @return the GameSparks server response
     */
		public static GameSparksSender logEventRequest(String eventKey) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".LogEventRequest");
			data.Add("eventKey", eventKey);
			return getSender(data);
		}

		/**
     	* Retrieves a list of the configured achievements in the game, along with whether the current player has earned the achievement.
     	* 
     	* @return the GameSparks server response
     	*/
		public static GameSparksSender listAchievementsRequest() {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".ListAchievementsRequest");
			return getSender(data);
		}

		/*		*
     * 
     * @return the GameSparks server response
     */
		public static GameSparksSender listGameFriendsRequest() {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".ListGameFriendsRequest");
			return getSender(data);
		}

		/*		*
     * Returns the list of the current players game friends. A Game friend is someone in their social network who also plays the game.
     * 
     * @return the GameSparks server response
     */
		public static GameSparksSender listInviteFriendsRequest() {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".ListInviteFriendsRequest");
			return getSender(data);
		}

		/*		*
     * Returns the list of the current players messages / notifications.
     * 
     * @return the GameSparks server response
     */
		public static GameSparksSender listMessageRequest() {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".ListMessageRequest");
			return getSender(data);
		}

		/*		*
     * Allows a message to be dismissed. Once dismissed the message will no longer appear in either ListMessageResponse or ListMessageSummaryResponse.
     * 
     * @param messageId
     * @return the GameSparks server response
     */
		public static GameSparksSender dismissMessageRequest(String messageId) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".DismissMessageRequest");
			data.Add("messageId", messageId);
			return getSender(data);
		}

		/*		*
     * Returns the full details of a message.
     * 
     * @param messageId
     * @return the GameSparks server response
     */
		public static GameSparksSender getMessageRequest(String messageId) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".GetMessageRequest");
			data.Add("messageId", messageId);
			return getSender(data);
		}

		/*		*
     * Send a message to the user's friends.
     * 
     * @param friendIds
     * @param message
     * @return the GameSparks server response
     */
		public static GameSparksSender sendFriendMessageRequest(String[] friendIds, String message) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".SendFriendMessageRequest");
			data.Add("friendIds", friendIds);
			data.Add("message", message);
			return getSender(data);
		}

		/*		*
     * Starts a timed analyser. Only one instance of a key can exists in a given session. If the same key is started twice without a endTimer call being made
     * the first one is deemed to be abandoned.
     * 
     * @param key
     * @param data
     * @return the GameSparks server response
     */
		public static GameSparksSender startTimer(String key, IDictionary<string, object> requestData) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".AnalyticsRequest");
			data.Add("key", key);
			data.Add("start", true);
			data.Add("data", requestData);
			return getSender(data);
		}

		/*		*
     * Ends a timed analyser. If no analyser has been started with this key the method returns without failing.
     * 
     * @param key
     * @param data
     * @return the GameSparks server response
     */
		public static GameSparksSender endTimer(String key, IDictionary<string, object> requestData) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".AnalyticsRequest");
			data.Add("key", key);
			data.Add("end", true);
			data.Add("data", requestData);
			return getSender(data);
		}

		/*		*
     * Records some custom analytical data. Simple analytics, where you just need to track the number of times something happened, just take a key parameter.
     * The GameSparks platform will record the players id against the data to allow you to report on averages per user.
     * 
     * @param key
     * @param data
     * @return the GameSparks server response
     */
		public static GameSparksSender analyse(String key, IDictionary<string, object> requestData) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".AnalyticsRequest");
			data.Add("key", key);
			data.Add("data", data);
			return getSender(data);
		}

	/*	requestData		*
     * 
     * @return the GameSparks server response
     */
		public static GameSparksSender listMessageSummaryRequest() {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".ListMessageSummaryRequest");
			return getSender(data);
		}

		/*		*
     * Returns a summary of the list of the current players messages / notifications.
     * 
     * @param usersToChallenge
     * @param shortCode
     * @param endTime
     * @return the GameSparks server response
     */
		public static GameSparksSender createChallengeRequest(String usersToChallenge, String shortCode, DateTime endTime) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".CreateChallengeRequest");
			data.Add("usersToChallenge", usersToChallenge);
			data.Add("challengeShortCode", shortCode);

			data.Add("endTime", endTime.ToString("yyyy-MM-dd'T'HH:mm'Z'"));
			return getSender(data);
		}

		/*		*
     * 
     * @param state
     * @param shortCode
     * @return the GameSparks server response
     */
		public static GameSparksSender listChallengeRequest(String state, String shortCode) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".ListChallengeRequest");
			data.Add("state", state);
			data.Add("shortCode", shortCode);
			return getSender(data);
		}

		/*		*
     * Returns the list of configured challenge types.
     * 
     * @return the GameSparks server response
     */
		public static GameSparksSender listChallengeTypeRequest() {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".ListChallengeTypeRequest");
			return getSender(data);
		}

		/*		*
     * 
     * @param challengeInstanceId
     * @param message
     * @return the GameSparks server response
     */
		public static GameSparksSender acceptChallengeRequest(String challengeInstanceId, String message) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".AcceptChallengeRequest");
			data.Add("challengeInstanceId", challengeInstanceId);
			data.Add("message", message);
			return getSender(data);
		}

		/*		*
     * Accepts a challenge that has been issued to the current player.
     * 
     * @param challengeInstanceId
     * @param message
     * @return the GameSparks server response
     */
		public static GameSparksSender declineChallengeRequest(String challengeInstanceId, String message) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".DeclineChallengeRequest");
			data.Add("challengeInstanceId", challengeInstanceId);
			data.Add("message", message);
			return getSender(data);
		}

		/*		*
     * 
     * @param challengeInstanceId
     * @param message
     * @return the GameSparks server response
     */
		public static GameSparksSender withdrawChallengeRequest(String challengeInstanceId, String message) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".WithdrawChallengeRequest");
			data.Add("challengeInstanceId", challengeInstanceId);
			data.Add("message", message);
			return getSender(data);
		}

		/*		*
     * Withdraws a challenge previously issued by the current player. This can only be done while the challenge is in the ISSUED state.
     * 
     * @param challengeInstanceId
     * @param message
     * @return the GameSparks server response
     */
		public static GameSparksSender chatOnChallengeRequest(String challengeInstanceId, String message) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".ChatOnChallengeRequest");
			data.Add("challengeInstanceId", challengeInstanceId);
			data.Add("message", message);
			return getSender(data);
		}

		/*		*
     * Gets the details of a challenge. The current player must be involved in the challenge for the request to succeed.
     * 
     * @param challengeInstanceId
     * @return the GameSparks server response
     */
		public static GameSparksSender getChallengeRequest(String challengeInstanceId) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".GetChallengeRequest");
			data.Add("challengeInstanceId", challengeInstanceId);
			return getSender(data);
		}

		/*		*
     * Returns a list of all leaderboards configured in the game.
     * 
     * @return the GameSparks server response
     */
		public static GameSparksSender listLeaderboardsRequest() {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".ListLeaderboardsRequest");
			return getSender(data);
		}

		/*		*
     * Returns the top data for either the specified global leaderboard or the specified challenges leaderboard. The data is sorted as defined in the rules
     * specified in the leaderboard configuration. The response contains the top of the leaderboard, and returns the number of entries as defined in the
     * entryCount parameter.
     * 
     * @param shortCode
     * @param entryCount
     * @return the GameSparks server response
     */
		public static GameSparksSender leaderboardDataRequest(String shortCode, int entryCount) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".LeaderboardDataRequest");
			data.Add("leaderboardShortCode", shortCode);
			data.Add("entryCount", entryCount);
			return getSender(data);
		}

		/*		*
     * Returns leaderboard data that only contains entries of players that are game friends with the current user. The GameSparks platform will attempt to
     * return players both ahead and behind the current player, where data is available.
     * 
     * @param shortCode
     * @param entryCount
     * @return the GameSparks server response
     */
		public static GameSparksSender socialLeaderboardDataRequest(String shortCode, int entryCount) {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".SocialLeaderboardDataRequest");
			data.Add("leaderboardShortCode", shortCode);
			data.Add("entryCount", entryCount);
			return getSender(data);
		}

		/*		*
     * Allows a device id to be used to create an anonymous profile in the game. This allows the player to be tracked and have data stored against them before
     * using FacebookConnectRequest to create a full profile. DeviceAuthenticationRequest should not be used in conjunction with RegistrationRequest as the two
     * accounts will not be merged.
     * 
     * @return the GameSparks server response
     */
		public static GameSparksSender deviceAuthenticationRequest() {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".DeviceAuthenticationRequest");
			data.Add("deviceId", GameSparks.Core.GS.GSPlatform.DeviceId);
			data.Add("deviceOS", GameSparks.Core.GS.GSPlatform.DeviceOS);
			return getSender(data);
		}


		/*		*
     * Retrieves the details of the current authenticated player.
     * 
     * @return the GameSparks server response
     */
		public static GameSparksSender accountDetailsRequest() {
			IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("@class", ".AccountDetailsRequest");
			return getSender(data);
		}


		#endregion

	}

	public class GameSparksMessageReceivedEventArgs : EventArgs
	{
		public GameSparksMessageReceivedEventArgs (IDictionary<string,object> message)
		{
			Message = message;
		}
		
		public IDictionary<string,object> Message { get; private set; }
	}
	
	public class GameSparksAvailabilityEventArgs : EventArgs
	{
		public GameSparksAvailabilityEventArgs (bool available)
		{
			this.available = available;
		}
		
		public bool available { get; private set; }
	}
}
