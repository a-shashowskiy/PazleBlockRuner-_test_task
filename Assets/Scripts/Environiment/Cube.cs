using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody rigB;

    private void Start()
    {
        rigB = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
     
    { 
        if(other.tag == "Player")
        {
            GetComponent<BoxCollider>().isTrigger = false;
            rigB.useGravity = true;
            rigB.constraints = RigidbodyConstraints.None;
            transform.parent = null;
            rigB.AddForce(new Vector3(0,0, 100));
            gameObject.layer = 10;//Set layer non Collide with playr
            Destroy(this);
        }
    }

}
