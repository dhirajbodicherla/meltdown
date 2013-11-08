﻿using UnityEngine;
using System.Collections;

public class SnowFlake : MonoBehaviour {
	
	public AudioClip collectSound;
	float dropSpeed = 0.5f;
	float snowFlakeDeathTime = 4.0f;
	
	// Use this for initialization
	void Start () {
	
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
		StartCoroutine(SnowflakeCollected());
	}
	
	IEnumerator SnowflakeCollected(){
		audio.PlayOneShot(collectSound);
		Game.collectSnowFlake();
		
		yield return new WaitForSeconds(collectSound.length);
		
		Destroy(gameObject);
	}
}
