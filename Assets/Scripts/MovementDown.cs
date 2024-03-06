using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementDown : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float JumpForceDown;
    public bool playerisalive = true;
    public float delay = 1f;
    public AudioSource sound1;
    public AudioSource sound3;
    private LevelLoader loader2;
    public GameObject player;
    private Collider2D collider2;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody.GetComponent<Rigidbody2D>();
        loader2 = FindObjectOfType<LevelLoader>();
        collider2 = player.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && playerisalive)
        {
            myRigidbody.velocity = Vector2.up * JumpForceDown;
            JumpForceDown -= Time.deltaTime * 15f;
            sound3.Play();

        }

        if (Input.GetKeyUp(KeyCode.Space) && playerisalive)
        {
            JumpForceDown = -4;
        }





    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            sound1.Play();
            playerisalive = false;
            DistanceUI.instance.SetScore();
            Time.timeScale = 0f;
            collider2.enabled = false;
            
            StartCoroutine(DelayLoad());
        }
    }

    private IEnumerator DelayLoad()
    {
        yield return new WaitForSecondsRealtime(delay);

        loader2.LoadNextScene();

        Time.timeScale = 1f;

    }
}
