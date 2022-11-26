using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayDeactivated : MonoBehaviour
{
    [SerializeField] private GameObject displayed;
    void Start()
    {
        if (CompareTag("Axe_Holder"))
       {
        displayed.SetActive(true);
       }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //displayed.SetActive(false);
            Destroy(gameObject);
            
        }
    }

    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Player"))
    //     {
    //         displayed.SetActive(false);
    //     }
    // }
}
