using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	float speed = 1.3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "enemy"){
			Destroy(gameObject);
		}
	}
}
