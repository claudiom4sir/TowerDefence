﻿using UnityEngine;

public class Bullet : MonoBehaviour {

    public Transform target;
    public float bulletSpeed = 70f;
    public GameObject impactEffect;
    public float rangeEffect = 0f;
    public int damage;

    public void SetTarget (Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	private void Update ()
    {
        if (target == null)
            Destroy(gameObject);
        else
        {
            Vector3 bulletDirection = target.position - transform.position;
            float dinstanceInThisFrame = bulletSpeed * Time.deltaTime; // the distance that the bullet will run in this frame
            if (bulletDirection.magnitude <= dinstanceInThisFrame)
                HitTarget(); // if in this frame the bullet will hit the target
            else
            {
                transform.Translate(bulletDirection.normalized * dinstanceInThisFrame, Space.World); // if in this frame the bullet will not hit the target
                transform.LookAt(target); // for look in a direction of the target
            }
        }
	}

    private void HitTarget ()
    {
        GameObject localImpactEffect = Instantiate(impactEffect, transform.position, transform.rotation);
        if (rangeEffect >= 0)
            Explode();
        else
            Damage(target);
        Destroy(localImpactEffect, 0.5f);
        Destroy(gameObject);
    }

    private void Damage(Transform target)
    {
        target.TakeDamage();
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, rangeEffect); // it returns the objects that the bullet hits when explodes
        foreach (Collider collider in colliders)
            if (collider.tag.Equals("enemy"))   // it because the bullet's explosion can hits everythings
                Damage(collider.transform);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeEffect);
    }
}
