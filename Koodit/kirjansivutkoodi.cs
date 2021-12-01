using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kirjansivutkoodi : MonoBehaviour
{
    //Koodi ylläpitää mitä sivuja on löydetty ja säilyttää ne vaikka scene uudelleenlatautuisikin?
    public bool sivunpalanen01loytynyt = false;
    public bool sivunpalanen02loytynyt = false;
    public bool sivunpalanen03loytynyt = false;

    public GameObject sivunpalanen01a = null;
    public GameObject sivunpalanen01b = null;
    public GameObject sivunpalanen02a = null;
    public GameObject sivunpalanen02b = null;
    public GameObject sivunpalanen03a = null;
    public GameObject sivunpalanen03b = null;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(sivunpalanen01loytynyt == true)
        {
            sivunpalanen01a.SetActive(true);
            sivunpalanen01b.SetActive(true);
        }

        if (sivunpalanen02loytynyt == true)
        {
            sivunpalanen02a.SetActive(true);
            sivunpalanen02b.SetActive(true);
        }

        if (sivunpalanen03loytynyt == true)
        {
            sivunpalanen03a.SetActive(true);
            sivunpalanen03b.SetActive(true);
        }
    }
}
