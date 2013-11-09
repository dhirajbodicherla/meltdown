using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoodGuy : MonoBehaviour {

	float attackInterval = 1.5f;
	float energy = 100.0f;
	float energyDrainInterval = 2.5f;
	float attackTimer;
	GameObject myEnemy;
	List<GameObject> myEnemies = new List<GameObject>();
	
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		//myEnemies = new List<Transform>();
		Game.buyGoodGuy();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Physics.Raycast (transform.position, Vector3.right, out hit, 100.0f, 1 << 9)) {
			if(hit.collider.gameObject.tag == "enemy"){
				
				Debug.DrawLine (transform.position, hit.point, Color.cyan);
				
				attackInterval -= Time.deltaTime;

				if(attackInterval <= 0){

					Shoot();
					attackInterval = 1.5f;
				}
				
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "enemy"){
			
			myEnemy = col.gameObject;
			myEnemies.Add(myEnemy);
			
			DrainEnergy();
		}
	}
	void Shoot(){
		
		GameObject bullet = Instantiate(Resources.Load("Bullet")) as GameObject;
		bullet.transform.position = new Vector3(gameObject.transform.position.x+1.0f, 
												0.9f, 
												gameObject.transform.position.z);
		
	}
	
	void DrainEnergy(){
		
		energy -= 25.0f;
		
		if(energy == 0f){
			myEnemies.ForEach(ResetEnemyMovement);
			kill();
		}else{
			InvokeRepeating("DrainEnergy", energyDrainInterval, energyDrainInterval);
		}
		
	}
	
	void ResetEnemyMovement(GameObject gameObject){
		
		//print("");

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
}
