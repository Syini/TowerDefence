using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towersrc : MonoBehaviour {
	float range =300;
	public float Cooldown,currCooldown;
	public GameObject Projectile;
//	GameLogic gl;
//	Tower selftower;
//	public TypeTower selftype;
//	private void Start(){
//		gl = FindObjectOfType<GameLogic>();
//		selftower = FindObjectOfType<GameLogic>().AllTowers [(int)selftype];
//		GetComponent<SpriteRenderer> ().sprite = selftower.Spr;
//	}
	void Update(){
		if (CanShoot ()) {
			SearchforTarget ();
		}
		if (currCooldown > 0) {
			currCooldown -= Time.deltaTime;
		}
	}

	bool CanShoot(){
		if (currCooldown <= 0) {
			return true;
		}
		return false;	

	}
	void SearchforTarget(){
		Transform nearestUnit = null;
		float nearestUnitdistance = Mathf.Infinity;
		foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Unit")) {
			float currDistance = Vector2.Distance (transform.position, unit.transform.position);
			if (currDistance <= range && currDistance <=nearestUnitdistance) {
				nearestUnit = unit.transform;
				nearestUnitdistance = currDistance;
			}

		}
		if (nearestUnit != null) {
			Shoot (nearestUnit);
		}
	}
	void Shoot(Transform unit){
		currCooldown = Cooldown;
		GameObject proj = Instantiate (Projectile);
		Vector3 startPos = new Vector3 (transform.position.x +GetComponent<SpriteRenderer>().bounds.size.x/2,
			transform.position.y );
		proj.transform.position = startPos;
		proj.GetComponent<TowerProject> ().setTarget (unit);
	}
}
