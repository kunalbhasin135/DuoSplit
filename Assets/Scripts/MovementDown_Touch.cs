using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementDown_Touch : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float JumpForceDown;
    public bool playerisalive = true;
    public float delay = 1f;
    public AudioSource sound1;
    public AudioSource sound3;
    private LevelLoader loader2;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody.GetComponent<Rigidbody2D>();
        loader2 = FindObjectOfType<LevelLoader>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && playerisalive)
        {
            myRigidbody.velocity = Vector2.up * JumpForceDown;
            JumpForceDown -= Time.deltaTime * 15f;
            sound3.Play();

        }

        if (Input.touchCount == 0 && playerisalive)
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
