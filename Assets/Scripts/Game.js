#pragma strict

var  mainCam : Camera;

var topWall : BoxCollider2D;
var bottomWall : BoxCollider2D;
var leftWall : BoxCollider2D;
var rightWall : BoxCollider2D;
var EnemyBall : GameObject;
var myTimer : float =5.0;
var counter =4;
var mutetoggle = false;
var toggleimg = false;


function Start() {
//	TimerStart();

	AudioListener.volume = 1.0f;
	
	var newBall1Pos = new Vector2 (mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x + 0.6f,
	mainCam.ScreenToWorldPoint (new Vector3 ( 0f, Screen.height, 0f)).y - 0.6f);
	var newBall1 : GameObject = Instantiate(EnemyBall, newBall1Pos, transform.rotation);
	
	var newBall2Pos = new Vector2 (mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x - 0.6f,
	mainCam.ScreenToWorldPoint (new Vector3( 0f, 0f, 0f)).y + 0.6f);
	var newBall2 : GameObject = Instantiate(EnemyBall, newBall2Pos, transform.rotation);
	
	var newBall3Pos = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x -0.6f,
	mainCam.ScreenToWorldPoint (new Vector3 ( 0f, Screen.height, 0f)).y - 0.6f);
	var newBall3 : GameObject = Instantiate(EnemyBall, newBall3Pos, transform.rotation);
	
	var newBall4Pos= new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x + 0.6f,
	mainCam.ScreenToWorldPoint (new Vector3( 0f, 0f, 0f)).y + 0.6f);
	var newBall4 : GameObject = Instantiate(EnemyBall, newBall4Pos, transform.rotation);		
}




function Update () {
	
	topWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x, 1f);
	topWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3 ( 0f, Screen.height, 0f)).y + 0.5f);
	
	bottomWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2, 0f, 0f)).x, 1f);
	bottomWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3( 0f, 0f, 0f)).y - 0.5f);
	
	leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);;
	leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);
	
	rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);
	rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

 
  	if(myTimer > 0){
 		 myTimer -= Time.deltaTime;
 		}
 
 
 	if(myTimer <=1 && myTimer>=0){
 		//yield WaitForSeconds(5.0);
  		addball();
		}
	
}

function addball(){
		var newBall5Pos = new Vector2 (mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x + 0.3f,
	 	mainCam.ScreenToWorldPoint (new Vector3 ( 0f, Screen.height, 0f)).y - 0.3f);
		var newBall5 : GameObject = Instantiate(EnemyBall, newBall5Pos, transform.rotation);
		if(counter<6)
			myTimer=10.0;
		else if(counter>=6&&counter<8)
			myTimer=15.0;
		else if(counter>=8 && counter <10)
			myTimer=15.0;
		else if(counter>=10)
			myTimer=20.0;
		counter ++;

}
 

 
 
 
 
