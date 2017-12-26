using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	

public class MoneyManager : MonoBehaviour {
	public static MoneyManager Instance;
	public Text MoneyText;
	public int GameMoney;
	// Use this for initialization
	void Awake () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		MoneyText.text = GameMoney.ToString ();
	}
}
