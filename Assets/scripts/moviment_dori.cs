﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moviment_dori : MonoBehaviour
{

	public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.right*speed,Space.World);

    }
}
