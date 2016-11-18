﻿using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour {

	public Transform player;
	public float speed;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 dif = player.position - rb.transform.position;
		dif.Normalize ();
		dif *= speed;

		rb.AddForce(new Vector2(0, dif.y));

		if (dif.y > 0) {
			transform.localScale = new Vector3 (1, 1, 1);
		} else {
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		float yOld = rb.transform.position.y;
		//yOld = yOld < -26 ? -26 : yOld;
		//yOld = yOld > -9 ? -9 : yOld;

		//Vector3 xx = rb.transform.position;
		//rb.transform.position = new Vector3(xx.x, yOld, xx.z);
	}
}