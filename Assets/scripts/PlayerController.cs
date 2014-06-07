using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private float run;
	public GUIText playerDisplay;
	private float treecarry;
	Transform thingLocation;
	private float money;
	public float treevalue;
	public GameObject sapling;
	public static int fault;

	void Start(){

		setDisplayText ();
	}
	
	void Update () {

		Running ();
		Action ();

	}

	void Running () {

		if (Input.GetKey(KeyCode.LeftShift)){
			run = speed / 2 ;
		}
		else{
			run = 0f;
		}
	}

	void Action () {

		if (Input.GetKey(KeyCode.D)){
	
			transform.Translate(Vector3.right * (speed + run));
		}
		if (Input.GetKey(KeyCode.A)){

			transform.Translate(Vector3.left * (speed + run));
		}
		if (Input.GetKey(KeyCode.S)){

			transform.Translate(Vector3.down * (speed + run));
		}
		if (Input.GetKey(KeyCode.W)){

			transform.Translate(Vector3.up * (speed + run));
		}
		if (Input.GetKeyDown (KeyCode.E) && isAround("Caches")){

			Pickup();
			ajustSpeed();
		}
		if (Input.GetKeyUp (KeyCode.Space)) {

			Plant();
			ajustSpeed();
		}
	}

	bool isAround(string thing){

		GameObject t = GameObject.FindGameObjectWithTag (thing);

		thingLocation = t.transform;

		float sizex = t.transform.localScale.x;
		float sizey = t.transform.localScale.y;

		if (transform.position.x > thingLocation.position.x - sizex &&
			transform.position.x < thingLocation.position.x + sizex &&
			transform.position.y > thingLocation.position.y - sizey &&
			transform.position.y < thingLocation.position.y + sizey)
			return true;

		return false;
	}

	void Pickup(){

			treecarry += 5;
			setDisplayText ();
	}

	void Plant(){
		
		if (treecarry > 0) {
			Instantiate (sapling, transform.position - new Vector3 (-0.3f, 0.7f, 0), transform.rotation);
			treecarry--;
			money += treevalue;
		}
		setDisplayText ();
	}

	void setDisplayText(){

		playerDisplay.text = "trees : " + treecarry.ToString ()
		+ "\ncash  : " + money.ToString() + " $"
		+ "\nFault : " + fault.ToString();
	}

	void ajustSpeed(){

		speed = 0.1f;
		speed = speed * (1f - (treecarry / 300f));

		if (treecarry > 100)
			speed = 0;


	}

}
