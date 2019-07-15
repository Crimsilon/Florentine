using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounce : MonoBehaviour
{
    public Rigidbody2D body;
    public float jumpPower;
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
        Vector2 temp = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, jumpPower);
        print("the thing");
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = (temp);

       // collision.transform = new Vector2.up;
    }
}
