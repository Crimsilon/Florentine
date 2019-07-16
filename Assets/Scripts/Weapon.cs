using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectileRight;
    public GameObject projectileLeft;
    public Animator animator;
    [SerializeField] public Transform shotLocation;
   
    // Update is called once per frame

   
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("Fire1"))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //animator.SetBool(IsShooting, true);
            }
            
        

            if (gameObject.GetComponent<PlayerControl>().facingRight)
                GameObject.Instantiate(projectileRight, shotLocation.position, Quaternion.identity);
            else
                GameObject.Instantiate(projectileLeft, shotLocation.position, Quaternion.identity);

        
      
        }


    }
}
