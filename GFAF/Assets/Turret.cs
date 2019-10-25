using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour   
{
    private Transform target;
    public float range = 15f;

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
         InvokeRepeating ("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget ()
    {
        //stores each enemy in this array
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {   //gets the distance of the enemy and converts it to unity units, and stores into the float
            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) 
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        //Lock onto Target stuff
        //makes an vector point at the enemy, and have the end pos - the start pos
        Vector3 dir = target.position - transform.position;

        //tells unity what to turn so it looks at the enemy
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        //Lerp smooth the rotation of the turret, so it doesn't look janky when it aims at enemies
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        //makes sure that you only rotate the y-axis
        partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f); 
        
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
