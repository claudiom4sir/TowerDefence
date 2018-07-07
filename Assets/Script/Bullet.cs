using UnityEngine;

public class Bullet : MonoBehaviour {

    public Transform target;
    public float bulletSpeed = 70f;
    public GameObject impactEffect;

    public void SetTarget (Transform target)
    {
        this.target = target;
    }
	
	// Update is called once per frame
	void Update () {
		if(target == null)
        {
            ;
        }
        else
        {
            Vector3 bulletDirection = target.position - transform.position;
            float dinstanceInThisFrame = bulletSpeed * Time.deltaTime;
            if (bulletDirection.magnitude <= dinstanceInThisFrame)
                HitTarget();
            else
            {
                transform.Translate(bulletDirection.normalized * dinstanceInThisFrame, Space.World);
            }
        }
	}

    void HitTarget ()
    {
        GameObject localImpactEffect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(localImpactEffect, 0.5f);
       // Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
