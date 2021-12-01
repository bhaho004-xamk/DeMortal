using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// importataan UI-elementit
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class taikakoodi : MonoBehaviour
{
    // Muuttujat
    public string loitsu = "";
    public bool sytytys = false;
    public bool levitointikaynnissa = false;
    private bool riimulaskuri = false; // Laskee riimun syöttöaikaa
    private bool hiipuvariimulaskuri = false; // Laskee viipyilevän riimun
    private bool aavenakyvissa = false;

    // Ajastimet
    public float riimuviive = 12f; // Jotta riimut jäävät hetkeksi ruutuun loitsun onnistuttua
    public float syottoviive = 20f; // Aika syöttää uusi riimu

    // ulkopuoliset objektit
    private GameObject koodivarasto = null;
    private GameObject gatherteksti = null;
    public GameObject tekstiruutu = null;
    private GameObject loitsukentta = null;
    private GameObject loitsukentta2 = null;
    private GameObject summoncircle = null;
    public GameObject spawnpoint = null;
    public GameObject valopallo = null;
    public GameObject taikaefekti = null;
    public GameObject levitaatioefekti = null;
    public GameObject nostettavaesine = null;
    public List<GameObject> taiotutesineet = new List<GameObject>();
    public GameObject aaveruutu = null;
    public GameObject hamahakki = null;
    private GameObject hamisportaali = null;
    public GameObject paakamera = null;
    public GameObject henki = null;
    public GameObject kutsuttuhenki = null;
    public Material palanutlaatikkomateriaali = null;
    GameObject[] nostetutesineet;
    GameObject[] mustatpuut;
    GameObject[] rituaalikynttilat;

    // Tytär modelinsta kiinni
    public GameObject ruumis = null;

    void Start()
    {
        this.koodivarasto = GameObject.Find("Koodivarasto");
        this.gatherteksti = GameObject.Find("gatherteksti");
        this.loitsukentta = GameObject.Find("loitsu1");
        this.loitsukentta2 = GameObject.Find("loitsu2");
        this.loitsukentta2.GetComponent<Text>().text = "";
        this.ruumis = GameObject.Find("tytar");
        this.summoncircle = GameObject.Find("summoncircle");
        this.hamisportaali = GameObject.Find("hamisportaali");
        this.spawnpoint = GameObject.Find("spawnpoint");
        this.aaveruutu = GameObject.Find("aaveverho");
        this.paakamera = GameObject.Find("MainCamera");
        this.mustatpuut = GameObject.FindGameObjectsWithTag("mustapuu");
    } // end Start

    // Update is called once per frame
    void Update()
    {
        // TAIKA INPUTIT
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            this.loitsu += "1 ";
            this.syottoviive = 20f;
            this.riimulaskuri = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            this.loitsu += "2 ";
            this.syottoviive = 20f;
            this.riimulaskuri = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            this.loitsu += "3 ";
            this.syottoviive = 20f;
            this.riimulaskuri = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            this.loitsu += "i ";
            this.syottoviive = 20f;
            this.riimulaskuri = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            this.loitsu += "[] ";
            this.syottoviive = 20f;
            this.riimulaskuri = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            this.loitsu += "6 ";
            this.syottoviive = 20f;
            this.riimulaskuri = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
        {
            this.loitsu += "7 ";
            this.syottoviive = 20f;
            this.riimulaskuri = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
        {
            this.loitsu += "8 ";
            this.syottoviive = 20f;
            this.riimulaskuri = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            this.loitsu += "9 ";
            this.syottoviive = 20f;
            this.riimulaskuri = true;
        }

        if (this.loitsu == "[] 8 9 ")
        {
            this.sytytys = true;
            this.loitsukentta2.GetComponent<Text>().text = this.loitsu;
            this.hiipuvariimulaskuri = true;
            this.loitsu = "";
        }

        if (this.loitsu == "9 8 [] ")
        {
            this.sytytys = false;
            this.loitsukentta2.GetComponent<Text>().text = this.loitsu;
            this.hiipuvariimulaskuri = true;
            this.loitsu = "";
        }

        // sytytä esine
        if (this.loitsu == "[] 8 6 ")
        {
            if (nostettavaesine.name.StartsWith("laatikko"))
            {
                this.nostettavaesine.transform.GetChild(1).gameObject.SetActive(true);
                this.nostettavaesine.GetComponent<Tarttumiskoodi>().palaa = true;

                foreach (GameObject mustapuu in mustatpuut)
                {
                    mustapuu.GetComponent<mustapuukoodi>().TarkistaPalavat();
                }
                //Onko tarvetta muuttaa materiaalia, näyttää hieman räväkältä
                // nostettavaesine.GetComponent<MeshRenderer>().material = this.palanutlaatikkomateriaali;
            }
            else
            {
                this.nostettavaesine.GetComponent<kynttilakoodi>().Sytytammekynttilan();
            }
            this.loitsukentta2.GetComponent<Text>().text = this.loitsu;
            this.hiipuvariimulaskuri = true;
            this.loitsu = "";
        }

        // sammuta esine
        if (this.loitsu == "6 8 [] ")
        {
            if (nostettavaesine.name.StartsWith("laatikko"))
            {
                this.nostettavaesine.transform.GetChild(1).gameObject.SetActive(false);
                this.nostettavaesine.GetComponent<Tarttumiskoodi>().palaa = false;

                foreach (GameObject mustapuu in mustatpuut)
                {
                    mustapuu.GetComponent<mustapuukoodi>().TarkistaPalavat();
                }     
            }
            else
            {
                this.nostettavaesine.GetComponent<kynttilakoodi>().Sammutammekynttilan();
                this.loitsukentta2.GetComponent<Text>().text = this.loitsu;
                this.hiipuvariimulaskuri = true;
                this.loitsu = "";
            }

        }

        // kynttilät syttyy
        if (this.loitsu == "[] 8 7 ")
        {
            this.sytytys = false;
            this.loitsukentta2.GetComponent<Text>().text = this.loitsu;
            this.hiipuvariimulaskuri = true;
            this.loitsu = "";
            rituaalikynttilat = GameObject.FindGameObjectsWithTag("rituaalikynttila");
            Debug.Log("rituaali aktivoituu");
            foreach (GameObject rituaalikynttila in rituaalikynttilat)
            {
                Debug.Log("Looppi aktivoituu");
                rituaalikynttila.GetComponent<kynttilakoodi>().Sytytammekynttilan();
            }
        }

        // Summon Spi-Rit
        if (this.loitsu == "[] 1 4 7 ")
            
        {
            this.loitsukentta2.GetComponent<Text>().text = this.loitsu;
            this.hiipuvariimulaskuri = true;
            this.loitsu = "";
            if(summoncircle.GetComponent<rituaalirinki>().aktivoitunut == true)
            {
                Debug.Log("NYT ON ISO TAIKA");
                var apupositio = new Vector3(summoncircle.transform.position.x, summoncircle.transform.position.y + 2, summoncircle.transform.position.z);
                kutsuttuhenki = Instantiate(this.henki, apupositio, Quaternion.identity);

                if (GameObject.FindGameObjectsWithTag("rituaaliliekki").Length > 7)
                    {
                    Debug.Log("NYT ON KAIKKI PALAMASSA");
                    this.ruumis.GetComponent<Ruumis>().taikaa = true;
                    kutsuttuhenki.GetComponent<Aavekoodi>().jahtausmoodi = false;
                }

            } else
            {
                var apupaneeli = aaveruutu.GetComponent<Image>();
                var apuvari = apupaneeli.color;
                apuvari.a = 0.4f;
                apupaneeli.color = apuvari;
                aavenakyvissa = true;
            }           
        }

        // Kumoa summon loitsu? (Muuttaako lopussa kuitenkin että keski riimut laitettava eri päin?)
        if (this.loitsu == "[] 4 1 7")
        {
            this.loitsukentta2.GetComponent<Text>().text = this.loitsu;
            this.loitsu = "";
            this.hiipuvariimulaskuri = true;
            this.ruumis.GetComponent<Ruumis>().taikaa = false;
            Destroy(this.kutsuttuhenki);
        }

        // Summon Spi-der
        if (this.loitsu == "[] 1 2 7")

        {
            this.loitsukentta2.GetComponent<Text>().text = this.loitsu;
            this.hiipuvariimulaskuri = true;
            this.loitsu = "";
            if (summoncircle.GetComponent<rituaalirinki>().aktivoitunut == true)
            {
                // Paljon hämiksiä
                this.hamisportaali.GetComponent<hamisportaalikoodi>().hamisporttiauki = true;
                Debug.Log("hämiksiä!!!!");
            } else
            {
                Instantiate(hamahakki, spawnpoint.transform.position, Quaternion.identity);
                Debug.Log("hämiksiä!!!!");
            }


        }

        // Levitoi esinettä
        if (this.loitsu == "1 3 6 ")
        { 
            this.loitsukentta2.GetComponent<Text>().text = this.loitsu;
            this.hiipuvariimulaskuri = true;
            this.loitsu = "";
            if (nostettavaesine.name.StartsWith("rituaalikynttila")) // varmistetaan että rituaalikynttilää ei voi nostaa
            {            }
            else
            {
                this.nostettavaesine.GetComponent<Tarttumiskoodi>().nouse();
                this.levitointikaynnissa = true;
                this.levitaatioefekti.SetActive(true);
                this.GetComponent<kirjakoodi>().kirjaedessa = false;
            }
        }

        // Lopeta levitointi
        if (this.loitsu == "6 3 1 ")
        {
            this.loitsukentta2.GetComponent<Text>().text = this.loitsu;
            this.hiipuvariimulaskuri = true;
            this.loitsu = "";
            nostetutesineet = GameObject.FindGameObjectsWithTag("nostettavat esineet");
            foreach (GameObject nostettuesine in nostetutesineet)
            {
                nostettuesine.GetComponent<Tarttumiskoodi>().leijuminen = false;
                this.levitointikaynnissa = false;   
            }
            this.levitaatioefekti.SetActive(false);

        }

        // Palaa alkuun
        if (this.loitsu == "[] [] [] ")
        {
            this.loitsukentta2.GetComponent<Text>().text = this.loitsu;
            this.hiipuvariimulaskuri = true;
            this.loitsu = "";
            GameObject.Find("Koodivarasto").GetComponent<lopetuskoodi1>().loppulaskenta = true;
            this.transform.GetChild(4).gameObject.SetActive(true);
        }

        // Sytytä valo itselle
        if (this.sytytys == true && this.valopallo.GetComponent<Light>().intensity < 6)
        {
            this.valopallo.GetComponent<Light>().intensity += .03f;
            this.taikaefekti.SetActive(true);
            foreach (GameObject mustapuu in mustatpuut)
            {
                mustapuu.GetComponent<mustapuukoodi>().TarkistaPalavat();
            }
        }
         // Sammuta valo
        if (this.sytytys == false && this.valopallo.GetComponent<Light>().intensity > 0)
        {
            this.valopallo.GetComponent<Light>().intensity -= .05f;
            this.taikaefekti.SetActive(false);
            foreach (GameObject mustapuu in mustatpuut)
            {
                mustapuu.GetComponent<mustapuukoodi>().TarkistaPalavat();
            }
        }

        // AJASTINKOODIT

        // LOITSUN VIIPYMINEN RUUDULLA
        if (hiipuvariimulaskuri == true && riimuviive > 0)
        {
            this.riimuviive -= Time.deltaTime * 10f;
        }
        // Riimu jää ilmaan taian jälkeen, käytetty < 1 jotta vältetään bugeja tai päällekkäisyyksiä

        if (riimuviive < 1)
        {
            this.loitsukentta2.GetComponent<Text>().text = "";
            hiipuvariimulaskuri = false;
            riimuviive = 12f;
        }

        // Riimun jälkeen jos ei paineta uutta, tyhjentää loitsu-rivin
        if (riimulaskuri == true && syottoviive > 0)
        {
            this.syottoviive -= Time.deltaTime * 10f;
        }

        if (syottoviive < 1)
        {
            this.loitsu = "";
            riimulaskuri = false;
            syottoviive = 20f;
        }

        // Päivitetään kenttään haluttu loitsurimpsu
        this.loitsukentta.GetComponent<Text>().text = this.loitsu;

         // himmennetään aavekasvot
         if(aavenakyvissa == true)
        {
            var apupaneeli = aaveruutu.GetComponent<Image>();
            var apuvari = apupaneeli.color;
            apuvari.a -= 0.3f * Time.deltaTime;
            apupaneeli.color = apuvari;

            if(apuvari.a < 0)
            {
                aavenakyvissa = false;
            }
        }

   } // end Update

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("rituaalikynttila"))
        {
            
        } else {
            other.GetComponent<kerattavakoodi>().voikerata = true;
            if(other.tag == "luettava")
            {
                this.gatherteksti.GetComponent<Text>().text = "Press 'E' to read";
            } else {
                this.gatherteksti.GetComponent<Text>().text = "Press 'E' to gather";
            }
            Debug.Log("Nyt voi kerätä esineen " + other.name);
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<kerattavakoodi>().voikerata = false;
        this.gatherteksti.GetComponent<Text>().text = "";
        this.tekstiruutu.SetActive(false);

    }
}

    