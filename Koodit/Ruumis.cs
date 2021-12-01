using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ruumis : MonoBehaviour
{
    public bool taikaa = false;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    private float amplitude = 0.1f;
    public GameObject silma1 = null;
    public GameObject silma2 = null;
    public GameObject koodivarasto = null;
    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
        tempPos = posOffset;
        this.koodivarasto = GameObject.Find("Koodivarasto");
    }

    // Update is called once per frame
    public void Update()
    {
        if(taikaa == true)
        {
           if(tempPos.y < 1.5f)
           tempPos.y += Time.deltaTime * amplitude;
           transform.position = tempPos;
            this.silma1.SetActive(true);
            this.silma2.SetActive(true);
        }

        if (taikaa == false && tempPos.y > 0.4f)
        {
            tempPos.y -= Time.deltaTime * 2 * amplitude;
            transform.position = tempPos;
            this.silma1.SetActive(false);
            this.silma2.SetActive(false);
        }

        if (taikaa == true)
        {
            if (tempPos.y > 1.4f)
            {
                if(koodivarasto.GetComponent<tavaratkoodi>().pupuasetettu == false)
                {
                    Debug.Log("BAD ENDING");
                    SceneManager.LoadScene("demonendingscene");

                }

                if (koodivarasto.GetComponent<tavaratkoodi>().pupuasetettu == true)
                {
                    Debug.Log("GOOD ENDING");
                    SceneManager.LoadScene("resurrectionendingscene");
                }
            }
               
        }
    }
}
