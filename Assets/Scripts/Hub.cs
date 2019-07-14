﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hub : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        InvokeRepeating("decreaseingHealth", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void decreaseingHealth()
    {
        curHealth -= 2f;
    }
}
