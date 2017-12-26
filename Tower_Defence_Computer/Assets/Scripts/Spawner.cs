using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	//startCellPos.GetComponent<SpriteRenderer> ().bounds.size.x / 2;
	public LevelManager LM;
	public float spawn_time = 4;
	int spawnCount = 0;
	public GameObject Unitpref;
	// Update is called once per frame
	void Update () {
//			
			if (spawn_time <= 0) {
				StartCoroutine (SpawnEnemy (spawnCount));
				spawn_time = 4;
			}
			spawn_time -= Time.deltaTime;


	}
	IEnumerator SpawnEnemy(int enemyCount){
		spawnCount++;
		for (int i = 0; i < enemyCount; i++) {
			GameObject temp_unit = Instantiate (Unitpref);
			temp_unit.transform.SetParent (gameObject.transform, false);
//			Debug.Log (GameObject.Find("LevelGroup").GetComponent<LevelManager> ().waypoints [0].transform.position.x +" "
//				+ GameObject.Find("LevelGroup").GetComponent<LevelManager> ().waypoints [0].transform.position.y);
				
			//temp_unit.transform.position = GameObject.Find("LevelGroup").GetComponent<LevelManager> ().waypoints [0].transform.position;

			//Transform startCellPos = LM.waypoints [0].transform;
			//Debug.Log (startCellPos.position.x + "  " + startCellPos.position.y);
			//temp_unit.transform.position.x = GameObject.Find("LevelGroup").GetComponent<LevelManager> ().waypoints [0].transform.position.x;
			//temp_unit.transform.position.y = GameObject.Find("LevelGroup").GetComponent<LevelManager> ().waypoints [0].transform.position.y;
			Vector3 startPos = new Vector3 (GameObject.Find("LevelGroup").GetComponent<LevelManager> ().waypoints [0].transform.position.x,
				GameObject.Find("LevelGroup").GetComponent<LevelManager> ().waypoints [0].transform.position.y);
//			Debug.Log (startPos +"sa");
			temp_unit.transform.position = startPos;
//			Debug.Log (temp_unit.transform.position);
			yield return new WaitForSeconds (0.3f);
		}
	}
}
