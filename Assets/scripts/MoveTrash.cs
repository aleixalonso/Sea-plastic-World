using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrash : MonoBehaviour
{
    private bool isMoving = false;
    private GameObject objectCollide = null;
    //private float speed = 0.0f;
    //private Vector3 oldPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isMoving && objectCollide)
        { 
            transform.SetPositionAndRotation(objectCollide.transform.position, transform.rotation);
        }

        //speed = Vector3.Distance(oldPosition, transform.position) * 100f;
        //oldPosition = transform.position;
        //if(speed > 400)
        //{
        //    Debug.Log("ENTRO PORQUE SPEED: " + speed.ToString("F2"));
        //    isMoving = false;
        //    objectCollide = null;
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isMoving) {
            isMoving = true;
            objectCollide = other.gameObject;
        }
    }
}
