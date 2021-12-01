using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rituaalirinki : MonoBehaviour
{
    SpriteRenderer sprite = null;
    
    // V‰rit omina muuttujina jotta saadaan sulava siirtym‰ v‰reiss‰, jota voidaan s‰‰t‰‰ tilanteen mukaan
    private float punainen = 0f;
    private float vihrea = 0f;
    private float sininen = 0f;
    private float lapinakyvyys = 1f;
    public int maxkynttilamaara = 8;
    public int kynttilamaara = 2;
    private bool sytytetaan = false;
    public bool pelaajaringissa = false;


    public bool aktivoitunut = false; 

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(aktivoitunut == true)
        {
            if(punainen < 1f)
            {
                this.punainen += 0.005f;
            }
        }

        if (aktivoitunut == false && punainen > 0)
        {
           this.punainen -= 0.005f;
        }

        if(aktivoitunut == true && Input.GetMouseButtonDown(1) && this.kynttilamaara < this.maxkynttilamaara)
        {
            this.transform.GetChild(kynttilamaara).gameObject.SetActive(true);
            this.kynttilamaara += 1;
        }

        sprite.color = new Color(punainen, vihrea, sininen, lapinakyvyys);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Pelaaja")
        {
            aktivoitunut = true;
            pelaajaringissa = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Pelaaja" && sytytetaan == false)
        {
            aktivoitunut = false;
            pelaajaringissa = false;
        }
    }


public void sytytakynttilat()
    {
        this.sytytetaan = true;

        Debug.Log("Childeja on " + transform.childCount);

        for (int i = 0; i < kynttilamaara; i++)
        {
            Debug.Log("Sytytet‰‰n kynttil‰ numero: " + i);
            var sytytettavakynttila = this.gameObject.transform.GetChild(i); ; // .gameObject
            Debug.Log("Saatu kiinni child: " + i);
            sytytettavakynttila.transform.GetChild(1).gameObject.SetActive(true);
            sytytettavakynttila.transform.GetChild(2).gameObject.SetActive(true);
            Debug.Log("Suoritettu koodin kutsu child: " + i);

        }
        aktivoitunut = true;
    }
}
