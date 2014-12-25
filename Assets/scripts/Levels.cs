﻿using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour {

	public static LevelStructure[] levels;
	
	/*
	 *
	 (_scene, _enemies, _goodGuys, _numberOfEnemies, _startEnergy, _levelName)
	 *
	 */
	
	// Use this for initialization
	void Start () {
		
		levels = new LevelStructure[]{
			new LevelStructure("level_1", new int[]{1,2,3}, new int[]{3,4}, 2, 50, "Level 1"),
			new LevelStructure("level_2", new int[]{2,3,4}, new int[]{3,4}, 2, 50, "Level 2")
		};
		
		/*
		,
			new LevelStructure("level_3", new int[]{1,2,3,4}, new int[]{3}, 3, 10, "Level 3"),
			new LevelStructure("level_1", new int[]{4}, new int[]{4}, 4, 10, "Level 4"),
			new LevelStructure("level_1", new int[]{1,2,3,4}, new int[]{1,2,3,4}, 5, 10, "Level 5")
			
			*/
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public static void show(){
		//print(levelStructure[0]);
	}
}
