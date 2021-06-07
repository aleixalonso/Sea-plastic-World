using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployFish : MonoBehaviour
{

	public GameObject fishPrefab;
	public GameObject doriPrefab;
	public GameObject peixPrefab;
	public GameObject sharkPrefab;

	public float respawnTime = 1.0f;
	private Vector2 screenBorders;

	private TrashSpawn trashSpawn;

	private List<GameObject> fishesList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    	StartCoroutine(fishWave());
    	GameObject trashSpawnComponent = GameObject.Find("TrashSpawn");
		trashSpawn = trashSpawnComponent.GetComponent<TrashSpawn>();

    }

    private void spawnAnimals(){

    	if (trashSpawn.deletedObjects > 2){
    	GameObject f = Instantiate(fishPrefab) as GameObject;
    	f.transform.position = new Vector3 (Random.Range(108 , 10 ), Random.Range(-22 , 0), 80);
		fishesList.Add(f);
		}

		if (trashSpawn.deletedObjects > 4){
    	GameObject d = Instantiate(doriPrefab) as GameObject;
     	d.transform.position = new Vector3 (Random.Range(108 , 10 ), Random.Range(-22 , 0), 80);
     	fishesList.Add(d);
     	}


    	if (trashSpawn.deletedObjects > 5){
    	GameObject p = Instantiate(peixPrefab) as GameObject;
    	p.transform.position = new Vector3 (Random.Range(108 , 10 ), Random.Range(-22 , 0), 80);
		fishesList.Add(p);
    	}	

    	if (trashSpawn.deletedObjects > 6){
    	GameObject s = Instantiate(sharkPrefab) as GameObject;
    	s.transform.position = new Vector3 (Random.Range(108 , 10 ), Random.Range(-22 , 0), 80);
    	fishesList.Add(s);
    	}

    	
    	
    	

	}

    IEnumerator fishWave(){

    	while(true){
    		
    		yield return new WaitForSeconds(respawnTime);
           	spawnAnimals();	
        }
    } 

    public void RemoveFishesFromList(GameObject pez)
   {
       fishesList.Remove(pez);
   }
    
}
