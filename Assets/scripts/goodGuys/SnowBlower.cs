using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnowBlower : MonoBehaviour {

	float energy = 6.0f;
	float energyDrainInterval = 1f;
	float snowflakeSpawnInterval = 6.0f; //23
	GameObject myEnemy;
	List<GameObject> myEnemies = new List<GameObject>();
	GameObject _base;
	
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		//myEnemies = new List<Transform>();
		_base = GameObject.FindGameObjectWithTag("base");
		_base.SendMessage("buyGoodGuy", 50.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		snowflakeSpawnInterval -= Time.deltaTime;
		
		if(snowflakeSpawnInterval <= 0){
			SpawnSnowFlake();
			snowflakeSpawnInterval = Random.Range(6.0f, 8.0f);
		}
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
		
		if(GameGrid.getActionType() == -1)
			kill();
		
		GameGrid.setActionType(0);
		
	}
	
	void kill(){
		Destroy(gameObject);
	}
	
	void SpawnSnowFlake(){
		
		GameObject snowFlake = Instantiate(Resources.Load("goodGuys/Snowflake")) as GameObject;
		
		snowFlake.transform.position = new Vector3(transform.position.x,
													transform.position.y + 2.0f,
													transform.position.z + 4.0f);
													
		snowFlake.transform.parent = transform;
		
		snowFlake.name = "Snowflake";
		
					
	}
}
