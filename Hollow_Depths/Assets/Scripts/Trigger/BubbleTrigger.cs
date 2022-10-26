using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTrigger : MonoBehaviour
{
    public GameObject Bubbles;
    public GameObject OxygenTank;
    private GameObject Player;
    private IEnumerator Counter;
    private int BubbleCount;
    
    [SerializeField] private GameObject displayed;
    void Start()
    {
        Bubbles.SetActive(false);
        OxygenTank.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Player");
        Counter = Player.GetComponent<Player_Oxygen_Segmented>().OxygenCounter();
        BubbleCount = Bubbles.transform.childCount;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Bubbles.SetActive(true);
            OxygenTank.SetActive(true);
            StartCoroutine(Counter);
            RespawnBubbles();
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

    public void RespawnBubbles()
    {

        int numChildren = Bubbles.transform.childCount;

        for (int i = 0; i < BubbleCount; i++)

        {

           Bubbles.transform.GetChild(i).gameObject.SetActive(true);   

        }

    }






}
