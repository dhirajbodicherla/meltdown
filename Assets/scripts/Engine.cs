using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {

	public static int currentLevel = 0;
	GameObject _base;
	
	// Use this for initialization
	void Start () {
		_base = GameObject.FindGameObjectWithTag("base");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void gameEnd(){
		Application.LoadLevel("MainMenu");
	}
	
	public void proceedToNextLevel(){
		print("proceed called in engine " + currentLevel);
		currentLevel++;
		PlayerPrefs.SetInt("currentLevel", currentLevel);
		print ("curr: " + currentLevel + " :: " + Levels.levels[currentLevel].getSceneName());
		Application.LoadLevel(Levels.levels[currentLevel].getSceneName());
	}
}
