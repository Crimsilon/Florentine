﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hub : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;
    public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
       // InvokeRepeating("decreaseingHealth", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
        

    public void setHealthBar(float HubHealth)
    {
        //hubHealth needs to be between 0 and 1 , calculated by max and cur helth

        healthBar.transform.localScale = new Vector3(HubHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public void TakeDamage(float damage)
    {

        print("brah");
            curHealth -= damage;
            print(curHealth);
            if (curHealth<= 0)
            {
               // Die();
            }

        
            float HubHP = curHealth / maxHealth;
            setHealthBar(HubHP);
    }

    

}
