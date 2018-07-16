﻿using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    private string enemyTag = "enemy";  // it is used for identify the enemies with them tag

    [Header("Turret attributes")]
    public Transform fireOrigin;    // it is used for show the origin of the bullet
    public Transform rotationParts;
    public float range = 11f;    // this is the range of the turret
    public float rotationSpeed = 10f;
    public float fireRate = 1f; // one bullet each second
    public float fireCountDown = 0f;

    [Header("Type of fire")]
    public GameObject bullet;

    [Header("Laser turrets attributes")]
    public bool isLaserTurret = false;
    public LineRenderer lineRenderer;

	// Use this for initialization
	private void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);  // it periodically calls UpdateTarget method
	}
	
	// Update is called once per frame
	private void Update () {
        if (target == null)
        {
            if (isLaserTurret)
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            return;
        }
        LockOnTarget();
        if (isLaserTurret)
            UseLaser();
        else
            UseBullet();
	}

    private void UseLaser() // only if the turret is a laser turret
    {
        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, fireOrigin.position);
        lineRenderer.SetPosition(1, target.position);
    }

    private void UseBullet() // it is used if the turret is not a laser turret
    {
        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1 / fireRate;
        }
        fireCountDown = fireCountDown - Time.deltaTime;
    }

    private void LockOnTarget() // the turret is locks on a specific target
    {
        Vector3 directionRotation = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(directionRotation); // the turret ruotes in the directionRotation
        Vector3 rotation = Quaternion.Lerp(rotationParts.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        rotationParts.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Shoot()    // this method is invoked when a turret shots
    {
        GameObject newBullet = Instantiate(bullet, fireOrigin.position, fireOrigin.rotation);
        Bullet localBullet = newBullet.GetComponent<Bullet>();
        if (localBullet != null)
            localBullet.SetTarget(target); // it set the target of the bullet
    }

    private void UpdateTarget ()    // it is used for update the targets 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);     // it will contains the targets
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float actualTargetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (actualTargetDistance < shortestDistance)
            {
                shortestDistance = actualTargetDistance;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
            target = nearestEnemy.transform;
        else
            target = null;
    }

    private void OnDrawGizmosSelected ()    // it is used for draw the sphere for the range of the turret
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
