using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	float speed = 0.5f;
	float energy = 100.0f;
	bool movementFlag = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(movementFlag){
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}else{
			//attack();
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "bullet"){
			energy -= 25.0f;

			if(energy == 0.0f){
				Destroy(gameObject);
			}
		}else if(col.gameObject.tag == "goodGuy"){
			
			movementFlag = false;
			
		}else if(col.gameObject.tag == "enemy"){
			
			movementFlag = false;
			
		}
		if(col.gameObject.name == "Snowmobile"){
			
			//die animation
			Die();
			
		}
	}
	
	void OnTriggerExit(Collider col){
		
		if(col.gameObject.tag == "enemy")
			movementFlag = true;
	}
	
	void MoveAgain(){
		movementFlag = true;
	}
	
	void Die(){
		Destroy(gameObject);
	}
	
}
