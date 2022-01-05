using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //private RectTransform background;

    private int pontuacao = 0;
    private int highScore = 0;

    private float timer = 1;

    private TextMeshProUGUI currentPointsTxt;
    private TextMeshProUGUI highScoreTxt;
        
    private void Awake()
    {
        DontDestroyOnLoad(this);
        AddPoints(0);
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<0)
        {
            AddPoints(1);
            timer = 1;
        }
    }

    public void AddPoints(int points)
    {
        pontuacao += points;
        currentPointsTxt = GameObject.Find("PontuacaoAtual").GetComponent<TextMeshProUGUI>();
        currentPointsTxt.text = "Score: " + pontuacao.ToString();

        highScoreTxt = GameObject.Find("High").GetComponent<TextMeshProUGUI>();

        if (pontuacao > highScore)
        {
            highScore = pontuacao;            
            highScoreTxt.text = "Highest: " + highScore.ToString();
        }

        RectTransform background = GameObject.Find("Background").GetComponent<RectTransform>();

        highScoreTxt.ForceMeshUpdate();
        float highScoreSize = highScoreTxt.GetRenderedValues(false).magnitude;
        currentPointsTxt.ForceMeshUpdate();
        float currentScoreSize = currentPointsTxt.GetRenderedValues(false).magnitude;

        if(highScoreSize > currentScoreSize)
        {
            background.localScale = new Vector3(highScoreSize / 100f, 1f);
        }
        else 
        {
            background.localScale = new Vector3(currentScoreSize / 100f, 1f);
        }
    }

    public void Resetar()
    {
        pontuacao = 0;
        highScoreTxt = GameObject.Find("High").GetComponent<TextMeshProUGUI>();
        highScoreTxt.text = "Highest: " + highScore.ToString();
    }
}
