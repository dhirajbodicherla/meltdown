using UnityEngine;
using System.Collections;

public class MainMenuBtns : MonoBehaviour {
	
	public bool loadlevel = false;
	public Texture2D normalTexture;
	public Texture2D rollOverTexture;
	public GameObject clicktoshow;
	public AudioClip beep;
	public bool quitButton = false;
	// Use this for initialization
	
	void Start () {
		//PlayerPrefs.DeleteKey("currentLevel");
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
	void OnMouseOver(){
		if (Input.GetMouseButtonDown (0)){
			/*
			if (clicktoshow.activeInHierarchy == true)
				clicktoshow.SetActive(false); 
			if (clicktoshow.activeInHierarchy == false)
				clicktoshow.SetActive(true);
			*/
			
			Application.LoadLevel(Levels.levels[Engine.currentLevel].getSceneName());
		}
	}
	
	void OnMouseExit(){
		guiTexture.texture = normalTexture;
	}
	IEnumerator OnMouseUp(){
		audio.PlayOneShot(beep);
		yield return new WaitForSeconds(0.35f);
		if(quitButton){
			PlayerPrefs.DeleteKey("currentLevel");
		}
		else{
			if(loadlevel == true){
				Application.LoadLevel(Levels.levels[Engine.currentLevel].getSceneName());
			}
		}
	}
	
	
}
