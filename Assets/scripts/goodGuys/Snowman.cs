using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Snowman : MonoBehaviour {

	float attackInterval = 1.5f;
	float energy = 4.0f;
	float energyDrainInterval = 1f;
	float attackTimer;
	GameObject myEnemy;
	List<GameObject> myEnemies = new List<GameObject>();
	GameObject _base;
	AnimateTexture sprite;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		//myEnemies = new List<Transform>();
		_base = GameObject.FindGameObjectWithTag("base");
		_base.SendMessage("buyGoodGuy", 100.0f);
		sprite = transform.GetComponent<AnimateTexture>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Physics.Raycast (transform.position, Vector3.right, out hit, 100.0f, 1 << 9)) {
			if(hit.collider.gameObject.tag == "enemy"){
				
				//Debug.DrawLine (transform.position, hit.point, Color.cyan);
				
				sprite.fps = 2;
				
				attackInterval -= Time.deltaTime;

				if(attackInterval <= 0){

					Shoot();
					attackInterval = 1.5f;
				}
				
			}
		}else{
			sprite.fps = 0;
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
}
