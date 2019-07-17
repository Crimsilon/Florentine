using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;

    //value of -1 gives left 1 right

    public int direction;

    private float curHp;

    public float maxHP;

    public float damage;
    
    public bool RedCreature;
   
    public float hubDamage;

    private GameObject DimensionControl;

    //what type of Ai/enemy behavior to run

    public bool pigglet;
    public bool wearwolf;

    // Start is called before the first frame update
    void Start()
    {
        
        // rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        curHp = maxHP;
        // rb.bodyType = RigidbodyType2D.Dynamic;

        DimensionControl = GameObject.Find("dimension Control");



        rb = gameObject.GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {

        if (pigglet == true)
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);

        else if (wearwolf == true) {
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        }
        // moving = true;
        // t = 0.0f;


        //transparency of sprite control dont try to think about it, it just works

        if (RedCreature)
        {
            if (RedCreature == true && !DimensionControl.GetComponent<WorldSwap>().blueActive)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

            }
            else
            {

                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .2f);

            }
        }
        else
        {
            if (RedCreature != true && DimensionControl.GetComponent<WorldSwap>().blueActive)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);


            }
            else
            {

                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .2f);

            }
        }

    }

    public void TakeDamage(float damage)
    {
        if (RedCreature == true && !DimensionControl.GetComponent<WorldSwap>().blueActive) {
            curHp -= damage;
            print(curHp);
            if (curHp <= 0)
            {
                Die();
            }
        }
        if(RedCreature!=true&& DimensionControl.GetComponent<WorldSwap>().blueActive) {
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
        if (enemy != null)
        {
            if (enemy.tag == "Hub")
            {
                Destroy(gameObject);
            }
        }
    }


}
