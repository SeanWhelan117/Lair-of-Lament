using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class torchcontroller : MonoBehaviour
{
    public GameObject torchObj;
    public bool TorchOff = false;
    public bool runonce = false;
    float duration = 1.0f;
    Color color0 = Color.white;
    Color color1 = Color.black;

    public float lifetime = 0;
    public float maxBatteryLife = 500.0f;

    public new UnityEngine.Rendering.Universal.Light2D light;
    public UnityEngine.Rendering.Universal.Light2D detail;


    [Header("Breaking mechanic if below low battery")]

    public int randomChanceOfBreaking = 0;
    public bool broken = false;

    [Header("Player")]
    public PlayerFifi player;

    // Start is called before the first frame update
    void Start()
    {
        TorchOff = true;

    }
    private void FixedUpdate()
    {

        if (lifetime < 100 && lifetime != 0 && TorchOff == false)
        {
            randomChanceOfBreaking = Random.Range(1, 10000);
            Debug.Log(randomChanceOfBreaking);
            if (randomChanceOfBreaking == 5000)      //if statement to break flashslight when below 100 power       <<----     1/10,000 CHANCE TO BREAK
            {
                lifetime = 0;
                broken = true;          // <<-----<RESET THIS WHEN BATTERY IS PICKED UP SO NEW BATTERY WILL RECHARGE    ***********DONE*********
                                        //add sound of breaking and some indication of breaking //add sounds (screams when flashlight is off )  ******************************
            }
        }

        if (lifetime <= 0)          //if there is no battery left == turn off and reset torch
        {
            TorchOff = true;
            light.color = Color.Lerp(color0, color1, 1);
            detail.color = Color.Lerp(color0, color1, 1);
            runonce = true;
        }

        if (TorchOff == true && broken == false && lifetime < maxBatteryLife)
        {
            lifetime += 0.003f;
        }

    }
    // Update is called once per frame
    void Update()
    {
        // set light color
        if (player.torchInHand == true)
        {
            duration = duration + Time.deltaTime;
            //   light.color = Color.Lerp(color0, color1, t);
            //  detail.color = Color.Lerp(color0, color1, t);





            if (TorchOff == false)      //torch on
            {
                lifetime -= Time.deltaTime;
            }

            if (TorchOff == false && lifetime >= 0.01f)     //bool to turn on the light // torch on
            {
                if (runonce == true)        //run the fade in flicker
                {
                    StartCoroutine(FadeIn());
                }
                light.color = Color.Lerp(color1, color0, duration);
                detail.color = Color.Lerp(color1, color0, duration);

                //torchObj.SetActive(true);
            }
            if (TorchOff == true)    //bool to turn off the light 
            {
                light.color = Color.Lerp(color0, color1, 1);
                detail.color = Color.Lerp(color0, color1, 1);
                runonce = true;
                //torchObj.SetActive(false);

            }
            if (Input.GetKeyDown(KeyCode.F) && lifetime >= 0.01f)    //button click to turn on off light and keep off if there is no battery
            {
                duration = 0.0f;
                TorchOff ^= true;
            }
            if (Input.GetKeyDown(KeyCode.F) && lifetime <= 0)       //if there is no battery left and user presses key 
            {
                Debug.Log("get batteries for torch");
            }


        }


        if (player.torchInHand == false)    //bool to turn off the light 
        {
            light.color = Color.Lerp(color0, color1, 1);
            detail.color = Color.Lerp(color0, color1, 1);
            TorchOff = true;
            runonce = true;
            //torchObj.SetActive(false);

        }
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(0.1f);
        light.color = Color.Lerp(color1, color0, 1);
        detail.color = Color.Lerp(color1, color0, 1);
        yield return new WaitForSeconds(0.1f);
        light.color = Color.Lerp(color0, color1, 1);
        runonce = false;
    }
}