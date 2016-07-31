#pragma strict 

public var position: Vector3;
public var gm1 : GameObject;
public var gm2 : GameObject;
public var gm3 : GameObject;
public var gm4 : GameObject;

var temps ;

static var click : int;

function start () {
	  Cursor.visible = true;
	  click=0;
}

function OnMouseDown () {		
	click++;
	Debug.Log("clickedddd");
	if(click==1)
	gm1.transform.position = Vector3(0.47, 0.48, -9);
	if(click==2)
	gm2.transform.position = Vector3(0.47, 0.48, -6);
	if(click==3)
	gm3.transform.position = Vector3(0.47, 0.48, -7);
	if(click==4)
	gm4.transform.position = Vector3(0.47, 0.48, -2);
	if(click==5)
	Application.LoadLevel ("scene");
		
}