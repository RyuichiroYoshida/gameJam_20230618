using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject _gameManeger = null;
    [SerializeField]
    GameObject _enemy = null;
    [SerializeField] 
    float _interval = 1f;

    [System.NonSerialized]
    public int _waveNum = 1;

    float _timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _interval)
        {
            Instantiate(_enemy, this.gameObject.transform.position, Quaternion.identity);
            _timer = 0;

        }        
    }
}
