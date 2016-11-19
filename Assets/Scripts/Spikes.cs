using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	private Player player;

	void Start(){

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player> ();
	}

	void OnTriggerEnter2D(Collider2D col){
        //This code can be applied to more than just spikes, anything we want to kill the player can use it. Should not have named it spikes. Hindsight is 20/20
		if (col.CompareTag ("Player")) {
			player.dead = true;
		}

	}
}
