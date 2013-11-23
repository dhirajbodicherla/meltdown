using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	float speed = 6.0f;
	public AudioClip snowballHitSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "enemy"){
			AudioSource.PlayClipAtPoint(snowballHitSound, transform.position);
			Destroy(gameObject);
		}
	}
}
