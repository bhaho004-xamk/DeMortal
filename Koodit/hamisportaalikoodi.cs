using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamisportaalikoodi : MonoBehaviour
{
    public bool hamisporttiauki = false;
    public GameObject kutsuttavahamis;
    public int hamistenmaara = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hamisporttiauki == true && hamistenmaara < 50)
        {
            Instantiate(kutsuttavahamis, transform.position, Quaternion.identity);
            hamistenmaara++;
        }
    }
}
