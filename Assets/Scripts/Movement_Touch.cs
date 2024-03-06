using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement_Touch : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float JumpForce;
    public bool playerIsAlive = true;
    public float waitTime = 1f;

    private LevelLoader loader;
    public AudioSource sound;
    public AudioSource sound2;



    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("currentScore", "0");
        myRigidbody.GetComponent<Rigidbody2D>();
        loader = FindObjectOfType<LevelLoader>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && playerIsAlive)
        {
            myRigidbody.velocity = Vector2.up * JumpForce;
            JumpForce += Time.deltaTime * 15f;
            sound2.Play();

        }

        if (Input.touchCount == 0 && playerIsAlive)
        {
            JumpForce = 4;
        }





    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {

            playerIsAlive = false;
            DistanceUI.instance.SetScore();

            Time.timeScale = 0f;
            sound.Play();

            StartCoroutine(LoadSceneDelay());

        }
    }

    private IEnumerator LoadSceneDelay()
    {
        yield return new WaitForSecondsRealtime(waitTime);

        loader.LoadNextScene();

        Time.timeScale = 1f;

    }
}
