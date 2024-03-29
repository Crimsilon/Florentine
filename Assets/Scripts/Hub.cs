﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hub : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;
    public GameObject healthBar;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        curHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
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

        

            curHealth -= damage;

            print(curHealth);
            float HubHP = (curHealth / maxHealth);
        if (HubHP >= 0)
        {
            setHealthBar(HubHP);
        }
        if (curHealth<= 0)
            {
           

            Time.timeScale = .2f;
            StartCoroutine("time");
            
            player.GetComponent<PlayerControl>().enabled = false;

            player.GetComponent<Weapon>().enabled = false;

            

            
            }

        
            
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene(0);
    }
    

}
