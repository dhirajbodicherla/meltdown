using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public int[] location;
	string enemyType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void GoodGuySpawn() {
		
		if(transform.childCount > 0 )
			return;
		
		if(Game.getMoney() <= 0.0f)
			return;
		
		GameObject goodGuy = Instantiate(Resources.Load("GoodGuy")) as GameObject;
        goodGuy.transform.position = new Vector3(gameObject.transform.position.x, 
												0.85f, 
												gameObject.transform.position.z);
		goodGuy.transform.parent = transform;
	
	}
	public void EnemySpawn(int type){
	
		switch(type){
			case 1:
				enemyType = "Sun";
				break;
			case 2:
				enemyType = "Snowblower";
				break;
			case 3:			
				enemyType = "Hairdryer";
				break;
			case 4:
				enemyType = "lighter";
				break;
		}
		enemy();
	}
	
	void enemy(){
		
		GameObject enemy = Instantiate(Resources.Load("Enemies/" + enemyType)) as GameObject;
        enemy.transform.position = new Vector3(gameObject.transform.position.x, 
											0.85f, 
											gameObject.transform.position.z);
		
	}
	
	public void SnowFlakeSpawn(){
		
		GameObject snowFlake = Instantiate(Resources.Load("goodGuys/Snowflake")) as GameObject;
		snowFlake.transform.position = new Vector3(gameObject.transform.position.x, 
											gameObject.transform.position.y+4.0f, 
											gameObject.transform.position.z+10.0f);
		
		snowFlake.transform.parent = transform;
		
	}
}
