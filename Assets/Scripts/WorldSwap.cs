using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwap : MonoBehaviour
{

    public bool blueActive;

    public GameObject blueScreen;
    public GameObject RedScreen;
    // Start is called before the first frame update
    private void Start()
    {
        blueActive = false;
        blueScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButtonDown("dimshift"))
        {
            if (blueActive)
            {
                blueScreen.SetActive(false);
                RedScreen.SetActive(true);
                blueActive = false;
            }
            else
            {
                blueScreen.SetActive(true);
                RedScreen.SetActive(false);
                blueActive = true;
            }
        }
    }

    public bool getBlueActive()
    {
        return blueActive;
    }
}
