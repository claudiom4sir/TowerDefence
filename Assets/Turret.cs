using UnityEngine;

public class Turret : MonoBehaviour {

    public Transform target;
    public float range = 7f;
    private string enemyTag = "enemy";
    public Transform rotationParts;

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = lookRotation.eulerAngles;
            rotationParts.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
	}

    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
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

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
