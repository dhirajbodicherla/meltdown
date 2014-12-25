using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {

	private Engine engine;
	
	// Use this for initialization
	void Start () {
		engine = transform.parent.GetComponentInChildren<Engine>();
	}
	
	// Update is called once per frame
	void Update () {
		//
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "enemy"){
			engine.gameEnd();
		}
	}
}
