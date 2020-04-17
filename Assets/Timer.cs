using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour

{
    float timeLeft = 60f;

    public Text text;
    public GameObject cam;
    public GameObject nextpos;
    public GameObject player;
    public GameObject canva;
    public GameObject mechant;



    void Update()
    {
        timeLeft -= Time.deltaTime;
        text.text = "" + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            mechant.gameObject.SetActive(false);
            player.gameObject.SetActive(false);
            canva.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}