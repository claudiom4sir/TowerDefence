using UnityEngine;

public class Turret : MonoBehaviour {

    public Transform target;
    public float range = 11f;    // this is the range of the turret
    private string enemyTag = "enemy";  // it is used for identify the enemies with them tag
    public Transform rotationParts;
    public float rotationSpeed = 10f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);  // it periodically calls UpdateTarget method
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            Vector3 directionRotation = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(directionRotation); // the turret ruotes in the directionRotation
            Vector3 rotation = Quaternion.Lerp(rotationParts.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
            rotationParts.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
	}

    void UpdateTarget ()    // it is used for update the targets 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);     // it will contains the targets
        float shortestDinstance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float actualDinstance = Vector3.Distance(transform.position, enemy.transform.position);
            if (actualDinstance < shortestDinstance)
            {
                shortestDinstance = actualDinstance;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDinstance <= range)
            target = nearestEnemy.transform;
        else
            target = null;
    }

    void OnDrawGizmosSelected ()    // it is used for draw the sphere for the range of the turret
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
