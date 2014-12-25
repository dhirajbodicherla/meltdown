using UnityEngine;
using System.Collections;

public class SnowFlake : MonoBehaviour {
	
	public AudioClip collectSound;
	float dropSpeed = 0.5f;
	float snowFlakeDeathTime = 4.0f;
	GameObject _base;
	
	// Use this for initialization
	void Start () {
		_base = GameObject.FindGameObjectWithTag("base");
	}
	
	// Update is called once per frame
	void Update () {
		
		if(transform.position.z - transform.parent.position.z >= 0 ){
			
			transform.Translate(Vector3.down * dropSpeed * Time.deltaTime);
			
		} else {
			
			snowFlakeDeathTime -= Time.deltaTime;
			
			if(snowFlakeDeathTime <= 0){
				Destroy(gameObject);
			}
			
		}
		
	}
	
	void OnMouseDown(){
		_base.SendMessage("collectSnowFlake");
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		Destroy(gameObject);
		GameGrid.setActionType(0);
	}
}
