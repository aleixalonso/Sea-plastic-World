using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawn : MonoBehaviour
{

    private int currentNumberTrash;
    private int i;
    private int sizeOfList = 0;

    public int objectsToDelete = 10;

    public int deletedObjects = 0;


    //public GameObject fishPrefab;
    public List<GameObject> trashPrefabs;
    public GameObject trashParent;
    
    public float respawnTime = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        sizeOfList = trashPrefabs.Count;
        StartCoroutine(startTrash());
    }

    private void spawnTrash()
    {

        //GameObject f = Instantiate(fishPrefab) as GameObject;
        GameObject trashElem = Instantiate( trashPrefabs[i % sizeOfList] ) as GameObject;
        trashElem.transform.parent = trashParent.transform;
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
        trashElem.transform.position = new Vector3(Random.Range(9, 90), 0, Random.Range(9, 90));
        i++;
    }

    IEnumerator startTrash()
    {

        while (true)
        {
            Debug.Log("DELETED OBJECTS: " + deletedObjects);
            yield return new WaitForSeconds(respawnTime);
            if(i < objectsToDelete) spawnTrash();
        }
    }

}
