using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLeft : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float Pspeed;
    [SerializeField] public GameObject player;
    public float damage;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
       // gameObject.transform.rotation.Set( 0, 0, -180, 0);
    }

    // Update is called once per frame
    void Update()
    {

        //shoot left
       
            rb.velocity = new Vector2(-Pspeed, 0.0f);
        //shoots right
      
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        enemy enemy = hitInfo.GetComponent<enemy>();
        if (enemy != null)
        {
            
            enemy.TakeDamage(damage);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }


}
