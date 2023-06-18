using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [System.NonSerialized] public float _score = 0; //score�l
    float _time = 0; //�o�ߎ���

    [SerializeField] Text _scoretext; //�X�R�A�\��text

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
