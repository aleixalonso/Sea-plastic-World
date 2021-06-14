using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moviment3 : MonoBehaviour
{

	public float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(-1 *speed, 0 , -1* speed,Space.World);

    }
}
