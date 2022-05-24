using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class UnitResources : MonoBehaviour
{
   [SerializeField] TMP_Text unitResourcesCountText;
   [SerializeField] string mineTag;
   [SerializeField] string castleTag;
   int unitResourcesCount = 0;
   NavMeshAgent agent;
   [SerializeField] Transform castlePosition;
   [SerializeField] Transform minePosition;
   private void OnTriggerEnter(Collider other) {
       if(other.tag == mineTag){
       unitResourcesCount += 1;
       agent.SetDestination(castlePosition.position);
       }

       if(other.tag == castleTag){
            unitResourcesCountText.text = unitResourcesCount.ToString();
            agent.SetDestination(minePosition.position);         
       }
   }
   
}
