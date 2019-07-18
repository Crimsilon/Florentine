using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject teleportLink;
    private bool coolDown=true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (coolDown)
            {
                //collision.gameObject.GetComponent<PlayerControl>().canTeleport = false;

                print("why");
                StartCoroutine("coolD");
                coolDown = false;
                collision.gameObject.GetComponent<PlayerControl>().teleport(teleportLink.transform);
                

            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (coolDown)
        {
            //collision.gameObject.GetComponent<PlayerControl>().canTeleport = false;

            print("why");
            StartCoroutine("coolD");
            coolDown = false;
            collision.gameObject.GetComponent<PlayerControl>().teleport(teleportLink.transform);


        }
    }



    IEnumerator coolD()
    {
        print("coolestD");
        Physics2D.IgnoreLayerCollision(9, 11, true);
      

        yield return new WaitForSeconds(2);

        Physics2D.IgnoreLayerCollision(9, 11, false);
        coolDown = true;

    }
    

    
}
