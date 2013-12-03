using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public GUISkin skin;
	
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
	
	/*
	 * Containers
	 */ 
	
	Rect topContainer = new Rect(-10, -10, 640, 60);
	Rect leftContainer = new Rect(-10, 100, 150, 800);
	Rect snowContainer = new Rect (10, 20, 120, 40);
	Rect shovelContainer = new Rect (138, 20, 90, 40);
	static Rect progressBarContainer = new Rect (250, 25, 250, 50);
	Rect menuButtonContainer = new Rect (540, 20, 90, 40);
	
	void Start () {
		//GUI.skin = skin;
	}
	
	void OnGUI(){
		
		if(HUDType == 1){
		
			//Vector3 xx = Util.getScreenPoint(GameObject.Find("reference").transform);
			
			topContainer.Set(0, 0, 640, 70);
			
			GUI.skin = skin;
			
			float yScale = 0.9f;
			
			GUI.matrix = Matrix4x4.TRS(new Vector3(50,0,0),Quaternion.identity,new Vector3(yScale, yScale, 1f));
			
			GUI.BeginGroup(leftContainer,"");
				GUI.Box (new Rect(10,10,150,500), "");
				//snowblower
				
				if(GUI.Button(new Rect(30, 50, 100, 100), "")){
					GameGrid.setActionType(1);
				}
				GUI.DrawTexture(new Rect(10,20,150,150), snowblowerImage);
				//snowman
				if(GUI.Button(new Rect(30, 150, 100, 100), "")){
					GameGrid.setActionType(2);
				}
				GUI.DrawTexture(new Rect(10,120,150,150), snowmanImage);
				//icecube
				if(GUI.Button(new Rect(30, 250, 100, 100), "")){
					GameGrid.setActionType(3);
				}
				GUI.DrawTexture(new Rect(10,220,150,150), icecubeImage);	
			
				GUI.EndGroup();
			
			GUI.EndGroup ();
			
			GUI.BeginGroup(topContainer, "");
			
				/*
				 * Snow
				 */
				  
				GUI.BeginGroup(snowContainer, "");
					GUI.Box (new Rect(5,5,110,35), "");
					GUI.DrawTexture(new Rect(-5,-1,48,48), snowFlakeImage);
					GUI.Label(new Rect(50,1,60,48), snowFlakesCount + "");
				GUI.EndGroup();
				
				/*
				 * Shovel
				 */
				
				GUI.BeginGroup(shovelContainer, "");
					GUI.Box (new Rect(5, 5, 85, 35), "");
					if(GUI.Button(new Rect(15, 8, 60, 28), "shovel")){
						GameGrid.setActionType(0);
					}
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
					GUI.Box (new Rect(5, 5, 85, 35), "");
					if(GUI.Button(new Rect(15, 8, 60, 28), pauseImage)){
						if(Time.timeScale == 1.0f){
							Time.timeScale = 0f;
							gameIsPaused = true;
						}else{
							Time.timeScale = 1.0f;
							gameIsPaused = false;
						}
					}
				GUI.EndGroup();
			
			GUI.EndGroup();
			
		}
		
		if(progressBarUpdateLock){
			
			if(progress < finalProgress){
				progress += 10.0f * Time.deltaTime;
			}else{
				progressBarUpdateLock = false;
			}
		}
		
	}
	
	void updateSnowFlakeCount(float flakesCount){
		snowFlakesCount = flakesCount;
	}
	
	void initGameHUD(){
		HUDType = 1;
		progress = 0;
	}
	
	void updateProgressBar(float[] gameProgress){
		
		finalProgress = ( progressBarContainer.x * gameProgress[1] ) / gameProgress[0];
		progressBarUpdateLock = true;
		
	}
	
}