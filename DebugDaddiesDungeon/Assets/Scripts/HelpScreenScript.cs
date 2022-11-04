using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreenScript : MonoBehaviour
{
    public GameObject AKey;
    public GameObject DKey;
    public GameObject SpaceKey;

    private Vector3 scaleFactor;
    private Vector3 scaleFactor2;

    // Start is called before the first frame update
    void Start()
    {
        scaleFactor = new Vector3(0.5f, 0.5f, 0.5f);
        scaleFactor2 = new Vector3(0.25f, 0.25f, 0.25f);
    }

    // Update is called once per frame
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
    }
}
