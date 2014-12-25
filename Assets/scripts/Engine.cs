using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {

	public static int currentLevel = 0;
	GameObject _base;
	public GUITexture gameOver;
	public GUITexture gameWinTexture;
	private HUD hud;
	private Game game;
	
	// Use this for initialization
	void Start () {
		_base = GameObject.FindGameObjectWithTag("base");
		hud = transform.GetComponentInChildren<HUD>();
		game = transform.GetComponentInChildren<Game>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void gameEnd(){
		audio.Stop();
		//gameOver.enabled = true;
		Instantiate(gameOver);
		hud.SendMessage("stopGameHUD");
		game.SendMessage("stopGame");
	}
	
	public void proceedToNextLevel(){
		currentLevel++;
		if(Levels.levels.Length < currentLevel+1){
			//gameWin();
			StartCoroutine("gameWin");
			return;
		}
			
		PlayerPrefs.SetInt("currentLevel", currentLevel);
		Application.LoadLevel(Levels.levels[currentLevel].getSceneName());
		
	}
	public IEnumerator gameWin(){
		audio.Stop();
		Instantiate(gameWinTexture);
		hud.SendMessage("stopGameHUD");
		game.SendMessage("stopGame");
		
		yield return new WaitForSeconds(10.0f);
		
		PlayerPrefs.SetInt("currentLevel", 0);
		Application.LoadLevel(0);
		
	}
	
}
