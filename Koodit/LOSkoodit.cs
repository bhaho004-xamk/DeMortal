using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOSkoodit : MonoBehaviour
{
    GameObject pelaaja;
    private void Start()
    {
        this.pelaaja = GameObject.Find("Pelaaja");
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name == this.pelaaja.GetComponent<taikakoodi>().nostettavaesine.name)
        {
            other.GetComponent<Tarttumiskoodi>().leijuminen = false;
            Debug.Log("ulkona voiman alueelta");
        }
    }
}
