using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class Click : MonoBehaviour, IPointerClickHandler
{
    private List<GameObject> _list = new(3);
    private Score _score;

    private void Start()
    {
        _score = GameObject.Find("Score").GetComponent<Score>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      
        if (eventData.pointerId == -1)
        {
            if (eventData.pointerEnter.CompareTag("Player"))
            {
             
                if (_list.Count < 3)
                {
                    bool correctly = true;
                    foreach (GameObject item in _list)
                    {
                        if (item == eventData.pointerEnter)
                        {
                            correctly = false;
                        }

                    }
                    if (correctly)
                    {
                        _list.Add(eventData.pointerEnter);
                        GreenColor(eventData.pointerEnter);
                    }


                    if (_list.Count == 3 && Similar(_list))
                    {
                        DestroySimilar();
                    }
                    else if (_list.Count == 3 && !Similar(_list))
                    {
                        ClearColor();
                    }
                }


            }

        }

    }

    private void GreenColor(GameObject gameObject)
    {
        gameObject.transform.parent.gameObject
                    .GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void DestroySimilar()
    {
        foreach (GameObject item in _list)
        {
            Destroy(item.transform.parent.gameObject);

        }
        _score._score++;
        _score.UpdateScoreText();
        _list.Clear();
    }

    private void ClearColor()
    {
        foreach (GameObject item in _list)
        {
            item.transform.parent.gameObject
                    .GetComponent<SpriteRenderer>().color = Color.white;
        }
        _list.Clear();
    }

    private bool Similar(List<GameObject> list)
    {
        bool isSimilar = true;
        SpriteRenderer temp = list[0].GetComponent<SpriteRenderer>();
        foreach (GameObject item in _list)
        {
            SpriteRenderer someObj = item.GetComponent<SpriteRenderer>();
            if (!(temp.sprite == someObj.sprite))
            {
                isSimilar = false;
            }
        }
        return isSimilar;
    }
}
