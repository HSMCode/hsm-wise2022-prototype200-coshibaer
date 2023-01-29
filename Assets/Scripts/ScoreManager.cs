using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text textScore;
    public float score;
    public string LevelToLoad;


    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        textScore.text = "GIFTS: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "GIFTS: " + score.ToString();

        if(score == 10f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
