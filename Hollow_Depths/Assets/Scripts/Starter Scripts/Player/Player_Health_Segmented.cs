using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health_Segmented : MonoBehaviour {
    // InstaDeath objects should be tagged "Death" and set as a trigger
    // Enemies (and other 1-damage obstacles) should be tagged "Enemy" and should NOT be set as a trigger

    //private AudioManager audioManager; 
    private GameObject respawn;

    private int playerScore;

    public int MaxHealth = 3;
    public int CurrentHealth = 3;

    // [Tooltip("The score value of a coin or pickup.")]
    // public int coinValue = 5;
    // [Tooltip("The amount of points a player loses on death.")]
    // public int deathPenalty = 20;

  //  public Text scoreText;
    // Feel free to add more! You'll need to edit the script in a few spots, though.
    public GameObject health3;
    public GameObject health2;
    public GameObject health1;
    private GameObject Player;
    private GameObject Water;

    public PlayerAudio playerAudio;

    // Use this for initialization
    void Start()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn");
        Player = GameObject.FindGameObjectWithTag("Player");
        Water = GameObject.FindGameObjectWithTag("Water");

        playerAudio = GetComponent<PlayerAudio>();
        

        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        //Debug.Log(audioManager);

        //  playerScore = 0;
        //  scoreText.text = playerScore.ToString("D4");

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
        // else if (collision.CompareTag("Health"))
        // {
        //     AddHealth();
        //     Destroy(collision.gameObject);
        // }
         if (collision.CompareTag("Death"))
        {
            Respawn();
        }
        else if (collision.CompareTag("Health"))
        {
            AddHealth();
            Destroy(collision.gameObject);
        }

        else if (collision.CompareTag("Collection"))
        {
            playerAudio.CollectSource.Play();
        }

        else if (collision.CompareTag("Water"))
        {
            playerAudio.LoopBreathingAudio = true;
            playerAudio.BreathingSource.Play();
           
        }

        else if (collision.CompareTag("Oxygen"))
        {
            playerAudio.BubblesSource.Play();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            playerAudio.BreathingSource.Stop();
            playerAudio.LoopBreathingAudio = false;
           

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage();
        }

        //===My code to have already been damage at the beginning
        if (collision.collider.CompareTag("BeginTut"))
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage()
    {
        // For more health, copy the if block for health3, change health3 to whatever yours is,
        // then change the if statement for health3 to else if

        //FindObjectOfType<AudioManager>().Play("Ding");

        //GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Ding");

        //audioManager.Play("Ding");

        playerAudio.DamageSource.Play();

        --CurrentHealth;

        if (CurrentHealth == 2)
        {

            health3.SetActive(false);

        }
        else if (CurrentHealth == 1)
        {

            health2.SetActive(false);

        }
        else
        {

            Respawn();

        }
        
    }
     
    public void AddHealth()
    /*{
        if (!health2.activeInHierarchy)
        {
            health2.SetActive(true);
        }
        else if (!health3.activeInHierarchy)
        {
            health3.SetActive(true);
        }
        // For more health, just copy the else if block for health3 and change the name.
    } */
        {
        if (CurrentHealth == 1)
        {
            health2.SetActive(true);
            CurrentHealth++;
        }
        else if (CurrentHealth == 2)
        {
            health3.SetActive(true);
            CurrentHealth++;
        }
        else
        {
            CurrentHealth = 3;
            health3.SetActive(true);
        }
        // For more health, just copy the else if block for health3 and change the name.
    }
    public void Respawn()
    {
        // For more health, just add another similar line here.
        health3.SetActive(true);
        health2.SetActive(true);
        health1.SetActive(true);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.transform.position = respawn.transform.position;
        CurrentHealth = 3;
        Player.GetComponent<Player_Oxygen_Segmented>().currentOxygen=4;
        Player.GetComponent<Player_Oxygen_Segmented>().oxygen4.SetActive(true);
        Player.GetComponent<Player_Oxygen_Segmented>().oxygen3.SetActive(true);
        Player.GetComponent<Player_Oxygen_Segmented>().oxygen2.SetActive(true);
        Player.GetComponent<Player_Oxygen_Segmented>().oxygen1.SetActive(true);
        Water.GetComponent<BubbleTrigger>().RespawnBubbles();


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
