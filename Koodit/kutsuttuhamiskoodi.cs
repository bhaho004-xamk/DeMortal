using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kutsuttuhamiskoodi : MonoBehaviour
{
    public float voimaylos = 10f;
    public float voimasivulle = 8f;

    void Start()
    {
        float xVoima = Random.Range(-voimasivulle, voimasivulle);
        float yVoima = Random.Range(voimaylos / 2, voimaylos);
        float zVoima = Random.Range(-voimasivulle, voimasivulle);

        Vector3 liikevoima = new Vector3(xVoima, yVoima, zVoima);

        GetComponent<Rigidbody>().velocity = liikevoima;
    }
}
