using UnityEngine;
using System.Collections;

public class GoodGuy : MonoBehaviour {

	float attackInterval = 1.5f;
	float energy = 100.0f;
	float attackTimer;

	// Use this for initialization
	void Start () {
		Game.buyGoodGuy();
	}
	
	// Update is called once per frame
	void Update () {

		attackInterval -= Time.deltaTime;

		if(attackInterval <= 0){
			
			Shoot();
			attackInterval = 1.5f;
			
		}
		
		if(Input.GetMouseButtonDown(1)){
			Game.killGoodGuy();
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "enemy"){
			energy -= 25.0f;

			if(energy == 0f){
				Destroy(gameObject);
			}
		}
	}
	void Shoot(){
		GameObject bullet = Instantiate(Resources.Load("Bullet")) as GameObject;
		bullet.transform.position = new Vector3(gameObject.transform.position.x+1.0f, gameObject.transform.position.y-0.4f, gameObject.transform.position.z);
	}
}
