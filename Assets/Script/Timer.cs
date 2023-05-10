using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private int startValue = 15;
    public Text counter;
    private int counterValue;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoCountDown());
    }

    IEnumerator DoCountDown()
    {
        counterValue = startValue;
        for (int i = 0; i < startValue; i++)
        {
            counterValue -= 1;
            if (counterValue < 11)
            {
                counter.color = Color.red;
            }
            counter.text = counterValue.ToString("D2");
            yield return new WaitForSeconds(1f);
        }
        if (counterValue <= 0f)
        {
            GlobalVariables.roundNumber++;
            SceneManager.LoadScene("RoundScreen");
        }
    }
}
