using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class UnitResources : MonoBehaviour
{
   [SerializeField] string mineTag;
   [SerializeField] string castleTag;
   NavMeshAgent agent;
   Transform castlePosition;
   Transform minePosition;
   public bool isMined = false;
   CastleResources crScript;

   private void Start() {
       agent = GetComponent<NavMeshAgent>();
       castlePosition = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Transform>();
       minePosition = GameObject.FindGameObjectWithTag("Mine").GetComponent<Transform>();
       crScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<CastleResources>();
   }
   private void OnTriggerEnter(Collider other) {
       if(other.tag == mineTag){
       agent.SetDestination(castlePosition.position);
       isMined = true;
       }

       if(other.tag == castleTag && isMined == true){
            crScript.UpdateText();
            agent.SetDestination(minePosition.position);  
            isMined = false;       
       }
   }
   
}
