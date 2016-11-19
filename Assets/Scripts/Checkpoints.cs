using UnityEngine;
using System.Collections;

public class Checkpoints : MonoBehaviour {

	public Sprite unlit, lit;

	private bool triggered;
    
	void Start () {
		triggered = false;
		GetComponent<SpriteRenderer> ().sprite = unlit;
	}
	
	public bool isTriggered() {
		return triggered;
	}

	public void trigger() {
        //light lamposts on checkpoint
		triggered = true;
		GetComponent<SpriteRenderer> ().sprite = lit;
	}
}
