using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreHandler : MonoBehaviour
{

    public Text CurrentScore;
    public Text highScore;

    

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScore.text = PlayerPrefs.GetString("currentScore");

        highScore.text = PlayerPrefs.GetInt("highscore").ToString();

    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
