using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CastleResources : MonoBehaviour
{
    public int unitResourcesCount = 1;
    [SerializeField] TMP_Text unitResourcesText;
    [SerializeField] string minerTag;


   public void UpdateText()
   {
    unitResourcesCount += 1;
    unitResourcesText.text = unitResourcesCount.ToString();
   }
}
