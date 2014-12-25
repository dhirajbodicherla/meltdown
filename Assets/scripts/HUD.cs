using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public GUISkin skin;
	GUIStyle leftHUDStyle = new GUIStyle();
	
	static int HUDType = 1; // 1 - top and left, 2- something else
	
	private float snowFlakesCount;
	public float progress = 0.5f;
	bool gameIsPaused = false;
	bool progressBarUpdateLock = false;
	float finalProgress;
	
	/*
	 * Textures
	 */ 
	
	public Texture snowFlakeImage;
	public Texture sunImage;
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	public Texture2D pauseImage;
	public Texture snowmanImage;
	public Texture snowblowerImage;
	public Texture icecubeImage;
	public Texture shovelImage;
	
	/*
	 * Containers
	 */ 
	
	Rect topContainer = new Rect(0, -10, 640, 60);
	Rect leftContainer = new Rect(-15, 50,120, 800);
	Rect snowContainer = new Rect (10, 20, 120, 40);
	Rect shovelContainer = new Rect (138, 20, 90, 40);
	static Rect progressBarContainer = new Rect (250, 25, 250, 50);
	Rect menuButtonContainer = new Rect (540, 20, 90, 40);
	
	Rect menuContainer = new Rect(10, 10, Screen.width-20, Screen.height-20);
	
	void Start () {
		//GUI.skin = skin;
		leftHUDStyle.fontSize = 22;
		leftHUDStyle.normal.textColor = new Color(1,1,1,1);
	}
	
	void OnGUI(){
		
		if(HUDType == 1){
		
			//Vector3 xx = Util.getScreenPoint(GameObject.Find("reference").transform);
			
			topContainer.Set(0, 0, 640, 70);
			
			GUI.skin = skin;
			
			float yScale = 0.9f;
			
			GUI.matrix = Matrix4x4.TRS(new Vector3(20,0,0),Quaternion.identity,new Vector3(yScale, yScale, 1f));
			
			GUI.BeginGroup(leftContainer,"");
				//GUI.Box (new Rect(10,10,150,500), "");
			
				//snowblower
				if(GUI.Button(new Rect(30, 50, 84, 64), "")){
					GameGrid.setActionType(1);
				}
				GUI.DrawTexture(new Rect(30,50,64,64), snowblowerImage);
				GUI.Label(new Rect(88, 50, 64, 64), "50", leftHUDStyle);
			
				//snowman
				if(GUI.Button(new Rect(30, 114, 84, 64), "")){
					GameGrid.setActionType(2);
				}
				GUI.DrawTexture(new Rect(45,114,64,64), snowmanImage);
				GUI.Label(new Rect(84, 114, 64, 64), "100", leftHUDStyle);
			
				//icecube
				if(GUI.Button(new Rect(30, 178, 84, 64), "")){
					GameGrid.setActionType(3);
				}
				GUI.DrawTexture(new Rect(30,178,64,64), icecubeImage);
				GUI.Label(new Rect(88, 178, 64, 64), "50", leftHUDStyle);
			
			GUI.EndGroup ();
			
			GUI.BeginGroup(topContainer, "");
			
				/*
				 * Snow
				 */
				  
				GUI.BeginGroup(snowContainer, "");
					GUI.Box (new Rect(5,5,110,35), "");
					GUI.DrawTexture(new Rect(-5,-1,48,48), snowFlakeImage);
					GUI.Label(new Rect(55,3,60,48), snowFlakesCount + "");
				GUI.EndGroup();
				
				/*
				 * Shovel
				 */
				
				GUI.BeginGroup(shovelContainer, "");
					GUI.Box (new Rect(5, 5, 85, 35), "");
					if(GUI.Button(new Rect(5, 5, 85, 35), "")){
						GameGrid.setActionType(-1);
					}
					GUI.DrawTexture(new Rect(10, -12, 64,64), shovelImage);
				GUI.EndGroup();
				
				/*
				 * Progress bar
				 */
			
				GUI.BeginGroup (progressBarContainer, "");
			        GUI.Box (new Rect (0, 0, 250, 35), "");
			        // draw the filled-in part:
					GUI.BeginGroup (new Rect (220f-progress, 0f, 280, 45));
						GUI.Box (new Rect (25f, 0, 370, 35),"");
						GUI.DrawTexture(new Rect(-5f,-5, 48, 48), sunImage);
					GUI.EndGroup();
						
			    GUI.EndGroup ();
				//GUI.DrawTexture(new Rect(progressBarContainer.x + 230f - progress,progressBarContainer.y-5f, 48, 48), sunImage);
			
				
				/*
				 * Menu button
				 */
				GUI.BeginGroup(menuButtonContainer, "");
					GUI.Box (new Rect(5, 5, 60, 35), "");
					if(GUI.Button(new Rect(5, 5, 60, 35),"")){
						if(Time.timeScale == 1.0f){
							gamePause();
						}else{
							gameResume();
						}
					}
					GUI.DrawTexture(new Rect(20, 8, 32, 32), pauseImage);
				GUI.EndGroup();
			
			GUI.EndGroup();
			
			if(gameIsPaused){
				menuContainer = GUI.ModalWindow(0, menuContainer, menuWindow, "Paused !");
			}
			
		}
		
		if(progressBarUpdateLock){
			
			if(progress < finalProgress){
				progress += 10.0f * Time.deltaTime;
			}else{
				progressBarUpdateLock = false;
			}
		}
		
	}
	
	public void menuWindow(int windowID) {
        if (GUI.Button(new Rect(menuContainer.width/2-70, 100, 140, 70), "Resume")){
			gameResume();
		}
		
		if (GUI.Button(new Rect(menuContainer.width/2-70, 200, 140, 70), "Restart")){
			quitGame();
			PlayerPrefs.SetInt("currentLevel", 0);
		}
		
		if (GUI.Button(new Rect(menuContainer.width/2-70, 300, 140, 70), "Quit")){
			quitGame();
		}
    }
	
	void updateSnowFlakeCount(float flakesCount){
		snowFlakesCount = flakesCount;
	}
	
	void initGameHUD(){
		HUDType = 1;
		progress = 0;
	}
	
	void stopGameHUD(){
		HUDType = 0;
	}
	
	void updateProgressBar(float[] gameProgress){
		
		finalProgress = ( progressBarContainer.x * gameProgress[1] ) / gameProgress[0] - 25;
		progressBarUpdateLock = true;
		
	}
	
	void gamePause(){
		Time.timeScale = 0f;
		gameIsPaused = true;
		audio.Pause();
	}
	
	void gameResume(){
		Time.timeScale = 1.0f;
		gameIsPaused = false;
		audio.Play();
	}
	
	void quitGame(){
		Application.LoadLevel("MainMenu");
	}
	
}