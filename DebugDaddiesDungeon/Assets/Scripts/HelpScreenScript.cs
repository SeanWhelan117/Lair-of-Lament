using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreenScript : MonoBehaviour
{
    public GameObject AKey;
    public GameObject DKey;
    public GameObject SpaceKey;
    public GameObject Ekey;
    public GameObject FKey;
    public GameObject MouseLeft;

    private Vector3 scaleFactor;
    private Vector3 scaleFactor2;

    // Start is called before the first frame update
    /// <summary>
    /// Sets the intitial scales for the key sprites on the help screen
    /// 1 scale is for what it has to be reset to, the other is to be added when the correct inputs are given
    /// </summary>
    void Start()
    {
        scaleFactor = new Vector3(0.5f, 0.5f, 0.5f);
        scaleFactor2 = new Vector3(0.25f, 0.25f, 0.25f);
    }

    // Update is called once per frame
    /// <summary>
    /// Update that jsut checks for key presses for the keys on the help screen.
    /// Additionally resets the keys scales using the other scale factor when the keys are not being pressed.
    /// Affected keys are A, D, Space, E, F and Mouse left
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AKey.transform.localScale += scaleFactor2;
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            AKey.transform.localScale = scaleFactor;
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            DKey.transform.localScale += scaleFactor2;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            DKey.transform.localScale = scaleFactor;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpaceKey.transform.localScale += scaleFactor2;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            SpaceKey.transform.localScale = scaleFactor;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ekey.transform.localScale += scaleFactor2;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            Ekey.transform.localScale = scaleFactor;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            FKey.transform.localScale += scaleFactor2;
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            FKey.transform.localScale = scaleFactor;
        }

        if (Input.GetMouseButtonDown(0) == true)
        {
            Debug.Log("cLICK");
            MouseLeft.transform.localScale += scaleFactor2;
        }
       else if (Input.GetMouseButtonUp(0) == true)
        {
            MouseLeft.transform.localScale = scaleFactor;
        }
    }
}
