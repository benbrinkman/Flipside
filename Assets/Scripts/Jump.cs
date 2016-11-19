using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float timeJump;
	public float forceApplied;

	private float lastTime;
	private Rigidbody2D rb;
    
	void Start () {
		lastTime = Time.realtimeSinceStartup;

		rb = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {

		Vector2 forceUp = new Vector2(-1, 0);
        //gravity
		if (Time.realtimeSinceStartup - lastTime > timeJump) {
			Vector2 force = forceUp * forceApplied;
			rb.AddForce(force);

			lastTime = Time.realtimeSinceStartup;
		}

		Vector2 forceDown = -forceUp * 100f * Time.deltaTime;
		rb.AddForce (forceDown);

		rb.rotation = 90;

		Vector3 vel = rb.velocity;
		rb.velocity = new Vector3(vel.x, 0, 0);
	}
}
