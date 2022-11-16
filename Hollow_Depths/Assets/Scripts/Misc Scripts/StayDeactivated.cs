using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayDeactivated : MonoBehaviour
{
    [SerializeField] private GameObject displayed;
    void Start()
    {
        if (CompareTag("Collection"))
       {
        displayed.SetActive(true);
       }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            displayed.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            displayed.SetActive(false);
        }
    }
}
