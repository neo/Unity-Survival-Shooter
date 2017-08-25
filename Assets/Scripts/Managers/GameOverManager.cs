using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    PlayerHealth playerHealth;
    Animator anim;


    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
        }
    }
}
