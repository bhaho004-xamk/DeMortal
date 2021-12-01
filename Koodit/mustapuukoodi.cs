using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mustapuukoodi : MonoBehaviour
{
    GameObject pelaaja = null;
    private Vector3 skaala;
    private float skaalatilanne;
    public float minskaala = 0.4f;
    public float maxskaala = 1f;
    public bool kutistuu = false;
    List<GameObject> lahellaolevat;


    private void Start()
    {
        this.pelaaja = GameObject.Find("Pelaaja");
    }

    private void FixedUpdate()
    {
        this.skaalatilanne = this.transform.localScale.y;



        if(this.kutistuu == true)//other.name == pelaaja.name)
        {
            if (this.skaalatilanne > this.minskaala)
            {
                Debug.Log("VALOA");
                this.skaala = new Vector3(0.002f, 0.003f, 0.002f);
                this.transform.localScale -= skaala;
            }
            
        }

        if (this.kutistuu == false)//other.name == pelaaja.name)
        {
            if (this.skaalatilanne < this.maxskaala)
            {
                Debug.Log("VALOA");
                this.skaala = new Vector3(0.002f, 0.003f, 0.002f);
                this.transform.localScale += skaala;
            }

        }
    }

    public void TarkistaPalavat()
    {
        float apuetaisyys = Vector3.Distance(pelaaja.transform.position, this.transform.position);
        if (apuetaisyys < 20 && pelaaja.GetComponent<taikakoodi>().sytytys == true)
        {
            this.kutistuu = true;
        }

        if (apuetaisyys < 20 && pelaaja.GetComponent<taikakoodi>().sytytys == false)
        {
            this.kutistuu = false;
        }
        /*
         * KOODI JOUDUTTU JÄÄDYTTÄMÄÄN KOSKA VEI VALTAVASTI TEHOJA
         * Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 20);
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.name == "Pelaaja")
            {
                GameObject apupelaaja = hitCollider.gameObject;
                if(apupelaaja.GetComponent<taikakoodi>().sytytys == true)
                {
                    Debug.Log("IIK PALAVA PELAAJA");
                    this.kutistuu = true;
                }
            } else if (hitCollider.name.StartsWith("laatikko"))
            {
                GameObject apulaatikko = hitCollider.gameObject;
                if (apulaatikko.GetComponent<Tarttumiskoodi>().palaa == true)
                {
                    Debug.Log("IIK PALAVA LAATIKKO");
                    this.kutistuu = true;
                }
            } else
            {
                Debug.Log("HUH MIKÄÄN EI ENÄÄ PALA");
                this.kutistuu = false;
            }
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Pelaaja" && other.GetComponent<taikakoodi>().sytytys == true)
        {
            this.kutistuu = true;
        }

        if (other.name.StartsWith("laatikko") && other.GetComponent<Tarttumiskoodi>().palaa == true)
        {
            this.kutistuu = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Pelaaja" && other.GetComponent<taikakoodi>().sytytys == true)
        {
            this.kutistuu = false;
        }

        if (other.name.StartsWith("laatikko") && other.GetComponent<Tarttumiskoodi>().palaa == true)
        {
            this.kutistuu = false;
        }
    }
}
