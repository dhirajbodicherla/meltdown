// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {

	public Texture2D icon;
	public Texture2D icon2;
	public Texture2D icon3;

	void OnGUI () {
		if (GUI.Button (new Rect (675,400, 100, 50), icon)) {
			print ("you clicked the icon");
		}
		if (GUI.Button (new Rect (275,50, 100, 50), icon2)) {
			print ("you clicked the icon");
		}
		if (GUI.Button (new Rect (275,100, 100, 50), icon3)) {
			print ("you clicked the icon");
		}

		if (GUI.Button (new Rect (10,70, 100, 20), "This is text")) {
			print ("you clicked the text button");
		}
	}

}