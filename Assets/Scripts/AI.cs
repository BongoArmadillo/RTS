using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    Camera mainCam;
    NavMeshAgent agent;
    public LayerMask ground;
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
    }
private void Update() {
    if(Input.GetMouseButtonDown(1))
    {
        RaycastHit hit;
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            agent.SetDestination(hit.point);
        }
    }
}
}
