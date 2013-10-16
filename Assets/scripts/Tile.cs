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
	void OnMouseDown () {
		if(Input.GetMouseButtonDown(0)){
			
			if(Game.getMoney() <= 0.0f)
				return;
			
			GameObject goodGuy = Instantiate(Resources.Load("GoodGuy")) as GameObject;
	        goodGuy.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+0.6f, gameObject.transform.position.z);
		}

	}
	public void EnemySpawn(){
		
		GameObject enemy = Instantiate(Resources.Load("Enemy")) as GameObject;
        enemy.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+0.3f, gameObject.transform.position.z);
		
	}
}
