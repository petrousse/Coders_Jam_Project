using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour

{
    float timeLeft = 60f;
    public GameObject script;
    public Text text;
    public GameObject cam;
    public GameObject player;
    public GameObject canva;
    public GameObject winscreen;
    public GameObject mechant;
    public Transform maincam;
    public Transform newcam;
    public Camera cams;

    public float speed = 100.0f;
    void start()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("enemy");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && winscreen.activeSelf)
        {
            SceneManager.LoadScene(0);
        }

        timeLeft -= Time.deltaTime;
        text.text = "" + Mathf.Round(timeLeft);
        if (timeLeft <= 0)
        {
            float step = speed * Time.deltaTime;
            maincam.transform.position = Vector3.MoveTowards(maincam.transform.position, newcam.position, step);
            text.text = "";
            player.gameObject.SetActive(false);
            canva.gameObject.SetActive(false);
            mechant.gameObject.SetActive(false);
            script.gameObject.SetActive(false);

            GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject go in foundObjects)
            {
                Destroy(go);
            }

            cams.orthographicSize = cams.orthographicSize + 4 * Time.deltaTime;
            if (cams.orthographicSize > 15)
            {
                cams.orthographicSize = 15;
                winscreen.gameObject.SetActive(true);

            }
        }
    }
}