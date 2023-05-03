using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float _time;
    [SerializeField] Transform parent; 
    [SerializeField] GameObject[] _gameObjects;
    void Start()
    {
        StartCoroutine(Spawn());
       
    }
    

    IEnumerator Spawn()
    {
        while (true)
        {
            
            var obj = Instantiate(_gameObjects[Random.Range(0, _gameObjects.Length)], transform);
            obj.transform.SetParent(parent);
            obj.transform.localScale = Vector3.one;
            yield return new WaitForSeconds(_time);
        }
        
    }
}
