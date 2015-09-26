#pragma strict


function Start () {
	var randomNumber = Random.Range(0, 5);
	if (randomNumber <= 2.5) {
		var randomNumberX = Random.Range(15, 20);
		var randomNumberY = Random.Range(15, 20);
		//yield WaitForSeconds(3.0);
		GetComponent.<Rigidbody2D>().AddForce (new Vector2 (randomNumberX, randomNumberY));
	}
	else {
		var randomNumberNegX = Random.Range(-15, -20);
		var randomNumberNegY = Random.Range(-15, -20);
		//yield WaitForSeconds(3.0);
		GetComponent.<Rigidbody2D>().AddForce (new Vector2 (randomNumberNegX, randomNumberNegY));
	}
}
