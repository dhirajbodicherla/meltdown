﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	float enemySpawnInterval = 2.0f;
	static float totalMoney = 100.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		enemySpawnInterval -= Time.deltaTime;

		if(enemySpawnInterval <= 0){
			GenerateEnemy();
			enemySpawnInterval = 2.0f;
		}

	}

	void GenerateEnemy(){
		GameObject.Find("Tile" + Random.Range(1,8)).SendMessage("EnemySpawn");
	}
	
	public static void buyGoodGuy(){
		totalMoney -= 20.0f;
		print (totalMoney);
	}
	
	public static void killGoodGuy(){
		totalMoney += 20.0f;
	}
	public static float getMoney(){
		return totalMoney;
	}
}
