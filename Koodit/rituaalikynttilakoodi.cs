using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rituaalikynttilakoodi : MonoBehaviour
{
    public bool voiasettaa = false;
    public bool asetettu = false;
    private GameObject koodivarasto = null;
    public GameObject gatherteksti = null;
    public GameObject kynttila = null;
    public GameObject pupu = null;


    // Start is called before the first frame update
    void Start()
    {
        this.koodivarasto = GameObject.Find("Koodivarasto");
        this.gatherteksti = GameObject.Find("gatherteksti");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && voiasettaa == true)
        {
            if (this.name.StartsWith("rituaalikynttila"))
            {
                this.kynttila.SetActive(true);
                this.gatherteksti.GetComponent<Text>().text = "";
                koodivarasto.GetComponent<tavaratkoodi>().kynttiloitakeratty -= 1;
                koodivarasto.GetComponent<tavaratkoodi>().kynttiloitaasetettu += 1;
                Debug.Log("Kynttiloita jäljellä " + koodivarasto.GetComponent<tavaratkoodi>().kynttiloitakeratty);
            }

            if (this.name.StartsWith("tytonpupu"))
            {
                this.pupu.SetActive(true);
                this.gatherteksti.GetComponent<Text>().text = "";
                koodivarasto.GetComponent<tavaratkoodi>().pupukeratty = false;
                koodivarasto.GetComponent<tavaratkoodi>().pupuasetettu = true;
                Debug.Log("Kynttiloita jäljellä " + koodivarasto.GetComponent<tavaratkoodi>().kynttiloitakeratty);
            }
            voiasettaa = false;
            this.asetettu = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.name.StartsWith("rituaalikynttila") && other.name == "Pelaaja" && this.asetettu == false && koodivarasto.GetComponent<tavaratkoodi>().kynttiloitakeratty > 0)
        {
            Debug.Log("Kynttiloita jäljellä " + koodivarasto.GetComponent<tavaratkoodi>().kynttiloitakeratty);

            this.voiasettaa = true;
            this.gatherteksti.GetComponent<Text>().text = "Put down candle";
        }

        else if (this.name.StartsWith("tytonpupu") && other.name == "Pelaaja" && this.asetettu == false && koodivarasto.GetComponent<tavaratkoodi>().pupukeratty == true) // && koodivarasto.GetComponent<tavaratkoodi>().kynttiloitakeratty > 0)
        {
            Debug.Log(this.name);

            this.voiasettaa = true;
            this.gatherteksti.GetComponent<Text>().text = "Put down bunny";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Pelaaja")
        {
            this.voiasettaa = false;
            this.gatherteksti.GetComponent<Text>().text = "";
        }
    }
}
