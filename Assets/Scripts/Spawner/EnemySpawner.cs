using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour{ 
    [SerializeField] GameObject units;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform targetPosition;
    GameObject unitsClone;
    float spawnerCooldown;
    [SerializeField] float cooldownTime;
    NavMeshAgent agent;


    public void Update(){
        
        if(Time.time > spawnerCooldown){
        unitsClone = Instantiate(units,spawnPoint.position,Quaternion.identity);
        spawnerCooldown = Time.time + cooldownTime;
        agent = unitsClone.GetComponent<NavMeshAgent>();
        agent.SetDestination(targetPosition.position);
        }
    }
    
 


}
