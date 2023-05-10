using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{

    public Text gameOverScoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScoreText.text = Score.scoreCount.ToString();
        Score.scoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
