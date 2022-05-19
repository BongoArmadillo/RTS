using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public LayerMask ground;
    LayerMask enemy = 10;
    public GameObject Target;
    public float maxDistance;
    bool isAttacking = false;
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
       
    }
private void Update() {
    Target = FindClosestEnemy();
        if(!agent.pathPending)
            move();

      if(Vector3.Distance(transform.position, Target.transform.position) < maxDistance){
               attack();
           }
    
    
}

void move(){
    int Randx = Random.Range(-10, 10);
    int Randy = Random.Range(-10, 10);

    Vector3 destination = new Vector3(Randx,0,Randy);
        
            agent.SetDestination(destination);
    
}
void attack(){
agent.SetDestination(Target.transform.position);
}

public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
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
