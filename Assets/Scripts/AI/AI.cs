using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    Camera mainCam;
    NavMeshAgent agent;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask enemy;
    [SerializeField] GameObject Target;
    bool isAttacking = false;
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        //GetComponent<AI>().enabled = false;
    }
private void Update() {
    
    move();

    callToAttack();

    if(FindClosestEnemy(out Target) && isAttacking == true){
        attack();
    }
    
}

void move(){
    if(Input.GetMouseButtonDown(1) && RTSselector.instance.unitSelected.Contains(gameObject))
    {
        RaycastHit hit;
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            isAttacking =  false;
            agent.SetDestination(hit.point);
        }
    }
}

void callToAttack(){
    if(Input.GetMouseButtonDown(1) && RTSselector.instance.unitSelected.Contains(gameObject))
    {
        RaycastHit hit;
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, enemy))
        {
            isAttacking = true;
            agent.SetDestination(hit.point);
        }
    }

}



void attack(){
agent.SetDestination(Target.transform.position);
}


public bool FindClosestEnemy(out GameObject closest)
    {
        GameObject[] enemy;
        enemy = GameObject.FindGameObjectsWithTag("Enemyv2");
        closest = null;
        float distance = 120f;
        Vector3 position = transform.position;
        foreach (GameObject enemyTarget in enemy)
        {
            Vector3 diff = enemyTarget.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = enemyTarget;
                distance = curDistance;
            }
        }
        if (closest == null)
            return false;
        
        return true;
    }
}
