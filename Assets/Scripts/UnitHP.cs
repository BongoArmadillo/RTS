using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHP : MonoBehaviour
{
    float healthAmount;
    int damage;
    [SerializeField] EnemyGameObj enemyObj;
    float timeStamp;
    [SerializeField] string enemyTag;
    
    private void Start() {
        healthAmount = enemyObj.maxHealth;
    }
    private void Update() {
        damage = Random.Range(1,5);
        DestroyObject();
    }
   private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == enemyTag)
        {
            takeDamage();    
        Debug.Log(healthAmount);
        }
   }
    public void takeDamage(){
       
        healthAmount -= damage;
    }
    public void DestroyObject()
    {
        if(healthAmount <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
