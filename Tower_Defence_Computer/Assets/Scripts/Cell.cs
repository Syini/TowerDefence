using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour {
	public bool isGround, hasTower = false;
	public Color BaseColor,CurrColor;
	private void OnMouseEnter(){
		if (!isGround) {
			GetComponent<SpriteRenderer> ().color = CurrColor;
		}
	}
	private void OnMouseExit(){ 
		GetComponent<SpriteRenderer> ().color = BaseColor;
	}
	private void OnMouseDown(){
		
	}
}
