using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SpawnerButton : MonoBehaviour
{
    [SerializeField] GameObject WarriorUnit;
    [SerializeField] GameObject MinerUnit;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform targetPosition;
    [SerializeField] Text cooldownMinerText;
    [SerializeField] Text cooldownWarriorText;
    [SerializeField] float cooldownTime;
    GameObject warriorClone;
    GameObject MinerClone;
    float spawnerMinerCooldown;
    float spawnerWarriorCooldown;
    float cooldownMinerTimer;
    float cooldownWarriorTimer;
    [SerializeField] CastleResources crScript;
    
    NavMeshAgent agent;

    private void Update() {
        WarriorTimer();
        MinerTimer();
        
    }

public void WarriorTimer() {
        if(cooldownWarriorTimer >= 0){
        cooldownWarriorTimer -= Time.deltaTime;
        cooldownWarriorText.text = Mathf.RoundToInt(cooldownWarriorTimer).ToString();
        }
        else{
            cooldownWarriorText.text = "Create";
        }
    }

    public void MinerTimer() {
        if(cooldownMinerTimer >= 0){
        cooldownMinerTimer -= Time.deltaTime;
        cooldownMinerText.text = Mathf.RoundToInt(cooldownMinerTimer).ToString();
        }
        else{
            cooldownMinerText.text = "Create";
        }
    }

    public void spawnerWarriorButtonClick(){
        
        if(Time.time > spawnerWarriorCooldown && crScript.unitResourcesCount >= 2){
        warriorClone = Instantiate(WarriorUnit,spawnPoint.position,Quaternion.identity);
        spawnerWarriorCooldown = Time.time + cooldownTime;
        crScript.unitResourcesCount -= 2;
        crScript.unitResourcesText.text = crScript.unitResourcesCount.ToString();
        agent = warriorClone.GetComponent<NavMeshAgent>();
        agent.SetDestination(targetPosition.position);
        cooldownWarriorTimer = cooldownTime;
        }
    }

    public void spawnerMinerButtonClick(){
        
        if(Time.time > spawnerMinerCooldown && crScript.unitResourcesCount >= 2){
        MinerClone = Instantiate(MinerUnit,spawnPoint.position,Quaternion.identity);
        spawnerMinerCooldown = Time.time + cooldownTime;
        crScript.unitResourcesCount -= 2;
        crScript.unitResourcesText.text = crScript.unitResourcesCount.ToString();
        agent = MinerClone.GetComponent<NavMeshAgent>();
        agent.SetDestination(targetPosition.position);
        cooldownMinerTimer = cooldownTime;
        }
    }
}
