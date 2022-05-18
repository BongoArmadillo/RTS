using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private LayerMask enemy = 10;
    private LayerMask units = 6;
    void Start()
    {
        if(gameObject.layer == units){
             RTSselector.instance.unitList.Add(this.gameObject);
        }
        if(gameObject.layer == enemy){
            RTSselector.instance.enemyUnits.Add(this.gameObject);
        }
    }

    private void OnDestroy() {
   if(gameObject.layer == units){
             RTSselector.instance.unitList.Remove(this.gameObject);
        }
    if(gameObject.layer == enemy)
        {
            RTSselector.instance.enemyUnits.Remove(this.gameObject);
        }
    }
}
