using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DistanceUI : MonoBehaviour
{

    public Text distanceUI;
    public float multiplier;
    public float dist;
    public int distint;

    public static DistanceUI instance;
    public int HighScore;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        multiplier += Time.fixedDeltaTime;
        dist += multiplier * 0.01f;
        distint = (int)dist;
        distanceUI.text = ((int)dist).ToString();



    }

    public void SetScore()
    {
        PlayerPrefs.SetString("currentScore", distanceUI.text);

        if (distint > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", distint);
            HighScore = distint;

        }

    }

    


}
