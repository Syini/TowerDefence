using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower{
	public float range,Cooldown, currCooldown = 0;
	public Sprite Spr;
	public Tower(float range, float cd,string path){
		this.range = range;
		Cooldown = cd;
		Spr = Resources.Load<Sprite> (path);
	}
}
public class Towerprojectile{
	 
}
public enum TypeTower{
	First_tower,Second_tower
}
public class GameLogic : MonoBehaviour {
	public List<Tower> AllTowers =  new List<Tower>();
	public void Awake(){
		AllTowers.Add (new Tower (40, 0.3f,"TowerSpr/First"));
		AllTowers.Add (new Tower (70, 0.9f,"TowerSpr/Second"));
	}
}
