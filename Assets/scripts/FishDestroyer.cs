using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish") || other.CompareTag("TrashObject"))
        {
            Destroy(other.gameObject);
        }
    }

}
