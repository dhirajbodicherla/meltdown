using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public int[] location;
	string enemyType;
	//GameObject _base;
	
	// Use this for initialization
	void Start () {
		//_base = GameObject.FindGameObjectWithTag("base");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void GoodGuySpawn(int actionType){
		
        GameGrid.setActionType(0); // this will update the action type which is defined in another class (GameGrid)
    
    	//the if will still be the value receieved by GoodGuySpawn(int actionType)
    
        if(actionType == -1){
    
            if(transform.childCount < 1 )
            return;
        
            Destroy(transform.GetChild(0).gameObject);
        
        }else if(actionType != 0){
    
            switch(actionType){
                case 1:
					GoodGuy(50.0f, "Snowblower");
                    break;
                case 2:
					GoodGuy(100.0f, "Snowman");
                    break;
                case 3:
					GoodGuy(50.0f, "IceCube");
                    break;
            }
        }               
    }
	
	public void GoodGuy(float cost, string goodguy){
		
		if(Game.totalMoney < cost)
			return;
		
		GameObject gg = Instantiate(Resources.Load("goodGuys/" + goodguy)) as GameObject;
        gg.transform.position = new Vector3(gameObject.transform.position.x, 
                                                0.85f, 
                                                gameObject.transform.position.z);
        gg.transform.parent = transform;
        gg.name = goodguy;
        
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
		enemy.name = enemyType;
		
	}
	
	public void SnowFlakeSpawn(){
		
		GameObject snowFlake = Instantiate(Resources.Load("goodGuys/Snowflake")) as GameObject;
		snowFlake.transform.position = new Vector3(gameObject.transform.position.x, 
											gameObject.transform.position.y+4.0f, 
											gameObject.transform.position.z+10.0f);
		
		snowFlake.transform.parent = transform;
		snowFlake.name = "Snowflake";
		
	}
}
