using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitKnockback : MonoBehaviour
{
   public float knockbackStr;
   [SerializeField] EnemyGameObj obj;
   [SerializeField] string targetLayer;
   Rigidbody rb;

private void Start() {
    rb = GetComponent<Rigidbody>();
    knockbackStr = obj.st;
}

     void OnTriggerEnter(Collider other) {
         if(other.gameObject.tag != targetLayer)
            return;
            Vector3 direction = transform.position - other.transform.position;
            rb.AddForce(direction.normalized * knockbackStr, ForceMode.Impulse);
            rb.isKinematic = false;
            Invoke("isKinematicOn",0.5f);
    }
    
    void isKinematicOn()
    {
        rb.isKinematic = true;
    }
 
}
