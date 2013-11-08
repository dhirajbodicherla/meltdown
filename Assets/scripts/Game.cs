using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	
	GameObject[] tiles;
	static int[] enemies;
	int tilesCount;
	static bool gameStart = false;
	float enemySpawnInterval = 6.0f;
	static int enemyDeadCount;
	static int enemySpawnCount;
	static int totalEnemiesForLevel;
	static float totalMoney;
	float snowflakeSpawnInterval = 2.0f;
	
	// Use this for initialization
	void Start () {
		tiles= GameObject.FindGameObjectsWithTag("tile");
		tilesCount = tiles.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!gameStart)
			return;
		
		enemySpawnInterval -= Time.deltaTime;
		snowflakeSpawnInterval -= Time.deltaTime;

		if(enemySpawnInterval <= 0 && enemySpawnCount != totalEnemiesForLevel){
			GenerateEnemy();
			enemySpawnInterval = 6.0f;
		}
		
		if(snowflakeSpawnInterval <= 0){
			GenerateSnowFlake();
			snowflakeSpawnInterval = Random.Range(1.0f,3.0f);
		}
		
		if(totalEnemiesForLevel == enemyDeadCount){
			//gameStart = false;
			//GameStart.proceedToNextLevel();
		}

	}

	void GenerateEnemy(){
		GameObject.Find("Tile" + Random.Range(1,6)).SendMessage("EnemySpawn", enemies[Random.Range(0, enemies.Length)]);
		enemySpawnCount++;
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
	
	public static void enemyDead(){
		enemyDeadCount++;
	}
	
	public static void gameBegin(LevelStructure level){
		
		print("enemySpawnCount before level loads: " + enemySpawnCount);
		
		Application.LoadLevel(level.getLevelName());
		
		totalMoney = level.getStartEnergy();
		totalEnemiesForLevel = level.getNumberOfEnemies();
		enemies = level.getEnemies();
		
		
		gameStart = true;
	}
	
}
