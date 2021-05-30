using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployFish : MonoBehaviour
{

	public GameObject fishPrefab;
	public float respawnTime = 1.0f;
	private Vector2 screenBorders;
    // Start is called before the first frame update
    void Start()
    {
        screenBorders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    	StartCoroutine(fishWave());

    }

    private void spawnAnimals(){
    	GameObject f = Instantiate(fishPrefab) as GameObject;
    	//f.transform.position = new Vector2(screenBorders.x , Random.Range(-screenBorders.y * 2, screenBorders.y * -2));
    	f.transform.position = new Vector3 (Random.Range(108 , 10 ), Random.Range(-22 , 0), 100);
    	//f.transform.z = Random.Range(-screenBorders.y , screenBorders.y );
	}

    IEnumerator fishWave(){

    	while(true){
        	yield return new WaitForSeconds(respawnTime);
            spawnAnimals();
        }
    } 
    
}
