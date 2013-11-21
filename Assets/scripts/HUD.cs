using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public GUISkin skin;
	
	static int HUDType = 1; // 1 - top and left, 2- something else
	
	private static float snowFlakesCount;
	public static float progress = 0.5f;
	private bool gameIsPaused = false;
	
	/*
	 * Textures
	 */ 
	
	public Texture snowFlakeImage;
	public Texture sunImage;
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	public Texture2D pauseImage;
	
	/*
	 * Containers
	 */ 
	
	Rect topContainer = new Rect(-10, -10, 640, 60);
	Rect snowContainer = new Rect (10, 20, 120, 40);
	Rect shovelContainer = new Rect (138, 20, 90, 40);
	static Rect progressBarContainer = new Rect (250, 25, 250, 50);
	Rect menuButtonContainer = new Rect (540, 20, 90, 40);
	
	void Start () {
		
		//GUI.skin = skin;
		
	}
	
	void Update () {
	
	}
	
	void OnGUI(){
		
		if(HUDType == 1){
		
			//Vector3 xx = Util.getScreenPoint(GameObject.Find("reference").transform);
			
			topContainer.Set(0, 0, 640, 70);
			
			GUI.skin = skin;
			
			float yScale = 0.9f;
			
			GUI.matrix = Matrix4x4.TRS(new Vector3(50,0,0),Quaternion.identity,new Vector3(yScale, yScale, 1f));
			
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
					GUI.BeginGroup (new Rect (220f-progress, 0f, 260, 45));
						GUI.Box (new Rect (25f, 0, 290, 35),"");
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
		
	}
	
	public static void updateSnowFlakeCount(float flakesCount){
		snowFlakesCount = flakesCount;
	}
	
	public static void initGameHUD(){
		HUDType = 1;
		progress = 0;
	}
	
	public static void updateProgressBar(float enemiesTotal, float enemiesCurrent){
		
		progress = ( progressBarContainer.x * enemiesCurrent ) / enemiesTotal;
		//progress += 1f;
		//StartCoroutine(progressBarTransition());
		
	}
	/*
	static IEnumerator progressBarTransition(){
		
	}
	*/
}
