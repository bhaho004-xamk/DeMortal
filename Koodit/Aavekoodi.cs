using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Aavekoodi : MonoBehaviour
{
    private Rigidbody rb;
    public Transform pelaaja = null;
    public GameObject paakamera = null;
    public bool jahtausmoodi = true;
    private float liikkumisnopeus = 2.5f;
    public GameObject mustaruutu = null;
    void Start()
	{
        this.paakamera = GameObject.Find("MainCamera");
        this.mustaruutu = GameObject.Find("mustaruutu");
    }

    void Update()
    {
        if (this.jahtausmoodi == true)
        {
            transform.LookAt(this.paakamera.transform.position);
            transform.position += (this.paakamera.transform.position - transform.position).normalized * liikkumisnopeus * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Pelaaja")
        {
            Debug.Log("POSSESSSSSS");
            Destroy(this.gameObject);
            var apupaneeli = mustaruutu.GetComponent<Image>();
            var apuvari = apupaneeli.color;
            apuvari.a = 1f;
            apupaneeli.color = apuvari;
            GameObject.Find("Koodivarasto").GetComponent<lopetuskoodi1>().loppulaskenta = true;
        }
    }
}
