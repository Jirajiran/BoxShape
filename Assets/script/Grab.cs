using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;

    private GameObject grabbedObject;
    private float previousGravityScale;

    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale.x, rayDist);

        if (grabCheck.collider != null && grabCheck.collider.CompareTag("shield"))
        {
            if (Input.GetKeyDown(KeyCode.E) && grabbedObject == null)
            {
                grabbedObject = grabCheck.collider.gameObject;
                previousGravityScale = grabbedObject.GetComponent<Rigidbody2D>().gravityScale;
                grabbedObject.transform.SetParent(boxHolder);
                grabbedObject.transform.position = boxHolder.position;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            }
            else if (Input.GetKeyDown(KeyCode.E) && grabbedObject != null)
            {
                GameObject itemParent = GameObject.FindWithTag("Item"); // หา parent object ที่มี Tag "Item"

                if (itemParent != null)
                {
                    grabbedObject.transform.SetParent(itemParent.transform); // ตั้ง parent ใหม่เป็น object ที่มี Tag "Item"
                }

                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.GetComponent<Rigidbody2D>().gravityScale = previousGravityScale;
                grabbedObject = null;
            }


        }
    }
}
