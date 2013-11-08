using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	public static int currentLevel = 0;
	
	// Use this for initialization
	void Start () {
		// fetch local storage
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find("Cube2").transform.Translate(Vector3.left * 3f * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider col){
		Game.gameBegin(Levels.levels[currentLevel]);
	}
	
	public static void proceedToNextLevel(){
		currentLevel++;
		Game.gameBegin(Levels.levels[currentLevel]);
	}
	
	public static void gameEnd(){
		Application.LoadLevel("menu");
	}
}
