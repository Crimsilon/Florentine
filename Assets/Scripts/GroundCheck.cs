using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    GameObject Player;
    // Use this for initialization
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("enter");
        if (collision.collider.tag == "Ground")
        {

            print("enter");
            Player.GetComponent<PlayerControl>().grounded = true;
            //Player.GetComponent<PlayerControl>().extraJumps = Player.GetComponent<charMove>().extraJumpValue;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            print("exit");
            Player.GetComponent<PlayerControl>().grounded = false;
        }
    }
}
