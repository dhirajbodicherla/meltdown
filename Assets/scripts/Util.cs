using UnityEngine;
using System.Collections;

public class Util : MonoBehaviour {
	
	static Transform closest;
	static Vector3 position;
	
	public static Transform getClosestObject(string tag, Vector3 position, Transform transform){
		
		float distance = Mathf.Infinity;
		
		Camera camera = GameObject.FindGameObjectWithTag("MainCamera").camera;
		position = camera.ScreenToWorldPoint(Input.mousePosition);
		
		Transform[] gos = transform.GetComponentsInChildren<Transform>();
		foreach (Transform go in gos) {
			if(go.gameObject.tag == tag){
				
				float diff = (position-go.position).sqrMagnitude;
				
	            if (diff < distance) {
	                closest = go;
	                distance = diff;
	            }
	            
				
			}
            
        }
        
		return closest;
	}
	
	public static Vector3 getScreenPoint(Transform t){
		
		Camera camera = GameObject.FindGameObjectWithTag("MainCamera").camera;
		Vector3 screenPos = camera.WorldToScreenPoint(t.position);
		
		return screenPos;
		
	}
		
}
