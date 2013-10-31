using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public int[] location;

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
	public void EnemySpawn(){
		
		GameObject enemy = Instantiate(Resources.Load("Enemy")) as GameObject;
        enemy.transform.position = new Vector3(gameObject.transform.position.x, 
											0.85f, 
											gameObject.transform.position.z);
		
	}
}
