using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public Transform target;
	private float speed;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target,Vector3.up);
        transform.position += transform.forward*speed*Time.deltaTime;
    }




    void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.tag == "Bullet") {
            Destroy(this);
            Instantiate(explosion,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
    
}
