using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kynttilakoodi : MonoBehaviour
{
    public GameObject paakamera = null;
    public GameObject tahtain = null;
    public GameObject pelaaja = null;
    void Start()
    {
        this.pelaaja = GameObject.Find("Pelaaja");
        this.paakamera = GameObject.Find("MainCamera");
        this.tahtain = GameObject.Find("tahtain");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sytytammekynttilan()
    {
        if (this.name.StartsWith("kynttila"))
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(2).gameObject.SetActive(true);
        }

        if (this.name.StartsWith("rituaalikynttila"))
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void Sammutammekynttilan()
    {
        if (this.name.StartsWith("kynttila"))
        {
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
        }

        if (this.name.StartsWith("rituaalikynttila"))
        {
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

}
