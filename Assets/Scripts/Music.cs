using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	AudioSource[] audioList;

	// Use this for initialization
	void Start () {
		audioList = GetComponentsInChildren<AudioSource> ();

	}

	public void selectMusic(int audioNum){
        //this unmutes the music and mutes the perviously playing music
        //they are all kept running so they are at hte same spot in the music and transition smoothly into each other
		for (int i = 0; i < 4; i++) {
			audioList[i].mute = true;
		}
        //inverse which music is selected rather than rename the music itself
		if (audioNum != 5)
			audioList [5 - audioNum - 1].mute = false;
		else
			audioList [4].mute = false;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
