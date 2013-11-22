using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	private int currentLevel = 0;
	
	// Use this for initialization
	void Start () {
		// fetch local storage
		if(PlayerPrefs.HasKey("currentLevel")){
			currentLevel = PlayerPrefs.GetInt("currentLevel");
		}else{
			currentLevel = 0;
			PlayerPrefs.SetInt("currentLevel", currentLevel);
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find("Cube2").transform.Translate(Vector3.left * 3f * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider col){
		Application.LoadLevel(currentLevel);
	}
	
	public void proceedToNextLevel(){
		currentLevel++;
		//Game.gameBegin(Levels.levels[currentLevel]);
	}
	
	public static void gameEnd(){
		Application.LoadLevel("menu");
	}
}
