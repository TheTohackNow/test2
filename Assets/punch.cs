using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punch : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("enemy"))
        {
            Destroy(other.gameObject); 
        }
    }
}
