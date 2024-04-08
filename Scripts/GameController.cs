using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Camera cam;
    public GameObject[] ball;
    public float timeLeft;
    public Text timerText;
    public Text scoreText;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject menuButton;
    public HatController hatController;

    private bool playing;
    private float maxWidth;


    void Start()
    {

        if (cam == null)
            cam = Camera.main;

        playing = true;

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);

        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);

        float ballWidth = ball[0].GetComponent<Renderer>().bounds.extents.x;

        maxWidth = targetWidth.x - ballWidth;

        StartCoroutine(Spawn());

        UpdateText();
    }

    public void startGame()
    {
        hatController.toggleControl(true);
        StartCoroutine(Spawn());
    }

    public void Menu()
    {
        menuButton.SetActive(true);
        SceneManager.LoadScene("Menu");
    }

    void FixedUpdate()
    {
        if (playing)
        {

            if (timeLeft < 0)
            {
                timeLeft = 0;
                SceneManager.LoadScene("Game2");
            }

            timeLeft -= Time.deltaTime;
            UpdateText();
        }
    }

    void UpdateText()
    {
        timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft);
    }

    IEnumerator Spawn()
    {

        yield return new WaitForSeconds(2.0f);


        while (timeLeft > 0)
        {

            GameObject ballSpawn = ball[Random.Range(0, ball.Length)];

            Vector3 spawnPosition = new Vector3(
                Random.Range(-maxWidth, maxWidth),
                transform.position.y,
                0.0f
                );

            Quaternion spawnRotation = Quaternion.identity;

            Instantiate(ballSpawn, spawnPosition, spawnRotation);

            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        }

        yield return new WaitForSeconds(1.0f);
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        hatController.toggleControl(false);
    }
}
