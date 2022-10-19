using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTrigger : MonoBehaviour
{
    public GameObject Bubbles;
    public GameObject OxygenTank;
    private GameObject Player;
    private IEnumerator Counter;
    
    [SerializeField] private GameObject displayed;
    void Start()
    {
        Bubbles.SetActive(false);
        OxygenTank.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Player");
        Counter = Player.GetComponent<Player_Oxygen_Segmented>().OxygenCounter();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Bubbles.SetActive(true);
            OxygenTank.SetActive(true);
            StartCoroutine(Counter);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Bubbles.SetActive(false);
            OxygenTank.SetActive(false);
            StopCoroutine(Counter);
            Player.GetComponent<Player_Oxygen_Segmented>().InitialOxygen = true;
        }
    }

}
