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

    public float hopFreq;

    public float hopX;

    public float hopY;

    public float hopPower;

    private GameObject DimensionControl;

    public Animator animator;

    //what type of Ai/enemy behavior to run

    public bool pigglet;
    public bool wearwolf;
    public bool Hopper;

    // Start is called before the first frame update
    void Start()
    {
        
        // rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        curHp = maxHP;
        // rb.bodyType = RigidbodyType2D.Dynamic;

        DimensionControl = GameObject.Find("dimension Control");

        rb = gameObject.GetComponent<Rigidbody2D>();

        if (Hopper == true)
        {

            StartCoroutine(Hops());

        }
    }

   
    void Update()
    {

        if (pigglet == true)
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);

        else if (wearwolf == true) {
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        }
        else if(Hopper == true)
        {
               // code for the hopper is in the start and a coroutine Hops
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
        if (hitInfo.tag.Equals("Reverse"))
        {
            print("bounce");
            direction = direction * -1;
            if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
       
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
    IEnumerator Hops()
    {
        while (true)
        {

            StartCoroutine("HopsAnim");

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(hopX * hopPower*direction, hopY * hopPower);

            yield return new WaitForSeconds(hopFreq);

            
        }
        

    }

    IEnumerator HopsAnim()
    {
        animator.SetBool("Jump", true);

        yield return new WaitForSeconds(.5f);

        //animator.SetBool("Jump", false);
    }

}
