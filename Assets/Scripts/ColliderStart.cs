using UnityEngine;
using System.Collections;

public class ColliderStart : MonoBehaviour {
    
	void Start () {
	
	}
	
	// Activate Game
	void OnTriggerEnter2D(Collider2D col){
		Application.LoadLevel ("gamejam");
	}
}
