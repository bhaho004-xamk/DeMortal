using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamahakkikoodi : MonoBehaviour
{
    private bool voimurskaantua = false;
    private float asettumisenlaskuri = 0f;

    private void Update()
    {
        if(voimurskaantua == false)
        {
            this.asettumisenlaskuri += 1f * Time.deltaTime;
        }

        if(asettumisenlaskuri > 5 && voimurskaantua == false)
        {
            Debug.Log("nyt saa murskata");
            this.voimurskaantua = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Pelaaja" || other.name == "MainCamera")
        {
            Debug.Log("AUTS"); // lis‰‰ koodi pikaiseen v‰l‰hdykseen?
        }
        else if (other.name != "Terrain"  )
        {
            if(voimurskaantua == true)
            {
                Destroy(this.gameObject);
            }
        }
       
    }
}
