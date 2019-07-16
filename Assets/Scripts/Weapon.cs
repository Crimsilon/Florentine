using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectileRight;
    public GameObject projectileLeft;
    [SerializeField] public Transform shotLocation;
    [SerializeField] public Transform crouchShot;
    public Animator animator;
    // Update is called once per frame

   
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (gameObject.GetComponent<PlayerControl>().crouch)
            {
                
                if (gameObject.GetComponent<PlayerControl>().facingRight)
                    GameObject.Instantiate(projectileRight, crouchShot.position, Quaternion.identity);
                else
                    GameObject.Instantiate(projectileLeft, crouchShot.position, projectileLeft.transform.rotation);

            }
            else
            {
                animator.SetTrigger("shot");
                if (gameObject.GetComponent<PlayerControl>().facingRight)
                    GameObject.Instantiate(projectileRight, shotLocation.position, Quaternion.identity);
                else
                    GameObject.Instantiate(projectileLeft, shotLocation.position, projectileLeft.transform.rotation);
            }

          

        }


    }
}
