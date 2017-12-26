using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	int wayIndex = 0;
	public int speed = 7;
	public int health = 30;



	public List<GameObject> wayPoints =  new List<GameObject>();

	private void  Start(){
		Getwaypoints ();
	}


	// Update is called once per frame
	void Update () {

		Move ();
		isAlive ();

	}
	void Getwaypoints(){
		//Debug.Log("gotcha");
		//Debug.Log(GameObject.Find("LevelGroup").GetComponent<LevelManager>().q);
		wayPoints = GameObject.Find("LevelGroup").GetComponent<LevelManager> ().waypoints;
		for (int i = 0; i < wayPoints.Capacity; i++) {
			//	Debug.Log("WayPoints = "+ wayPoints[i].transform.position.x +"   "+ wayPoints[i].transform.position.y);
		}

	}
	private void Move(){

		Transform currWayPoint = wayPoints [wayIndex].transform;

		//Debug.Log (GameObject.Find ("LevelGroup").GetComponent<LevelManager> ().waypoints [wayIndex].transform.position.x + " "
		//	+ GameObject.Find ("LevelGroup").GetComponent<LevelManager> ().waypoints [wayIndex].transform.position.y);
		Vector3 currWayPos = new Vector3 (wayPoints[wayIndex].transform.position.x + currWayPoint.GetComponent<SpriteRenderer>().bounds.size.x/2,
			wayPoints[wayIndex].transform.position.y - currWayPoint.GetComponent<SpriteRenderer>().bounds.size.y/2, transform.position.z);
		//Debug.Log ("check " + wayPoints [0].transform.position.x + " " + wayPoints [0].transform.position.y); 
		//Debug.Log ("check " + wayPoints [1].transform.position.x + " " + wayPoints [1].transform.position.y); 
		//Debug.Log ("откуда " + transform.position.x +"   " + transform.position.y);
		//Debug.Log (currWayPos +"куда");
		//Debug (transform.position);

		Vector2	direction = currWayPos - transform.position ;

		//Debug.Log (direction);
		//Debug.Log (direction.normalized);	
		//transform.position.x = currWayPoint.position.x;
		//transform.position.y = currWayPoint.position.y;	
		//transform.position.Set();
		transform.Translate(direction*Time.deltaTime*speed, Space.World);
		if (Vector3.Distance (transform.position, currWayPos) < 0.3f) {
			if (wayIndex < wayPoints.Count - 1) {
				wayIndex++;
			}
			else
				Destroy (gameObject	);
		}

	}



	public void TakeDamage(int damage){
		health -= damage;
	}
	void isAlive(){
		if (health <= 0) {
			Destroy (gameObject);
		}
	}
}
