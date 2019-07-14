using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed;
    public bool alive;
    bool active;

    public float curHp;
    public float maxHP;
    public float damage;
    public GameObject deathEffect;
    public bool RedCreature;
    public GameObject DimenstionControl;
    public float hubDamage;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag.Equals("Red"))
        {
            RedCreature = true;
        }
        else
        {
            RedCreature = false;
        }
        // rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        curHp = maxHP;
        // rb.bodyType = RigidbodyType2D.Dynamic;

        DimenstionControl = GameObject.Find("dimension Control");



        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curHp <= 0)
        {
            Die();
        }
        rb.velocity = new Vector2(speed, 0.0f);
        // moving = true;
        // t = 0.0f;

    }

    public void TakeDamage(float damage)
    {
        if (RedCreature == true && !DimenstionControl.GetComponent<WorldSwap>().blueActive) {
            curHp -= damage;
            print(curHp);
            if (curHp <= 0)
            {
                Die();
            }
        }
        if(RedCreature!=true&& DimenstionControl.GetComponent<WorldSwap>().blueActive) {
            curHp -= damage;
            print(curHp);
            if (curHp <= 0)
            {
                Die();
            }

        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Hub enemy = hitInfo.GetComponent<Hub>();
        if (enemy != null)
        {

            enemy.TakeDamage(damage);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);
        if (enemy.tag == "Hub")
        {
            Destroy(gameObject);
        }
    }
}
