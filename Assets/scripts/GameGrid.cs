using UnityEngine;
using System.Collections;

public class GameGrid : MonoBehaviour {
	
	
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerExit(Collider col){
		//if(col.gameObject.tag == "bullet")
			Destroy(col.gameObject);
	}
	
	void OnMouseDown(){
		
		Transform tile = Util.getClosestObject("tile", Input.mousePosition, transform);
		tile.gameObject.SendMessage("GoodGuySpawn");
		
	}
}
