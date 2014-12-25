using UnityEngine;
using System.Collections;

public struct LevelStructure {
	
	private string _scene;
	private int[] _enemies;
	private int[] _goodGuys;
	private int _numberOfEnemies;
	private int _startEnergy;
	private string _levelName;
	
	public LevelStructure(string scene, int[] enemies, int[] goodGuys, int numberOfEnemies, int startEnergy, string levelName){
		_scene = scene;
		_enemies = enemies;
		_goodGuys = goodGuys;
		_numberOfEnemies = numberOfEnemies;
		_startEnergy = startEnergy;
		_levelName = levelName;
	}
	
	public int getStartEnergy(){
		return _startEnergy;
	}
	
	public string getSceneName(){
		return _scene;
	}
	
	public int getNumberOfEnemies(){
		return _numberOfEnemies;
	}
	
	public int[] getEnemies(){
		return _enemies;
	}
	
	public int[] getGoodGuys(){
		return _goodGuys;
	}
	public string getLevelName(){
		return _levelName;
	}

}
