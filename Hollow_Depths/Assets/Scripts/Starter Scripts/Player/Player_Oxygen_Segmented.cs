using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Oxygen_Segmented : MonoBehaviour {
    // InstaDeath objects should be tagged "Death" and set as a trigger
    // Enemies (and other 1-damage obstacles) should be tagged "Enemy" and should NOT be set as a trigger

    private GameObject respawn;

    private int playerScore;
   

    // [Tooltip("The score value of a coin or pickup.")]
    // public int coinValue = 5;
    // [Tooltip("The amount of points a player loses on death.")]
    // public int deathPenalty = 20;

  //  public Text scoreText;
    // Feel free to add more! You'll need to edit the script in a few spots, though.
    public GameObject oxygen4;
    public GameObject oxygen3;
    public GameObject oxygen2;
    public GameObject oxygen1;
    private GameObject Player;
    public bool InitialOxygen = true;

    public int currentOxygen = 4;



    public IEnumerator OxygenCounter() {
        while (Player.GetComponent<Player_Health_Segmented>().CurrentHealth > 0) {
        if (InitialOxygen) { InitialOxygen = false; }
            else {
                --currentOxygen;

                if (currentOxygen == 3)
                {

                    oxygen4.SetActive(false);

                }
                else if (currentOxygen == 2)
                {

                    oxygen3.SetActive(false);

                }
                else if (currentOxygen == 1)
                {

                    oxygen2.SetActive(false);

                }
                else
                {

                    Player.GetComponent<Player_Health_Segmented>().TakeDamage();

                }

                  
            }
            yield return new WaitForSeconds(8);
        }
    }





    // Use this for initialization
    void Start()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn");
        //  playerScore = 0;
        //  scoreText.text = playerScore.ToString("D4");
        Player = GameObject.FindGameObjectWithTag("Player");
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.CompareTag("Death"))
        // {
        //     Respawn();
        // }
        // else if (collision.CompareTag("Coin"))
        // {
        //    // AddPoints(coinValue);
        //     Destroy(collision.gameObject);
        // }
        // else if (collision.CompareTag("Finish"))
        // {
        //     Time.timeScale = 0;
        // }
        // else if (collision.CompareTag("oxygen"))
        // {
        //     Addoxygen();
        //     Destroy(collision.gameObject);
        // }
         if (collision.CompareTag("Death"))
        {
            Respawn();
        }
        else if (collision.CompareTag("Oxygen"))
        {
            //Player.GetComponent<Player_Health_Segmented>().AddHealth();
          
            if (currentOxygen < 4) {

                ++currentOxygen;

                if (currentOxygen == 4)
                {

                    oxygen4.SetActive(true);

                }
                else if (currentOxygen == 3)
                {

                    oxygen3.SetActive(true);

                }
                else if (currentOxygen == 2)
                {

                    oxygen2.SetActive(true);

                }
                else
                {

                    oxygen1.SetActive(true);

                }

            }



            collision.gameObject.SetActive(false);
        }


    }

    private void TakeDamage()
    {
        // For more oxygen, copy the if block for oxygen3, change oxygen3 to whatever yours is,
        // then change the if statement for oxygen3 to else if
        if (oxygen4.activeInHierarchy)
        {
            oxygen4.SetActive(false);
        }
        else if (oxygen3.activeInHierarchy)
        {
            oxygen3.SetActive(false);
        }
        else if (oxygen2.activeInHierarchy)
        {
            oxygen2.SetActive(false);
        }
        else
        {
            oxygen1.SetActive(false);
            Respawn();
        }
    }
     
    private void Addoxygen()
    {
        if (!oxygen2.activeInHierarchy)
        {
            oxygen2.SetActive(true);
        }
        else if (!oxygen3.activeInHierarchy)
        {
            oxygen3.SetActive(true);
        }
        else if (!oxygen4.activeInHierarchy)
        {
            oxygen4.SetActive(true);
        }
        // For more oxygen, just copy the else if block for oxygen3 and change the name.
    }

    public void Respawn()
    {
        // For more oxygen, just add another similar line here.
        oxygen4.SetActive(true);
        oxygen3.SetActive(true);
        oxygen2.SetActive(true);
        oxygen1.SetActive(true);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.transform.position = respawn.transform.position;
       // AddPoints(deathPenalty);
    }

    // public int GetScore()
    // {
    //     return playerScore;
    // }

    // public void AddPoints(int amount)
    // {
    //     playerScore += amount;
    //     scoreText.text = playerScore.ToString("D4");
    // }
}
