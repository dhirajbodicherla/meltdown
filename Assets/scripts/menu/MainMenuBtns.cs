using UnityEngine;
using System.Collections;

public class MainMenuBtns : MonoBehaviour {

	public bool loadlevel = false;
	public Texture2D normalTexture;
	public Texture2D rollOverTexture;
	public GameObject clicktoshow;
	public AudioClip beep;
	public bool quitButton = false;
	
	void Start () {
		if(PlayerPrefs.HasKey("currentLevel")){
			Engine.currentLevel = PlayerPrefs.GetInt("currentLevel");
		}else{
			Engine.currentLevel = 0;
			PlayerPrefs.SetInt("currentLevel", Engine.currentLevel);
		}
	}
	
	void OnMouseEnter(){
		guiTexture.texture = rollOverTexture;
	}
	void OnMouseDown(){
		if (Input.GetMouseButtonDown (0)){
			//StartCoroutine("applicationLoader", transform.tag);
			applicationLoader(transform.tag);
		}
	}
	
	void OnMouseExit(){
		guiTexture.texture = normalTexture;
	}
	
	void applicationLoader(string tag){
		
		//AudioSource.PlayClipAtPoint(beep, transform.position);
		//yield return new WaitForSeconds(0.35f);
		
		if(tag == "play"){
			checkCurrentLevel();
			Application.LoadLevel(Levels.levels[Engine.currentLevel].getSceneName());
		}else if(tag == "credits"){
			
		}else if(tag == "instructions"){
			
		}else if(tag == "quit"){
			PlayerPrefs.DeleteKey("currentLevel");
			Application.Quit();
		}else{
			
		}
	}
	void checkCurrentLevel(){
		if(PlayerPrefs.HasKey("currentLevel")){
			Engine.currentLevel = PlayerPrefs.GetInt("currentLevel");
		}else{
			Engine.currentLevel = 0;
			PlayerPrefs.SetInt("currentLevel", Engine.currentLevel);
		}
	}
}
