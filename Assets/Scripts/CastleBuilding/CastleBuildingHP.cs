using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleBuildingHP : MonoBehaviour
{
    float buildngHP;
    int knockbackStr;
    float cooldown;
    float attack = 1f;
    int enemyMinDmg = 0;
    int enemyMaxDmg = 0;
    int damage;
    [SerializeField] BuildingsGameObj buildingsObj;
    [SerializeField] string enemyTag;


    private void Start() {
        buildngHP = buildingsObj.maxHealth;
        knockbackStr = buildingsObj.knockbackStr;
    }

    private void Update() {
        damage = Random.Range(enemyMinDmg, enemyMaxDmg);
        DestroyObject();
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemyv2"){
        enemyMinDmg = other.GetComponent<UnitHP>().minUnitDmg;
        enemyMaxDmg = other.GetComponent<UnitHP>().maxUnitDmg;
        Debug.Log("Log1");

        if(other.gameObject.tag == enemyTag && Time.time > cooldown)
            {
                takeDamage();
                castleKnockback(other);
                Debug.Log("Log2");
                Debug.Log(buildngHP);
                cooldown = Time.time + attack;
            }
        }
    }

    public void takeDamage()
    {
        buildngHP -= damage;
    }

     public void DestroyObject()
    {
        if (buildngHP <= 0)
        {
            Destroy(gameObject);
            RTSselector.instance.deselect(this.gameObject);
            RTSselector.instance.unitSelected.Remove(this.gameObject);
            
        }

    }

    void castleKnockback(Collider other){
        Vector3 direction = transform.position - other.transform.position;
        other.GetComponent<Rigidbody>().AddForce(direction.normalized * knockbackStr, ForceMode.Impulse);
            
    }



}
