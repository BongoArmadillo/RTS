using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AImove : MonoBehaviour
{
    Camera mainCam;
    NavMeshAgent agent;
    [SerializeField] LayerMask ground;
    [SerializeField] AIattack AIattackScipt;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        GetComponent<AImove>().enabled = false;
    }
private void Update() {
    move();
}

void move(){
    if(Input.GetMouseButtonDown(1))
    {
        RaycastHit hit;
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            AIattackScipt.isAttacking = false;
            agent.SetDestination(hit.point);
        }
    }
}


}
