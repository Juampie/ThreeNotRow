using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Mover : MonoBehaviour
{
    [SerializeField] float _speed;
    private MaxScore _maxScore;

    private void Start()
    {
        StartCoroutine(FastStart());
        _maxScore = GameObject.Find("MaxScore").GetComponent<MaxScore>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y <= -4.3)
        {
            _maxScore.UpdateMaxScoreText();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    IEnumerator FastStart()
    {
        _speed *= 6;
        yield return new WaitForSeconds(2f);
        _speed /= 6;

    }
}
