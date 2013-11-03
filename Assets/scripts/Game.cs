using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	float enemySpawnInterval = 6.0f;
	static float totalMoney = 50.0f;
	float snowflakeSpawnInterval = 2.0f;
	GameObject[] tiles;
	int tilesCount;
	
	// Use this for initialization
	void Start () {
		tiles= GameObject.FindGameObjectsWithTag("tile");
		tilesCount = tiles.Length;
	}
	
	// Update is called once per frame
	void Update () {

		enemySpawnInterval -= Time.deltaTime;
		snowflakeSpawnInterval -= Time.deltaTime;

		if(enemySpawnInterval <= 0){
			GenerateEnemy();
			enemySpawnInterval = 6.0f;
		}
		
		if(snowflakeSpawnInterval <= 0){
			GenerateSnowFlake();
			snowflakeSpawnInterval = Random.Range(1.0f,3.0f);
		}

	}

	void GenerateEnemy(){
		GameObject.Find("Tile" + Random.Range(1,6)).SendMessage("EnemySpawn", Random.Range(1,4));
	}
	
	void GenerateSnowFlake(){
		tiles[Random.Range(1,tilesCount)].SendMessage("SnowFlakeSpawn");
	}
	
	public static void buyGoodGuy(){
		totalMoney -= 20.0f;
	}
	
	public static void killGoodGuy(){
		totalMoney += 20.0f;
	}
	public static void collectSnowFlake(){
		totalMoney += 10.0f;
		print("Total money is : " + totalMoney);
	}
	public static float getMoney(){
		return totalMoney;
	}
}
