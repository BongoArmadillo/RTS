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
    GameObject warriorClone;
    GameObject MinerClone;
    float spawnerMinerCooldown;
    float spawnerWarriorCooldown;
    float cooldownMinerTimer;
    float cooldownWarriorTimer;
    [SerializeField] float cooldownTime;
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
        
        if(Time.time > spawnerWarriorCooldown){
        warriorClone = Instantiate(WarriorUnit,spawnPoint.position,Quaternion.identity);
        spawnerWarriorCooldown = Time.time + cooldownTime;
        agent = warriorClone.GetComponent<NavMeshAgent>();
        agent.SetDestination(targetPosition.position);
        cooldownWarriorTimer = cooldownTime;
        }
    }

    public void spawnerMinerButtonClick(){
        
        if(Time.time > spawnerMinerCooldown){
        MinerClone = Instantiate(MinerUnit,spawnPoint.position,Quaternion.identity);
        spawnerMinerCooldown = Time.time + cooldownTime;
        agent = MinerClone.GetComponent<NavMeshAgent>();
        agent.SetDestination(targetPosition.position);
        cooldownMinerTimer = cooldownTime;
        }
    }
}
