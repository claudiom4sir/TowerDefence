using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;   // this is a speed of moviment of the enemy
    public int health;
    private Transform target;   // target is the "ruby" points 
    private int waypointIndex = 0;  // it is used for index in wayPoints.points array
    public GameObject deathEffect;
    public int rewards;

	// Use this for initialization
	private void Start () {
		target = WayPoints.points[0];
	}

    public void TakeDamage(int damage)
    {
        if (health - damage <= 0)
            Die();
        else
            health = health - damage;
    }

    private void Die()
    {
        GameObject death = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(death, 5f);
        PlayerStatistic.money = PlayerStatistic.money + rewards;
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	private void Update () {
        Vector3 direction = target.position - transform.position;   // the vector with direction
        // now, transforms is "this" enemy and function translate allows to move the enemy
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            GetNextWaypoint();
	}

    private void GetNextWaypoint()  // it allows to change wayPoints and to destroy the enemy when it is arrived to the last wayPoints
    {
        if (waypointIndex >= WayPoints.points.Length - 1)
            EndPath();
        else
        {
            waypointIndex++;
            target = WayPoints.points[waypointIndex];
        }
    }

    private void EndPath()
    {
        PlayerStatistic.lives--;
        Destroy(gameObject);
    }

}
