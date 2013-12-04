using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {

	public static int currentLevel = 0;
	GameObject _base;
	public GUITexture gameOver;
	
	// Use this for initialization
	void Start () {
		_base = GameObject.FindGameObjectWithTag("base");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void gameEnd(){
		//Application.LoadLevel("MainMenu");
		//Instantiate(gameOver);
		gameOver.enabled = true;
	}
	
	public void proceedToNextLevel(){
		print("proceed called in engine " + currentLevel);
		currentLevel++;
		PlayerPrefs.SetInt("currentLevel", currentLevel);
		print ("curr: " + currentLevel + " :: " + Levels.levels[currentLevel].getSceneName());
		Application.LoadLevel(Levels.levels[currentLevel].getSceneName());
	}
}
