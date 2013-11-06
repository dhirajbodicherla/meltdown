using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour {

	public static LevelStructure[] levels;
	
	// Use this for initialization
	void Start () {
		
		levels = new LevelStructure[]{
			new LevelStructure("level_1", new int[]{1,2,3,4}, new int[]{1,2,3,4}, 10, 10),
			new LevelStructure("level_1", new int[]{1,2,3,4}, new int[]{1,2,3,4}, 2, 10),
			new LevelStructure("level_1", new int[]{1,2,3,4}, new int[]{1,2,3,4}, 3, 10),
			new LevelStructure("level_1", new int[]{1,2,3,4}, new int[]{1,2,3,4}, 4, 10),
			new LevelStructure("level_1", new int[]{1,2,3,4}, new int[]{1,2,3,4}, 5, 10)
		};
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public static void show(){
		//print(levelStructure[0]);
	}
}
