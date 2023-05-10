using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{

    public Text gameOverRoundText;
    private int roundsSurvived;

    // Start is called before the first frame update
    void Start()
    {
        roundsSurvived = GlobalVariables.roundNumber - 1;
        gameOverRoundText.text = roundsSurvived.ToString();
        GlobalVariables.money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
