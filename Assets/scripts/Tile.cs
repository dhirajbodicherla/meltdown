using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown () {
		GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		cylinder.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        cylinder.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+0.6f, gameObject.transform.position.z);

	}
}
