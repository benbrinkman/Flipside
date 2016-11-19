using UnityEngine;
using System.Collections;

public class ElevatorRun : MonoBehaviour {

	public Transform end;
	public float speed;
	private bool running, finished;
	float tempx;
	float tempy;
    
	void Start () {
		running = false;
		finished = false;
	}
	
	void Update () {
		if (running && !finished) {
            //check how close player is to end
			Vector3 movement = end.position - transform.position;// new Vector2(0, 1);//end.position - transform.position;

            //I am not acctually sure what these temp variables do but I am too scared to delete them
            tempx = transform.position.x;
			tempy = transform.position.y;
			//transform.position.x = tempy;
			//transform.position.y = tempx;
			movement.Normalize();
			movement *= speed * Time.deltaTime;
			transform.Translate(movement);

			if ((end.position - transform.position).magnitude < 5) {
				finished = true;
			}
		}
	}

	public void startElevator() {
		running = true;
	}
}
