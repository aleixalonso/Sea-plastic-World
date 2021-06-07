using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrash : MonoBehaviour
{
    private TrashSpawn trashSpawn;
    // Start is called before the first frame update
    void Start()
    {
        GameObject trashSpawnComponent = GameObject.Find("TrashSpawn");
        trashSpawn = trashSpawnComponent.GetComponent<TrashSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrashObject"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Player1Moving"))
        {
            other.gameObject.tag = "Player1";
            trashSpawn.deletedObjects += 1;
        }
        if (other.CompareTag("Player2Moving"))
        {
            other.gameObject.tag = "Player2";
            trashSpawn.deletedObjects += 1;
        }
    }
}
