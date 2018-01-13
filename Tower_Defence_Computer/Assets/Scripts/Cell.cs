using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour {
	public bool isGround, hasTower = false;
	public Color BaseColor,CurrColor;
	public GameObject ShopPref, TowerPref;
	private void OnMouseEnter(){
		
		if (!isGround && FindObjectsOfType<ShopScript>().Length ==0 ) {
			GetComponent<SpriteRenderer> ().color = CurrColor;
		}
	}
	private void OnMouseExit(){ 
		GetComponent<SpriteRenderer> ().color = BaseColor;
	}
	private void OnMouseDown(){
		if (!isGround && FindObjectsOfType<ShopScript> ().Length == 0 && GameManager.Instance.canSpawn) {
			if (!hasTower) {
				GameObject shopobj = Instantiate (ShopPref);
				shopobj.transform.SetParent (GameObject.Find ("Canvas").transform, false);
				shopobj.GetComponent<ShopScript> ().selfcell = this;
			}
		}
	}
	public void Build(Tower tower){
		GameObject temp_tower = Instantiate (TowerPref);	
		temp_tower.transform.SetParent (transform, false);
		temp_tower.transform.position = transform.position;
		temp_tower.GetComponent<Towersrc> ().selftype = (TypeTower)tower.type;
		hasTower = true;
		FindObjectOfType<ShopScript> ().CloseShop();
	}
}
