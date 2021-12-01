using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class resurrectionkoodi : MonoBehaviour
{
    public bool taikaa = false;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    private float amplitude = 0.03f;
    public GameObject silma1 = null;
    public GameObject silma2 = null;
    public GameObject koodivarasto = null;
    public GameObject rituaalirinki= null;
    public bool silmatloistaa = false;
    public float sekuntikello = 0f;
    public GameObject mustaruutu = null;
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

        Debug.Log(sekuntikello);

        if (tempPos.y > 0f)
        {
            tempPos.y -= Time.deltaTime * amplitude;
            transform.position = tempPos;
        }

        if (this.sekuntikello > 0.2f)
        {
            this.mustaruutuhalvenee = true;
        }

        if (this.sekuntikello > 0.8f)
        {
            this.teksti1.SetActive(true);
        }

        if (this.sekuntikello > 0.9f)
        {
            mustaruutuilmestyy = true;
        }


        if (this.sekuntikello > 1.5f)
        {
            this.teksti1.SetActive(false);
        }

        if (this.sekuntikello > 1.8f)
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
