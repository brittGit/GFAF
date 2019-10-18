using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float speed = 10f;

   private Transform target;
   private int wavepointIndex = 0;

   void Start()
   {
       target = Waypoints.points[0]; //sets target to 1st waypoint
   }

   void Update()
   {
       //moves enemy towards waypoint
       Vector3 dir = target.position - transform.position;
       transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
       
       // when it reaches the waypoint it will call GetNextWayPoint
       if (Vector3.Distance(transform.position, target.position) <= 0.2f)
       {
           GetNextWaypoint();
       }
   }
    //moves the target from the current waypoint to the next
   void GetNextWaypoint()
   {    
       // if the enemy makes it to the end, it will be destroyed 
       if(wavepointIndex >= Waypoints.points.Length - 1)
       {
           Destroy(gameObject);
           return;
       }

       wavepointIndex++;
       target = Waypoints.points[wavepointIndex];
   }
}
