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
    // Start is called before the first frame update
    void Start()
    {
        // rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        curHp = maxHP;
        // rb.bodyType = RigidbodyType2D.Dynamic;

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curHp <= 0)
        {
            GameObject.Destroy(this);
        }
        rb.velocity = new Vector2(speed, 0.0f);
        // moving = true;
        // t = 0.0f;

    }

    public void takeDamage(float amount)
    {
        if (!alive)
        {
            return;
        }
        if (curHp <= 0)
        {
            curHp = 0;
            alive = false;
        }
        curHp -= amount;
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        print("fish");

        if (col.gameObject.tag == "Proj")
        {
            curHp -= 20;
          //  Destroy();
        }
    }
}
