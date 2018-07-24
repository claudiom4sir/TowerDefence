using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;   // this is a start speed of moviment of the enemy
    private float currentSpeed;
    public float startHealth;
    private float health;
    private Transform target;   // target is the "ruby" points 
    private int waypointIndex = 0;  // it is used for index in wayPoints.points array
    public GameObject deathEffect;
    public int rewards;
    public Image healthBar; // it is used for rappresent the health bar


	// Use this for initialization
	private void Start () {
		target = WayPoints.points[0];
        currentSpeed = startSpeed;
        health = startHealth;
	}

    public void TakeDamage(int damage)
    {
        health = health - damage;
        healthBar.fillAmount = health / startHealth; // for update the health bar
        if (health <= 0)
            Die();
    }

    public void ModifySpeed(float value)
    {
        currentSpeed = startSpeed * value;
    }

    private void Die()
    {
        GameObject death = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(death, 5f);
        PlayerStatistic.money = PlayerStatistic.money + rewards;
        PlayerStatistic.enemyKilled++; // for to increase the number of enemy killed
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	private void Update () {
        Vector3 direction = target.position - transform.position;   // the vector with direction
        // now, transforms is "this" enemy and function translate allows to move the enemy
        transform.Translate(direction.normalized * currentSpeed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            GetNextWaypoint();
        currentSpeed = startSpeed;
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
