using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SpawnerButton : MonoBehaviour
{
    [SerializeField] GameObject units;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform targetPosition;
    [SerializeField] Text cooldownText;
    GameObject unitsClone;
    float spawnerCooldown;
    float cooldownTimer;
    [SerializeField] float cooldownTime;
    NavMeshAgent agent;

    public void Update() {
        if(cooldownTimer >= 0){
        cooldownTimer -= Time.deltaTime;
        cooldownText.text = Mathf.RoundToInt(cooldownTimer).ToString();
        }
        else{
            cooldownText.text = "Create";
        }
    }

    public void spawnerButtonClick(){
        
        if(Time.time > spawnerCooldown){
        unitsClone = Instantiate(units,spawnPoint.position,Quaternion.identity);
        spawnerCooldown = Time.time + cooldownTime;
        agent = unitsClone.GetComponent<NavMeshAgent>();
        agent.SetDestination(targetPosition.position);
        cooldownTimer = cooldownTime;
        }
    }
}
