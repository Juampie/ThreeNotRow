using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int _score = 0;

    // Update is called once per frame
    public void UpdateScoreText()
    {
        gameObject.GetComponent<Text>().text = _score.ToString();
    }
}
