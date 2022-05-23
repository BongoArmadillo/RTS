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
    [SerializeField] float maxDistance;
    bool isAttacking = false;
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        GetComponent<AI>().enabled = false;
    }
private void Update() {
    Target = FindClosestEnemy();
    
    move();

    callToAttack();
    Debug.Log(isAttacking);

    if(Vector3.Distance(transform.position, Target.transform.position) < maxDistance && isAttacking == true){
        attack();
    }
    
}

void move(){
    if(Input.GetMouseButtonDown(1))
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
    if(Input.GetMouseButtonDown(1))
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
public GameObject FindClosestEnemy()
    {
        GameObject[] Enemy;
        Enemy = GameObject.FindGameObjectsWithTag("Enemyv2");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject EnemyTarget in Enemy)
        {
            Vector3 diff = EnemyTarget.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = EnemyTarget;
                distance = curDistance;
            }
        }
        return closest;
    }
}
