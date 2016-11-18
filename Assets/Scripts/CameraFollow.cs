using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;

	public float timerGravitySwitch = 0;
	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject player;

	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posy = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, posy, transform.position.z);

		if (Input.GetKey ("1")) {
			this.transform.localEulerAngles = new Vector3(0, 0, 0);
		}else if (Input.GetKey ("2")) {
			this.transform.localEulerAngles = new Vector3(0, 0, 90);
		}else if (Input.GetKey ("3")) {
			this.transform.localEulerAngles = new Vector3(0, 0, 180);
		}else if (Input.GetKey ("4")) {
			this.transform.localEulerAngles = new Vector3(0, 0, 270);
		}
	}
}
