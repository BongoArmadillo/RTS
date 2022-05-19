using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float camSpeed = 30f;
    public float borThickness;
    public Vector2 borLimit;
    public float heightLimitmax;
    public float heightLimitmin;
    float rotationSpeed = 80f;
    Vector3 position;

    void Update() {
        position = transform.position;
        if(Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - borThickness)
        {
           position += Vector3.Cross(transform.right, transform.up)  * (camSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S) || Input.mousePosition.y <= borThickness)
        {
           position -= Vector3.Cross(transform.right, transform.up)  * (camSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - borThickness)
        {
           position += transform.right * (camSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A) || Input.mousePosition.x <=  borThickness)
        {
           position -= transform.right * (camSpeed * Time.deltaTime);
        }

         if(Input.GetKey(KeyCode.Q))
        {
           transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
        }
         if(Input.GetKey(KeyCode.E))
        {
           transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0, Space.World);
        }

        position.x = Mathf.Clamp(position.x, -borLimit.x, borLimit.x);
        position.z = Mathf.Clamp(position.z, -borLimit.y, borLimit.y);
        position.y = Mathf.Clamp(position.y, heightLimitmin, heightLimitmax);

        transform.position = position;

    }
}
