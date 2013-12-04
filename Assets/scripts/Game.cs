using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	
	GameObject[] tiles;
	int[] enemies;
	int tilesCount;
	bool gameStart = false;
	float enemySpawnInterval = 20.0f;
	int enemyDeadCount;
	int enemySpawnCount;
	int totalEnemiesForLevel;
	public static float totalMoney;
	float snowflakeSpawnInterval = 7.0f;
	private HUD hud;
	private Engine engine;
	LevelStructure level;
	
	// Use this for initialization
	void Start () {
		tiles= GameObject.FindGameObjectsWithTag("tile");
		tilesCount = tiles.Length;
		hud = transform.GetComponentInChildren<HUD>();
		engine = transform.GetComponentInChildren<Engine>();
		gameBegin();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!gameStart)
			return;
		
		enemySpawnInterval -= Time.deltaTime;
		snowflakeSpawnInterval -= Time.deltaTime;

		if(enemySpawnInterval <= 0 && enemySpawnCount != totalEnemiesForLevel){
			GenerateEnemy();
			enemySpawnInterval = 20.0f;
		}
		
		if(snowflakeSpawnInterval <= 0){
			GenerateSnowFlake();
			snowflakeSpawnInterval = Random.Range(6.0f, 8.0f);
		}
		
		if(totalEnemiesForLevel == enemyDeadCount){
			gameStart = false;
			engine.SendMessage("proceedToNextLevel");
		}

	}

	void GenerateEnemy(){
		GameObject.Find("Tile" + Random.Range(1,6)).SendMessage("EnemySpawn", enemies[Random.Range(0, enemies.Length)]);
		enemySpawnCount++;
		updateProgress();
	}
	
	void GenerateSnowFlake(){
		tiles[Random.Range(1,tilesCount)].SendMessage("SnowFlakeSpawn");
	}
	
	public void buyGoodGuy(float cost){
		totalMoney -= cost;
		updateHUD();
	}
	
	public void collectSnowFlake(){
		totalMoney += 25.0f;
		updateHUD();
	}
	public float getMoney(){
		return totalMoney;
	}
	
	void enemyDead(){
		enemyDeadCount++;
	}
	
	void gameBegin(){
		
		//print("enemySpawnCount before level loads: " + enemySpawnCount);
		level = Levels.levels[PlayerPrefs.GetInt("currentLevel")];
		
		//Application.LoadLevel(level.getSceneName());
		
		totalMoney = level.getStartEnergy();
		totalEnemiesForLevel = level.getNumberOfEnemies();
		enemies = level.getEnemies();
		//sceneName = level.getSceneName();
		
		initHUD();
		
		updateHUD();
		
		gameStart = true;
	}
	
	void updateHUD(){
		hud.SendMessage("updateSnowFlakeCount", totalMoney);
	}
	
	void initHUD(){
		//HUD.initGameHUD();
		hud.SendMessage("initGameHUD");
		
	}
	
	void updateProgress(){
		
		hud.SendMessage("updateProgressBar", new float[]{totalEnemiesForLevel, enemySpawnCount});
		
	}
}
