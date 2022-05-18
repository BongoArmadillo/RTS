using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    Camera mainCam;
    [SerializeField]
    RectTransform dragBox;
    Rect  selectionBox;

    Vector2 startPosition;
    Vector2 endPosiotion;
    private void Start() {
        mainCam = Camera.main;
        startPosition = Vector2.zero;
        endPosiotion = Vector2.zero;
        drawVisual();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            startPosition = Input.mousePosition;
            selectionBox = new Rect();
        }
        if(Input.GetMouseButton(0)){
            endPosiotion = Input.mousePosition;
            drawVisual();
            drawSelection();
        }
        if(Input.GetMouseButtonUp(0)){
            startPosition = Vector2.zero;
            endPosiotion = Vector2.zero;
            drawVisual();
            selectUnits();

        }
    }

    void drawVisual(){
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosiotion;

        Vector2 boxCenter = (boxStart + boxEnd)/2;
        dragBox.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));
        dragBox.sizeDelta = boxSize;
    }

    void drawSelection(){
        if(Input.mousePosition.x < startPosition.x)
        {
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;

        }
        else
        {
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = Input.mousePosition.x;
        }

        if(Input.mousePosition.y < startPosition.y)
        {
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;
        }
        else{
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }

    void selectUnits(){
        foreach (var unit in RTSselector.instance.unitList)
        {
            if(selectionBox.Contains(mainCam.WorldToScreenPoint(unit.transform.position))){
                RTSselector.instance.dragSelect(unit);
            }
        }
    }
}
