using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tarttumiskoodi : MonoBehaviour
// TESTISSÄ ESINEEN levitointi
{
    private Rigidbody rb;
    public Rigidbody pelaajarb;
    public bool leijuminen = false;
    private float siirtovoima = 0f;
    private GameObject pelaaja = null;
    public GameObject taikaefekti = null;
    public GameObject paakamera = null;
    public GameObject tahtain = null;
    private GameObject uipiste = null;
    private bool hover = false;
    public bool palaa = false;

    private float aloitusetaisyys;
    private void Start()
    {
        this.pelaaja = GameObject.Find("Pelaaja");
        this.paakamera = GameObject.Find("MainCamera");
        this.pelaajarb = GameObject.Find("Pelaaja").GetComponent<Rigidbody>();
        this.tahtain = GameObject.Find("tahtain");
        this.uipiste = GameObject.Find("osoitin");
}
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        siirtovoima = rb.mass * 250f;
    }

    private void FixedUpdate()
    {

    }

 
   public void nouse()
    {
          rb.useGravity = true;
        Vector3 suuntapelaajaan = (this.pelaaja.transform.position - this.transform.position).normalized;
        this.rb.AddForce(0, (siirtovoima * 0.6f), 0);
        this.rb.AddForce(siirtovoima * (suuntapelaajaan));
        this.rb.AddTorque(50, 10, 20);
        this.leijuminen = true;
        this.aloitusetaisyys = this.transform.position.z;
        Debug.Log(aloitusetaisyys);
        this.transform.parent = paakamera.transform;
        rb.drag = 5;
        this.transform.GetChild(0).gameObject.SetActive(true);
    }


    public void Update()
    {
        if (leijuminen == true && pelaaja.GetComponent<taikakoodi>().loitsu == "c a b ")
        {
            // liikuta esinettä hiiren perässä, myöhemmin mahdollisesti pieni slow down?
            leijuminen = false;
        }

        // Liikutetaan esinettä lähemmäksi pelaajaa
        if (leijuminen == true && Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            Vector3 suuntapelaajaan = (this.paakamera.transform.position - this.transform.position).normalized;
            this.rb.AddForce(2 * siirtovoima * (suuntapelaajaan));
            this.rb.AddTorque(25, 5, 20);
            this.aloitusetaisyys = this.transform.position.z;
        }
        // Liikutetaan esinettä kauemmaksi pelaajasta
        if (leijuminen == true && Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            Vector3 suuntapoispelaajasta = (this.tahtain.transform.position - this.transform.position).normalized;
            this.rb.AddForce(3 * siirtovoima * (suuntapoispelaajasta));
            this.rb.AddTorque(-25, -5, -20);
            this.aloitusetaisyys = this.transform.position.z;
        }

        // pyöritetään esinettä ilmassa
        if (leijuminen == true && Input.GetKey(KeyCode.Mouse0))
        {
            this.rb.AddTorque(60, 0, 0);
        }

        // Pyöritetään esinettä ilmassa
        if (leijuminen == true && Input.GetKey(KeyCode.Mouse1))
        {
            this.rb.AddTorque(0, 60, 0);
        }

       if(leijuminen == false)
        {
            this.transform.parent = null;
            this.transform.GetChild(0).gameObject.SetActive(false);
            rb.drag = 0.5f;
        }

        if (leijuminen == true)
        {
            rb.AddForce(-Physics.gravity * Time.deltaTime, ForceMode.VelocityChange);

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rb.AddForce(0.1f * siirtovoima * pelaajarb.velocity.normalized);

            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                rb.AddForce(0.05f * siirtovoima * pelaajarb.velocity.normalized);

            }
        }
    }


    void OnMouseOver()
    {
      this.pelaaja.GetComponent<taikakoodi>().nostettavaesine = this.gameObject;
        this.uipiste.GetComponent<Image>().color = Color.magenta;
        this.hover = true;
    }


    void OnMouseExit()
    {
        if (this.hover == true)
        {
            this.uipiste.GetComponent<Image>().color = Color.white;
            this.hover = false;
        }
    }
    
    }