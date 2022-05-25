using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleBuildingBlueprint : MonoBehaviour
{
   [SerializeField] GameObject mineBlueprint;

   public void spawnMineBlueprint(){
       Instantiate(mineBlueprint);
   }
}
