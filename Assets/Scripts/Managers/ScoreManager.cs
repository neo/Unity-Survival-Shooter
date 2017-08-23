using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;


    Text text;
    static float displayScore = 0f;
    static float speed = 5f;


    void Awake ()
    {
        text = GetComponent <Text> ();
        displayScore = score = 0;
    }


    void Update ()
    {
        displayScore = Mathf.Lerp(displayScore, score, speed * Time.deltaTime);
        text.text = "Score: " + Mathf.Ceil(displayScore);
    }
}
