
 function Start (){
     Cursor.visible = false;
}
 
function Update (){	
     var mousePos = Input.mousePosition;
     mousePos.x = Mathf.Clamp(mousePos.x, 0, Screen.width);
	 mousePos.y = Mathf.Clamp(mousePos.y, 0, Screen.height);
}