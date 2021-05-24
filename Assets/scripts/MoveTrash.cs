using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrash : MonoBehaviour
{
    public int peopleToMove = 1;

    private int currentPeopleMoving = 0;
    private bool isMoving = false;
    private GameObject objectCollide = null;
    private float timeGrabbed = 0.0f;
    private float speed = 0.0f;
    private Vector3 oldPosition = Vector3.zero;
    private Vector3 newPosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float speedRB = GetComponent<Rigidbody>().velocity.magnitude;
        if(isMoving && objectCollide && peopleToMove == currentPeopleMoving)
        {
            //speed = Vector3.Distance(oldPosition, transform.position) * 100f;
            //oldPosition = transform.position;
            newPosition = transform.position;
            var media = (newPosition - oldPosition);
            speed = (media / Time.deltaTime).magnitude;
            oldPosition = newPosition;
            newPosition = transform.position;

            Debug.Log("RIGID BODY SPEED: " + speedRB.ToString("F2"));


            timeGrabbed += Time.deltaTime;
            transform.SetPositionAndRotation(objectCollide.transform.position, transform.rotation);

            if (timeGrabbed > 2.0) {
                Debug.Log("UNITY SPEED: " + speed.ToString("F2"));
                if (speed > 120.0)
                {
                    Debug.Log("ENTRO PORQUE SPEED: " + speed.ToString("F2"));
                    isMoving = false;
                    objectCollide = null;
                    timeGrabbed = 0.0f;
                    currentPeopleMoving = 0;
                }

            }
        }  

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isMoving || (isMoving && currentPeopleMoving < peopleToMove))
        {
            isMoving = true;
            objectCollide = other.gameObject;
            currentPeopleMoving += 1;
        }
    }
}
