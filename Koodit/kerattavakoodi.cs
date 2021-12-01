using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class kerattavakoodi : MonoBehaviour
{
    public bool voikerata = false;
    public bool lukemassa = false;
    private GameObject koodivarasto = null;
    public GameObject tekstiruutu = null;
    public GameObject tekstiruututeksi = null;
    public GameObject gatherteksti = null;
    public string luettavateksti = null;
    // Start is called before the first frame update
    void Start()
    {
        this.koodivarasto = GameObject.Find("Koodivarasto");
        this.gatherteksti = GameObject.Find("gatherteksti");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && voikerata == true)
        {
            if(this.name.StartsWith("kynttila"))
            {
                koodivarasto.GetComponent<tavaratkoodi>().kynttiloitakeratty += 1;
                Debug.Log("Kynttiloita taskussa " + koodivarasto.GetComponent<tavaratkoodi>().kynttiloitakeratty);
                Destroy(this.gameObject);
                this.gatherteksti.GetComponent<Text>().text = "";
            }

            if (this.name == "omapupu")
            {
                koodivarasto.GetComponent<tavaratkoodi>().pupukeratty = true;
                Debug.Log("Onko pupu mukana " + koodivarasto.GetComponent<tavaratkoodi>().pupukeratty);
                Destroy(this.gameObject);
                this.gatherteksti.GetComponent<Text>().text = "";
            }

            if (this.name == "kirjansivu01kerattava")
            {
                koodivarasto.GetComponent<kirjansivutkoodi>().sivunpalanen01loytynyt = true;
                Debug.Log("Sivu 1 " + koodivarasto.GetComponent<kirjansivutkoodi>().sivunpalanen01loytynyt);
                Destroy(this.gameObject);
                this.gatherteksti.GetComponent<Text>().text = "";
            }
            if (this.name == "kirjansivu02kerattava")
            {
                koodivarasto.GetComponent<kirjansivutkoodi>().sivunpalanen02loytynyt = true;
                Debug.Log("Sivu 2 " + koodivarasto.GetComponent<kirjansivutkoodi>().sivunpalanen01loytynyt);
                Destroy(this.gameObject);
                this.gatherteksti.GetComponent<Text>().text = "";
            }
            if (this.name == "kirjansivu03kerattava")
            {
                koodivarasto.GetComponent<kirjansivutkoodi>().sivunpalanen03loytynyt = true;
                Debug.Log("Sivu 3 " + koodivarasto.GetComponent<kirjansivutkoodi>().sivunpalanen01loytynyt);
                Destroy(this.gameObject);
                this.gatherteksti.GetComponent<Text>().text = "";
            }

            if (this.tag == "luettava" && this.lukemassa == false)
            {
                this.tekstiruututeksi.GetComponent<Text>().text = this.luettavateksti;
                this.tekstiruutu.SetActive(true);
                this.gatherteksti.GetComponent<Text>().text = "Press E to close";
                this.lukemassa = true;
            }
            else if (this.tag == "luettava" && this.lukemassa == true)
            {
                Debug.Log("Kirjakäteen");
                this.tekstiruutu.SetActive(false);
                this.gatherteksti.GetComponent<Text>().text = "";
                this.lukemassa = false;
            }
        }
    }
}
