using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class GameOver : MonoBehaviour {
	
	//public AudioClip beep;
	// Use this for initialization
	
	void Start () {
		audio.Play();
		transform.guiTexture.enabled = true;
	}
		
	void OnMouseDown(){
        if (Input.GetMouseButtonDown (0)){
			print (transform.tag);
            applicationLoader(transform.tag);
        }
    }
    
    
    void applicationLoader(string tag){
        
        //AudioSource.PlayClipAtPoint(beep, transform.position);
        //yield return new WaitForSeconds(0.35f);

        if(tag == "exit"){
			//yield return new WaitForSeconds(0.50f);
			transform.parent.guiTexture.enabled = false;
            Application.LoadLevel(0);
        }else if(tag == "retry"){
        	//yield return new WaitForSeconds(0.50f);
			Application.LoadLevel(Application.loadedLevel);
        }
		transform.guiTexture.enabled = false;
		audio.Stop();
    }
       
}
