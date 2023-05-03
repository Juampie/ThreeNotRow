using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour
{
    static int _maxScore = 0;
    private Text _scoreText;
    private Text _maxScoreText;

    private void Start()
    {
        _scoreText = GameObject.Find("Score").GetComponent<Text>();
        _maxScoreText = GetComponent<Text>();
        _maxScoreText.text = _maxScore.ToString();
    }

    public void UpdateMaxScoreText()
    {
        if (Convert.ToInt32(_scoreText.text) > Convert.ToInt32(_maxScoreText.text))
        {
            _maxScoreText.text = _scoreText.text;
            _maxScore = Convert.ToInt32(_maxScoreText.text);
      
            
        }
        
    }
}
