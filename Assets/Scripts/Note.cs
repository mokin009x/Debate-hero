﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    
    Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    void Start()
    {
        rb.velocity = new Vector2(0, -speed);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
