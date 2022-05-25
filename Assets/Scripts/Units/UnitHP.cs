using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class UnitHP : MonoBehaviour
{
    float healthAmount;
    float damage;
    public int minUnitDmg;
    public int maxUnitDmg;
    int enemyMinDmg = 0;
    int enemyMaxDmg = 0;
    [SerializeField] EnemyGameObj enemyObj;
    [SerializeField] string enemyTag;
    float cooldown;
    float attack = 1f;

    private void Start()
    {
        healthAmount = enemyObj.maxHealth;
        minUnitDmg = enemyObj.minUnitDmg;
        maxUnitDmg = enemyObj.maxUnitDmg;
    }
    private void Update()
    {
        damage = Random.Range(enemyMinDmg, enemyMaxDmg);
        DestroyObject();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemyv2"){
        enemyMinDmg = other.GetComponent<UnitHP>().minUnitDmg;
        enemyMaxDmg = other.GetComponent<UnitHP>().maxUnitDmg;
        }
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
