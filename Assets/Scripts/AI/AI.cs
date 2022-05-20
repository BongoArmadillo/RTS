using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    Camera mainCam;
    NavMeshAgent agent;
    public LayerMask ground;
    LayerMask enemy = 10;
    public GameObject Target;
    public float maxDistance;
    bool isAttacking = false;
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        GetComponent<AI>().enabled = false;
    }
private void Update() {
    Target = FindClosestEnemy();
    move();
    if(isAttacking == true){
        if(Vector3.Distance(transform.position, Target.transform.position) < maxDistance){
               attack();
           }
    }
    
}

void move(){
    if(Input.GetMouseButton(1))
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
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemyv2");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
