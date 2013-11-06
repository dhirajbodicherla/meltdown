using UnityEngine;
using System.Collections;

public class SnowMobile : MonoBehaviour {

	float snowMobileSpeed = 1.7f;
	bool destory = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(destory)
			transform.Translate(Vector3.left * snowMobileSpeed * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "enemy"){
			destory = true;
		}
	}
}
