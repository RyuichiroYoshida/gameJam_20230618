using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [System.NonSerialized] public float _score = 0; //score値
    float _time = 0; //経過時間

    [SerializeField] Text _scoretext; //スコア表示text

    void Start()
    {
        _score += 1000;
    }

    // Update is called once per frame
    void Update()
    {

        

        _time += Time.deltaTime;

        _scoretext.text = _score.ToString();

    }
}
