using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class demoniloppu : MonoBehaviour
{
    public bool taikaa = false;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    private float amplitude = 0.06f;
    public GameObject silma1 = null;
    public GameObject silma2 = null;
    public GameObject koodivarasto = null;
    public GameObject loppuliekit = null;
    public bool silmatloistaa = false;
    public float sekuntikello = 0f;
    public GameObject mustaruutu = null;
    public GameObject mustaruutuvari = null;
    public GameObject teksti1 = null;
    public GameObject teksti2 = null;
    public GameObject teksti3 = null;
    private bool mustaruutuhalvenee = false;
    private bool mustaruutuilmestyy = false;
    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
        tempPos = posOffset;
    }
    // Update is called once per frame
    void Update()
    {
        this.sekuntikello += Time.deltaTime * 0.1f;

        if (tempPos.y < 1.2f)
        {
            tempPos.y += Time.deltaTime * amplitude;
            transform.position = tempPos;
        }

        if(this.silmatloistaa == true && this.silma1.GetComponent<Light>().intensity < 2)
        {
            this.silma1.GetComponent<Light>().intensity += Time.deltaTime * 0.6f;
            this.silma2.GetComponent<Light>().intensity += Time.deltaTime * 0.6f;
        }

        if (this.sekuntikello > 0.2f)
        {
            this.mustaruutuhalvenee = true;
        }

        if (this.sekuntikello > 0.5f)
        {
            this.silmatloistaa = true;
            this.teksti1.SetActive(true);
        }

        if (this.sekuntikello > 0.8f)
        {
            this.teksti1.SetActive(false);
        }

        if (this.sekuntikello > 1f)
        {
            this.teksti2.SetActive(true);
        }

        if (this.sekuntikello > 1.5f)
        {
            this.teksti2.SetActive(false);
        }

        if (this.sekuntikello > 1.4f)
        {
            this.loppuliekit.SetActive(true);
        }

        if (this.sekuntikello > 1.7f)
        {
            this.teksti3.SetActive(true);
        }
        

        if (this.sekuntikello > 1.6f)
        {
            this.mustaruutuilmestyy = true;
        }

        if (this.sekuntikello > 2.1f)
        {
            this.teksti3.SetActive(false);
        }

        if (this.sekuntikello > 2.5f)
        {
            SceneManager.LoadScene("introscene");
        }

        if (this.mustaruutuhalvenee == true)
        {
            var apupaneeli = mustaruutu.GetComponent<Image>();
            var apuvari = apupaneeli.color;
            apuvari.a -= 0.5f * Time.deltaTime;
            apupaneeli.color = apuvari;

            if (apuvari.a < 0)
            {
                mustaruutuhalvenee = false;
            }
        }

        if (this.mustaruutuilmestyy == true)
        {
            Debug.Log("mustanruudun saapuminen? ");
            var apupaneeli = mustaruutu.GetComponent<Image>();
            var apuvari = apupaneeli.color;
            apuvari.a += 1.2f * Time.deltaTime;
            apupaneeli.color = apuvari;
        }

    }
}
