using UnityEngine;
using System.Collections;

public class GameGrid : MonoBehaviour {
	
	private static int actionType = 1; // 1 - spawn good guy, 0 - delete good guy
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "bullet" || col.gameObject.tag == "goodGuy" || col.gameObject.tag == "badGuy")
			Destroy(col.gameObject);
	}
	
	void OnMouseDown(){
		
		Transform tile = Util.getClosestObject("tile", Input.mousePosition, transform);
		tile.gameObject.SendMessage("GoodGuySpawn", actionType);
		
	}
	
	public static void setActionType(int type){
		actionType = type;
	}
	
	public static int getActionType(){
		return actionType;
	}
}
