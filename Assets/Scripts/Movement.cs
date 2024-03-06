using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float JumpForce;
    public bool playerIsAlive = true;
    public float waitTime = 1f;

    private LevelLoader loader;
    public AudioSource sound;
    public AudioSource sound2;

    public GameObject player2;
    private Collider2D collider;



    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("currentScore", "0");
        myRigidbody.GetComponent<Rigidbody2D>();
        loader = FindObjectOfType<LevelLoader>();
        collider = player2.GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && playerIsAlive)
        {
            myRigidbody.velocity = Vector2.up * JumpForce;
            JumpForce += Time.deltaTime * 15f;
            sound2.Play();

        }

        if (Input.GetKeyUp(KeyCode.Space) && playerIsAlive)
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
            collider.enabled = false;
            
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
