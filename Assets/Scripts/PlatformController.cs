using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformController : MonoBehaviour {

	public Vector3[] localWaypoints;
	Vector3[] globalWaypoints;
	
	public float speed;
	public bool cyclic;
	public float waitTime;
	[Range(0,2)]
	public float easeAmount;
	
	int fromWaypointIndex;
	float percentBetweenWaypoints;
	float nextMoveTime;


	void Start () {
		//get positions in world from the on positions based on location of the start
		globalWaypoints = new Vector3[localWaypoints.Length];
		for (int i = 0; i < localWaypoints.Length; i++) {
			globalWaypoints[i] = localWaypoints[i] + transform.position;
		}
	}

	void Update () {
		
		Vector3 velocity = CalculatePlatformMovement ();
		//MovePassengers (velocity);
		transform.Translate (velocity);
		
	}

	float Ease(float x)
	{
        //control the ease time selecter in the inspector
		float a = easeAmount + 1;
		return Mathf.Pow(x, a) / (Mathf.Pow(x, a) + Mathf.Pow(1 - x, a));
	}

	
	Vector3 CalculatePlatformMovement(){
        //if reached destination, don't move
		if (Time.time < nextMoveTime)
		{
			return Vector3.zero;
		}
        //get platform speed based on location from waypoints
		fromWaypointIndex %= globalWaypoints.Length;
		int toWaypointIndex = (fromWaypointIndex + 1) % globalWaypoints.Length;
		float distanceBetweenWaypoints = Vector3.Distance (globalWaypoints [fromWaypointIndex], globalWaypoints [toWaypointIndex]);
		percentBetweenWaypoints += Time.deltaTime * speed / distanceBetweenWaypoints;
		percentBetweenWaypoints = Mathf.Clamp01(percentBetweenWaypoints);
		float easedPercentBetweenWaypoints = Ease (percentBetweenWaypoints);
		
		Vector3 newPos = Vector3.Lerp (globalWaypoints [fromWaypointIndex], globalWaypoints [toWaypointIndex], easedPercentBetweenWaypoints);
		
		if(percentBetweenWaypoints >=1) {
			percentBetweenWaypoints = 0;
			fromWaypointIndex ++;
			
			if (!cyclic)
			{
				if (fromWaypointIndex >= globalWaypoints.Length - 1)
				{
					fromWaypointIndex = 0;
					System.Array.Reverse(globalWaypoints);
				}
			}
			nextMoveTime = Time.time + waitTime;
		}
		
		return newPos - transform.position;
	}

	void OnDrawGizmos(){
        //draw onscreen too visualize where the waypoints are
		if (localWaypoints !=null) {
			Gizmos.color=Color.green;
			float size = .3f;
			
			for (int i = 0; i < localWaypoints.Length; i++) {
				Vector3 globalWaypointPos = (Application.isPlaying)?globalWaypoints[i]:localWaypoints[i] + transform.position;
				Gizmos.DrawLine(globalWaypointPos - Vector3.up * size, globalWaypointPos + Vector3.up * size);
				Gizmos.DrawLine(globalWaypointPos - Vector3.left * size, globalWaypointPos + Vector3.left * size);
			}
		}
	}

}
