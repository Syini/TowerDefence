using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public static GameController Instance;
	public GameObject Menu;
	public bool canSpawn = false;	
	public void playBtn(){
		Destroy (GameObject.Find ("Menu"));
		//Menu.SetActive (false);
		canSpawn = true;
//		if (Input.GetKeyDown (KeyCode.Escape)) {
//			ToMenu ();
//		}z
	}
	public void QuitBtn(){
		Application.Quit();
	}
//	public void ToMenu(){
//		Menu.SetActive (true);
//		canSpawn = false;	
//	}
}
	