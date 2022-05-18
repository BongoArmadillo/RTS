using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RTSselector.instance.unitList.Add(this.gameObject);
    }

    private void OnDestroy() {
    RTSselector.instance.unitList.Remove(this.gameObject);
    }
}
