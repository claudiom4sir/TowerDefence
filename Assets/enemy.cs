using UnityEngine;

public class enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

	// Use this for initialization
	void Start () {
		target = wayPoints.points[0];
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
            GetNextWaypoint();
	}

    void GetNextWaypoint()
    {
        if (waypointIndex >= wayPoints.points.Length - 1)
            Destroy(gameObject);
        else
        {
            waypointIndex++;
            target = wayPoints.points[waypointIndex];
        }
    }

}
