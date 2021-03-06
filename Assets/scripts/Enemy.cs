﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	float speed = 0.1f;
	float energy = 96.0f;
	bool movementFlag = true;
	GameObject _base;

	// Use this for initialization
	void Start () {
		_base = GameObject.FindGameObjectWithTag("base");
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
			energy -= 8.0f;

			if(energy == 0.0f){
				Die();
			}
		}else if(col.gameObject.tag == "goodGuy"){
			movementFlag = false;
			attack(col.transform);
			
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
		_base.SendMessage("enemyDead");
		//Game.enemyDead();
		
		Destroy(gameObject);
	}
	
	void attack(Transform goodGuy){
		//goodGuy.SendMessage("DrainEnergy");
	}
	
}
