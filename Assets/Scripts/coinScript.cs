﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManagerScript>().sanity = 100.0f;
        gameObject.SetActive(false);        
    }
}
