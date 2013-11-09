using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public GUISkin skin;
	private static float snowFlakesCount;
	public Texture snowFlakeImage;
	
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	public Vector3 pos = new Vector3(330,95,0);
	public Vector3 size = new Vector3(240,30,0);
	public float barDisplay = 30;
	//public Rect snowFlakeGUINormalizedArea;
	
	// Use this for initialization
	void Start () {
		
		//GUI.skin = skin;
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		
		GUI.skin = skin;
		
		Rect snowContainer = new Rect (55,95, 90, 30);
		Rect shovelContainer = new Rect (190,95, 90, 30);
		Rect menuButtonContainer = new Rect (630,95, 90, 30);
		
		/*
		 * Snow
		 */
		  
		GUI.Box (snowContainer, "");
		GUI.DrawTexture(new Rect(38,85,48,48), snowFlakeImage);
		GUI.Label(new Rect(110,88,48,48), snowFlakesCount + "");
		
		/*
		 * Shovel
		 */
		
		GUI.Box (shovelContainer, "");
		if(GUI.Button(new Rect(200,96,60,28), "shovel")){
			GameGrid.setActionType(0);
		}
		
		/*
		 * Progress bar
		 */
		
		GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
	        GUI.Box (new Rect (0,0, size.x, size.y),progressBarEmpty);
	        // draw the filled-in part:
	        GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
	            GUI.Box (new Rect (0,0, size.x, size.y), progressBarFull);
	        GUI.EndGroup ();
	 
	    GUI.EndGroup ();
		
		/*
		 * Menu button
		 */
		GUI.Box (menuButtonContainer, "");
		if(GUI.Button(new Rect(645,96,60,28), "Menu")){
			Application.LoadLevel(0);
		}
		
	}
	public static void updateSnowFlakeCount(float flakesCount){
		snowFlakesCount = flakesCount;
	}
}
