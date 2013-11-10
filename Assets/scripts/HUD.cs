using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public GUISkin skin;
	
	static int HUDType = 0; // 1 - top and left, 2- something else
	
	private static float snowFlakesCount;
	public float barDisplay = 0.5f;
	
	public Texture snowFlakeImage;
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	
	public Rect topContainer = new Rect(-10, -10, 640, 60);
	
	Rect snowContainer = new Rect (10, 20, 120, 40);
	Rect shovelContainer = new Rect (138, 20, 90, 40);
	Rect progressBarContainer = new Rect (250, 25, 250, 40);
	Rect menuButtonContainer = new Rect (540, 20, 90, 40);
	
	//public Rect snowFlakeGUINormalizedArea;
	
	// Use this for initialization
	void Start () {
		
		//GUI.skin = skin;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		
		if(HUDType == 1){
		
			float xx = Util.getScreenPoint(GameObject.Find("reference").transform).x;
			
			topContainer.Set(xx, -10, 640, 60);
			
			GUI.skin = skin;
			
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
			        GUI.BeginGroup (new Rect (0, 0, 250 * barDisplay, 35));
			            GUI.Box (new Rect (0, 0, 250, 35), progressBarFull);
			        GUI.EndGroup ();
			    GUI.EndGroup ();
				
				/*
				 * Menu button
				 */
				GUI.BeginGroup(menuButtonContainer, "");
					GUI.Box (new Rect(5, 5, 85, 35), "");
					if(GUI.Button(new Rect(15, 8, 60, 28), "Menu")){
						Application.LoadLevel(0);
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
	}
}
