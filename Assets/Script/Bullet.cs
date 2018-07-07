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
		if(target != null)
        {
            Vector3 bulletDirection = target.position - transform.position;
            float dinstanceInThisFrame = bulletSpeed * Time.deltaTime; // the distance that the bullet will run in this frame
            if (bulletDirection.magnitude <= dinstanceInThisFrame)
                HitTarget(); // if in this frame the bullet will hit the target
            else
            {
                transform.Translate(bulletDirection.normalized * dinstanceInThisFrame, Space.World); // if in this frame the bullet will not hit the target
            }
        }
	}

    void HitTarget ()
    {
        GameObject localImpactEffect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(localImpactEffect, 0.5f);
       //Destroy(target.gameObject); // for destroy the target enemy (super power turret!)
        Destroy(gameObject);
    }
}
