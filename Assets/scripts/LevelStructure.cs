using UnityEngine;
using System.Collections;

public struct LevelStructure {
	
	private string scene;
	private int[] enemies;
	private int[] goodGuys;
	private int numberOfEnemies;
	private int startEnergy;
	
	public LevelStructure(string sc, int[] en, int[] gg, int noe, int se){
		scene = sc;
		enemies = en;
		goodGuys = gg;
		numberOfEnemies = noe;
		startEnergy = se;
	}
	
	public int getStartEnergy(){
		return startEnergy;
	}
	
	public string getLevelName(){
		return scene;
	}
	
	public int getNumberOfEnemies(){
		return numberOfEnemies;
	}
	
	public int[] getEnemies(){
		return enemies;
	}
	
	public int[] getGoodGuys(){
		return goodGuys;
	}

}
