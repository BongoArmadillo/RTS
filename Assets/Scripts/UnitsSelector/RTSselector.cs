using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSselector : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitSelected = new List<GameObject>();
    public List<GameObject> enemyUnits = new List<GameObject>();
    [SerializeField] string tag;

    private static RTSselector _instance;
    public static RTSselector instance {get {return _instance;}}

    private void Awake() {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void dragSelect(GameObject unitToAdd){
        if(!unitSelected.Contains(unitToAdd) && unitToAdd.tag == tag){
            unitSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<AI>().enabled = true;
        }
    }

    public void deselectALL()
    {
        foreach (var unit in unitSelected)
        {
            unit.transform.GetChild(0).gameObject.SetActive(false);
            unit.GetComponent<AI>().enabled = false;
        }
        unitSelected.Clear();
    }

    public void deselect(GameObject unitToDeselect){
            unitToDeselect.transform.GetChild(0).gameObject.SetActive(false);
            unitToDeselect.GetComponent<AI>().enabled = false;
    }
}
