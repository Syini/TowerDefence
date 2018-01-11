using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	int wayIndex = 0;

	public List<GameObject> wayPoints =  new List<GameObject>();
	public Enemy selfEnemy;
	public float currHealth;
	private void  Start(){

		Getwaypoints ();
		GetComponent<SpriteRenderer> ().sprite = selfEnemy.spr;
	}


	// Update is called once per frame
	void Update () {

		Move ();
		currHealth = selfEnemy.Health;

	}
	void Getwaypoints(){

		wayPoints = GameObject.Find("LevelGroup").GetComponent<LevelManager> ().waypoints;


	}
	private void Move(){

		Transform currWayPoint = wayPoints [wayIndex].transform;

		Vector3 currWayPos = new Vector3 (wayPoints[wayIndex].transform.position.x + currWayPoint.GetComponent<SpriteRenderer>().bounds.size.x/2,
			wayPoints[wayIndex].transform.position.y - currWayPoint.GetComponent<SpriteRenderer>().bounds.size.y/2, transform.position.z);

		Vector2	direction = currWayPos - transform.position ;

		transform.Translate(direction*Time.deltaTime*selfEnemy.Speed, Space.World);
		if (Vector3.Distance (transform.position, currWayPos) < 1f) {
			if (wayIndex < wayPoints.Count - 1) {
				wayIndex++;
			}
			else
				Destroy (gameObject	);
		}

	}



	public void TakeDamage(float damage){
		selfEnemy.Health -= damage;
		isAlive ();
	}
	void isAlive(){
		if (selfEnemy.Health <= 0) {
			MoneyManager.Instance.GameMoney += 5;
			Destroy (gameObject);

		}
	}
	public void StartSlow(float duration,float slowvalue){
		selfEnemy.Speed = selfEnemy.Startspeed;
		StopCoroutine("GetSlow");
		StartCoroutine(GetSlow(duration,slowvalue));
	}
	IEnumerator GetSlow(float duration,float slowvalue){
		selfEnemy.Speed -= slowvalue;
		yield return new WaitForSeconds (duration);
		selfEnemy.Speed = selfEnemy.Startspeed;
	}
	public void AOEplzWork(float range,float damage){
		List<Unit> units = new List<Unit>();
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Unit")) {
			if (Vector2.Distance (transform.position, go.transform.position) <= range) {
				units.Add (go.GetComponent<Unit> ());
			}
		}
		foreach (Unit es in units) {
			es.TakeDamage (damage);
		}

	}
}
