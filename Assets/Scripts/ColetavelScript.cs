using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetavelScript : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            GetComponent<AudioSource>().Play();
            GetComponent<Renderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            
            Destroy(gameObject, 3);
        }
    }
}
