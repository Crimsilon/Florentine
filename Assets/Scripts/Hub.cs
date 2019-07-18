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

            if (curHealth<= 0)
            {
            player.GetComponent<PlayerControl>().enabled = false;
            player.GetComponent<Weapon>().enabled = false;
            Time.timeScale = 0;
            StartCoroutine("time");
            }

        
            float HubHP = (curHealth / maxHealth)/2;
            setHealthBar(HubHP);
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    

}
