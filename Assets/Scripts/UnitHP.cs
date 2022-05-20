using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class UnitHP : MonoBehaviour
{
    float healthAmount;
    int damage;
    [SerializeField] EnemyGameObj enemyObj;
    float attack = 1f;
    [SerializeField] string enemyTag;
    float cooldown;

    private void Start()
    {
        healthAmount = enemyObj.maxHealth;
    }
    private void Update()
    {
        damage = Random.Range(10, 20);
        DestroyObject();
    }
    // private void OnCollisionExit(Collision other)
    // {
    //     Debug.Log("collider");
    //     if (other.gameObject.tag == enemyTag && Time.time > cooldown)
    //     {
    //         takeDamage();    
    //         Debug.Log(healthAmount);
    //         cooldown = Time.time + attack;
    //     }
    // }


       void OnTriggerExit(Collider other){
           if(other.gameObject.tag == enemyTag && Time.time > cooldown)
            {
               
                takeDamage();
                Debug.Log(healthAmount);
                cooldown = Time.time + attack;
            }

       }


    public void takeDamage()
    {
        healthAmount -= damage;
    }
    public void DestroyObject()
    {
        if (healthAmount <= 0)
        {
            Destroy(gameObject);
        }

    }
}
