#pragma strict

var moveUp : KeyCode;
var moveDown : KeyCode;
var moveRight : KeyCode;
var moveLeft : KeyCode;

var speed : float =10;

function Update () {
	if(Input.GetKey(moveUp))
	{
		GetComponent.<Rigidbody2D>().velocity.y = speed;
		
	}
	else if(Input.GetKey(moveDown))
	{
	 	GetComponent.<Rigidbody2D>().velocity.y = speed *-1;
	}
	
	else if(Input.GetKey(moveRight))
	{
		GetComponent.<Rigidbody2D>().velocity.x = speed;
	}
	else if(Input.GetKey(moveLeft))
	{
		GetComponent.<Rigidbody2D>().velocity.x = speed *-1;
	}
	else
	{
		GetComponent.<Rigidbody2D>().velocity.y=0;
		GetComponent.<Rigidbody2D>().velocity.x=0;
	}
	
}