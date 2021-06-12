using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrash : MonoBehaviour
{
    public int peopleToMove = 1;
    public float movementSpeed = 0.02f;
    public AudioClip beepSound;

    private int currentPeopleMoving = 0;
    private bool isMoving = false;

    private GameObject player1 = null;
    private GameObject player2 = null;

    private GameObject playerAlone = null;

    private GameObject Halo = null;

    private AudioSource audioSource;

    private float timeGrabbed = 0.0f;
    private float speed = 0.0f;
    private Vector3 oldPosition = Vector3.zero;
    private Vector3 newPosition = Vector3.zero;
    private Vector3 randPosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        oldPosition = transform.position;
        if(transform.Find("Halo")) Halo = transform.Find("Halo").gameObject;
        if(Halo) Halo.SetActive(false);
        randPosition = new Vector3(Random.Range(9, 90), 0, Random.Range(9, 90));
        //Debug.Log("POSITION: " + randPosition);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            
            UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
            transform.Rotate(0, 0, 1.0f * Time.deltaTime);
            //Vector3 randPosition = new Vector3(Random.Range(9, 90), 0, Random.Range(9, 90));
            float distance = Vector3.Distance(randPosition, transform.position);
            if (distance > 1.0f)
            {
                transform.position = Vector3.Lerp(transform.position, randPosition, Time.deltaTime * movementSpeed);
                //Debug.Log("RAND POSITION: " + randPosition);
                //Debug.Log("CURRENT POSITION: " + transform.position);
            } else
            {
                randPosition = new Vector3(Random.Range(9, 50), 0, Random.Range(9, 50));
                //Debug.Log("NEW POSITION: " + randPosition);
            }
            //float randomX = Random.Range(-0.5f, 0.5f);
            //float randomZ = Random.Range(-0.5f, 0.5f);
            //transform.position += new Vector3(randomX, 0, randomZ);
            
        }
        if (isMoving && peopleToMove == 1 && peopleToMove == currentPeopleMoving)
        {
            if (player1)
            {
                playerAlone = player1;
            }
            else if (player2)
            {
                playerAlone = player2;
            }

            if (playerAlone)
            {
                enableHalo();
                newPosition = transform.position;
                var media = (newPosition - oldPosition);
                speed = (media / Time.deltaTime).magnitude;
                oldPosition = newPosition;
                newPosition = transform.position;

                timeGrabbed += Time.deltaTime;
                transform.SetPositionAndRotation(playerAlone.transform.position, transform.rotation);

                if (timeGrabbed > 2.0)
                {
                    //Debug.Log("UNITY SPEED: " + speed.ToString("F2"));
                    if (speed > 120.0)
                    {
                        //Debug.Log("ENTRO PORQUE SPEED: " + speed.ToString("F2"));
                        isMoving = false;
                        if (playerAlone.CompareTag("Player1Moving"))
                        {
                            player1.gameObject.tag = "Player1";
                            player1 = null;

                        }
                        else if (playerAlone.CompareTag("Player2Moving"))
                        {
                            player2.gameObject.tag = "Player2";
                            player2 = null;
                        }
                        playerAlone = null;
                        timeGrabbed = 0.0f;
                        currentPeopleMoving = 0;
                        disableHalo();
                    }

                }
            } 
        }
        if (isMoving && peopleToMove == 2)
        {
            if(currentPeopleMoving < peopleToMove)
            {
                if (player1)
                {
                    playerAlone = player1;
                }
                else if (player2)
                {
                    playerAlone = player2;
                }
                if (playerAlone)
                {
                    timeGrabbed += Time.deltaTime;
                    transform.SetPositionAndRotation(playerAlone.transform.position, transform.rotation);

                    if (timeGrabbed > 1.0)
                    {
                        isMoving = false;
                        if (playerAlone.CompareTag("Player1Moving"))
                        {
                            player1.gameObject.tag = "Player1";
                            player1 = null;
                        }
                        else if (playerAlone.CompareTag("Player2Moving"))
                        {
                            player2.gameObject.tag = "Player2";
                            player2 = null;
                        }
                        playerAlone = null;
                        timeGrabbed = 0.0f;
                        currentPeopleMoving--;
                    }
                }

            }
            else if(player1 && player2)
            {
                enableHalo();
                timeGrabbed += Time.deltaTime;
                float dist = Vector3.Distance(player1.transform.position, player2.transform.position);
                //Debug.Log("BOTH MOVING");
                if(dist > 10.0f)
                {
                    isMoving = false;
                    player1.gameObject.tag = "Player1";
                    player2.gameObject.tag = "Player2";
                    player1 = null;
                    player2 = null;
                    playerAlone = null;
                    timeGrabbed = 0.0f;
                    currentPeopleMoving=0;
                    disableHalo();
                }
                else
                {
                    transform.SetPositionAndRotation((player1.transform.position + player2.transform.position) / 2, transform.rotation);
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isMoving || (isMoving && currentPeopleMoving < peopleToMove))
        {
            //Debug.Log("ENTRO AL ON TRIGGER CON OTHER: " + other.name);
            if (other.CompareTag("Player1") && !player1)
            {
                isMoving = true;
                player1 = other.gameObject;
                currentPeopleMoving += 1;
                other.gameObject.tag = "Player1Moving";
            }
            else if(other.CompareTag("Player2") && !player2)
            {
                isMoving = true;
                player2 = other.gameObject;
                currentPeopleMoving += 1;
                other.gameObject.tag = "Player2Moving";
            }
            
        }
    }

    private void OnDestroy()
    {
        if(player1) player1.gameObject.tag = "Player1";
        if(player2) player2.gameObject.tag = "Player2";
    }

    private void enableHalo()
    {
        if (Halo && !Halo.activeSelf)
        {
            Halo.SetActive(true);
            audioSource.PlayOneShot(beepSound, 1F);
        }
    }
    private void disableHalo()
    {
        if (Halo && Halo.activeSelf)
        {
            Halo.SetActive(false);
        }
    }
}
