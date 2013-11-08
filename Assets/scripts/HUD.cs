using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public GUISkin skin;
	public GUITexture snowFlakeGUITexture;
	public Rect snowFlakeCount;
	public Rect snowFlakeGUINormalizedArea;
	public Rect snowFlakeGUIArea;
	
	// Use this for initialization
	void Start () {
		//snowFlakeGUIArea = new Rect(
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		GUI.skin = skin;
		GUI.BeginGroup(snowFlakeGUIArea);
		GUI.Label(new Rect(snowFlakeCount), "100");
		GUI.EndGroup();
	}
}
