using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kirjakoodi : MonoBehaviour
{
    public GameObject pelaaja = null;
    public GameObject pikkukirja = null;
    public GameObject isokirja = null;

    public bool kirjaedessa = false;

    void Start()
    {
        this.pelaaja = GameObject.Find("Pelaaja");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
           {
            if(kirjaedessa == true)
            {
                kirjaedessa = false;
            }

            else if (kirjaedessa == false && this.pelaaja.GetComponent<taikakoodi>().levitointikaynnissa == false)
            {
                kirjaedessa = true;
            }
        }

        if(kirjaedessa == true)
        {
            pikkukirja.SetActive(false);
            isokirja.SetActive(true);
        }

        if (kirjaedessa == false)
        {
            pikkukirja.SetActive(true);
            isokirja.SetActive(false);
        }
    }
}
