using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnowBlower : MonoBehaviour {

	float energy = 6.0f;
	float energyDrainInterval = 1f;
	GameObject myEnemy;
	List<GameObject> myEnemies = new List<GameObject>();
	GameObject _base;
	
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		//myEnemies = new List<Transform>();
		_base = GameObject.FindGameObjectWithTag("base");
		_base.SendMessage("buyGoodGuy");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "enemy"){
			
			myEnemy = col.gameObject;
			myEnemies.Add(myEnemy);
			
			DrainEnergy();
		}
	}
	
	void DrainEnergy(){
		
		energy -= 1.0f;
		
		if(energy == 0f){
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
		
		if(GameGrid.getActionType() == 0)
			kill();
		
		GameGrid.setActionType(1);
		
	}
	
	void kill(){
		Destroy(gameObject);
	}
	
	void SpawnSnowFlake(){
		
		GameObject snowFlake = Instantiate(Resources.Load("goodGuys/Snowflake")) as GameObject;
		snowFlake.transform.position = transform.position;
		
		snowFlake.transform.parent = transform;
		snowFlake.name = "Snowflake";
		
					
	}
}
