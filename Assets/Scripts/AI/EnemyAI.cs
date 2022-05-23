using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject Target;
    public float maxDistance;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {

        if (!agent.pathPending)
            move();

        if(FindClosestEnemy(out Target)){

        if (Vector3.Distance(transform.position, Target.transform.position) < maxDistance)
        {
            attack();
        }

        }


    }

    void move()
    {
        int Randx = Random.Range(-100, 100);
        int Randy = Random.Range(-100, 100);

        Vector3 destination = new Vector3(Randx + transform.position.x, 1f, Randy + transform.position.z);

        agent.SetDestination(destination);

    }
    void attack()
    {
        agent.SetDestination(Target.transform.position);
    }

    public bool FindClosestEnemy(out GameObject closest)
    {
        GameObject[] enemy;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
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
