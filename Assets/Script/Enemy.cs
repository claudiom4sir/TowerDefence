using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;   // this is a speed of moviment of the enemy

    private Transform target;   // target is the "ruby" points 
    private int waypointIndex = 0;  // it is used for index in wayPoints.points array

	// Use this for initialization
	void Start () {
		target = WayPoints.points[0];
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = target.position - transform.position;   // the vector with direction
        // now, transforms is "this" enemy and function translate allows to move the enemy
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            GetNextWaypoint();
	}

    void GetNextWaypoint()  // it allows to change wayPoints and to destroy the enemy when it is arrived to the last wayPoints
    {
        if (waypointIndex >= WayPoints.points.Length - 1)
            Destroy(gameObject);
        else
        {
            waypointIndex++;
            target = WayPoints.points[waypointIndex];
        }
    }

}
