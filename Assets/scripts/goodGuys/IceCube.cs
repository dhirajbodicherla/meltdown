using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IceCube : MonoBehaviour {

	float energy = 7.0f;
	float energyDrainInterval = 1f;
	GameObject myEnemy;
	List<GameObject> myEnemies = new List<GameObject>();
	AnimateTexture sprite;
	GameObject _base;
	
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		//myEnemies = new List<Transform>();
		_base = GameObject.FindGameObjectWithTag("base");
		_base.SendMessage("buyGoodGuy", 50.0f);
		sprite = transform.GetComponent<AnimateTexture>();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		energy -= 1.0f * Time.deltaTime;
		if (energy == 0) {
			myEnemies.ForEach(ResetEnemyMovement);
			kill();
		}
		*/
	}
	

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "enemy"){
			
			myEnemy = col.gameObject;
			myEnemies.Add(myEnemy);
			
			sprite.fps = 1;
			
			DrainEnergy();
			
		}
	}
	
	void DrainEnergy(){
		
		energy -= 1.0f;
		
		if(energy <= 0f){
			
			myEnemies.ForEach(ResetEnemyMovement);
			kill();
		}else{
			InvokeRepeating("DrainEnergy", energyDrainInterval, energyDrainInterval);
		}
	}
	
	void ResetEnemyMovement(GameObject gameObject){

		if(gameObject)
			gameObject.SendMessage("MoveAgain");
		
	}
	void OnMouseDown(){
		
		if(GameGrid.getActionType() == -1)
			kill();
		
		GameGrid.setActionType(0);
		
	}
	
	void kill(){
		Destroy(gameObject);
	}
}
