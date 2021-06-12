using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrash : MonoBehaviour
{
    public AudioClip destroyTrashSound;
    private TrashSpawn trashSpawn;
    private AudioSource audioSource;
    private float colorSteps;
    private GameObject planeComponent;
    // Start is called before the first frame update
    void Start()
    {
        GameObject trashSpawnComponent = GameObject.Find("TrashSpawn");
        trashSpawn = trashSpawnComponent.GetComponent<TrashSpawn>();
        audioSource = GetComponent<AudioSource>();
        colorSteps = ((255.0f - 160.0f) / trashSpawn.objectsToDelete);
        planeComponent = GameObject.Find("Plane");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrashObject"))
        {
            audioSource.PlayOneShot(destroyTrashSound, 1F);
            Destroy(other.gameObject);
            trashSpawn.deletedObjects += 1;
            Color newColor = planeComponent.GetComponent<Renderer>().material.color;
            newColor.r += (colorSteps/255);
            newColor.g += (colorSteps / 255);
            planeComponent.GetComponent<Renderer>().material.color = newColor;
        }
    }
}
