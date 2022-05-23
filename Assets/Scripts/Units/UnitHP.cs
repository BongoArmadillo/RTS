using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class UnitHP : MonoBehaviour
{
    float healthAmount;
    float damage;
    float minDmg;
    float maxDmg;
    [SerializeField] EnemyGameObj enemyObj;
    [SerializeField] string enemyTag;
    float cooldown;
    float attack = 1f;

    private void Start()
    {
        healthAmount = enemyObj.maxHealth;
        minDmg = enemyObj.minDmg;
        maxDmg = enemyObj.maxDmg;
    }
    private void Update()
    {
        damage = Random.Range(minDmg, maxDmg);
        DestroyObject();
    }


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
            RTSselector.instance.deselect(this.gameObject);
            RTSselector.instance.unitSelected.Remove(this.gameObject);
            
        }

    }
}
