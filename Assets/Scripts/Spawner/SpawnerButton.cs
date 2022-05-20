using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerButton : MonoBehaviour
{
    [SerializeField] GameObject units;
    [SerializeField] Transform spawnPoint;
    GameObject unitsClone;
    float spawnerCooldown;
    [SerializeField] float cooldownTime;


    public void spawnerButtonClick(){
        if(Time.time > spawnerCooldown){
        unitsClone = Instantiate(units,spawnPoint.position,Quaternion.identity) as GameObject;
        spawnerCooldown = Time.time + cooldownTime;
        }
    }
}
