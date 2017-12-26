using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProject : MonoBehaviour {
	Transform target;
	float speed = 90;
	int damage =10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}
	public void setTarget(Transform unit){
		target = unit;
	}
	private void Move(){
		if (target != null) {
			if (Vector2.Distance (transform.position, target.position) < 0.1f) {
				target.GetComponent<Unit> ().TakeDamage(damage);
				Destroy (gameObject);
			} else {
				Vector2 dir = target.position - transform.position;
				transform.Translate (dir.normalized * Time.deltaTime * speed, Space.World);
			}
		} else {
			Destroy (gameObject);
		}
	}
}
