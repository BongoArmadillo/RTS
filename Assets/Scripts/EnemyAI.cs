using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject Target;
    public float maxDistance;
    
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
       
    }
private void Update() {
    Target = FindClosestEnemy();
        if(!agent.pathPending)
            move();

      if(Vector3.Distance(transform.position, Target.transform.position) < maxDistance && !agent.pathPending){
               attack();
           }
    
    
}

void move(){
    int Randx = Random.Range(-100, 100);
    int Randy = Random.Range(-100, 100);

    Vector3 destination = new Vector3(Randx + transform.position.x ,2f,Randy + transform.position.z);
        
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
        float distance = 10f;
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
