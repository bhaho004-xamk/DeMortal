using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lopetuskoodi1 : MonoBehaviour
{
    public GameObject pelaaja = null;
    public bool loppulaskenta = false;
    private float lopetuslaskuri = 4f;

    private void Start()
    {
        this.pelaaja = this.pelaaja = GameObject.Find("Pelaaja");
    }
    void Update()
    {
        if(loppulaskenta == true)
        {
            lopetuslaskuri -= 1f * Time.deltaTime;
        }
        // Lopetetaan sovellus
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        } // end if

        if (lopetuslaskuri < 0)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    } // end Update



    
} // end Class
