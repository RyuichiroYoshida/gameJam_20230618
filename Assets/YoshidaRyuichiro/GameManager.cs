using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] player_move _player;

    [SerializeField] Text _scoretext; //スコア表示text

    [SerializeField] GameObject[] _lifes; //lifeImage

    [SerializeField] int _PlayerLife = 1;

    [SerializeField] GameObject _gameOverText;

    [SerializeField] GameObject _button;

    LifeCountDeta _lefeCountDeta = LifeCountDeta.Three;

    int _lifeCounts = 3;
    float _score = 0;

    /// <summary>
    /// 残り残機の添字
    /// </summary>
    public int LifeCounts => _lifeCounts;

    /// <summary>
    /// スコアです
    /// </summary>
    public float Score => _score;

    void Start()
    {
        _gameOverText.SetActive(false);
        _button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _scoretext.text = _score.ToString();

        if (_PlayerLife <= 20 && _PlayerLife > 10 && _lefeCountDeta == LifeCountDeta.Three)
        {
            Lifes();
            _lefeCountDeta = LifeCountDeta.Two;
        }
        else if (_PlayerLife <= 10 && _PlayerLife > 0 && _lefeCountDeta == LifeCountDeta.Two)
        {
            Lifes();
            _lefeCountDeta = LifeCountDeta.One;
        }

        if (_PlayerLife == 0 && _lefeCountDeta == LifeCountDeta.One)
        {
            _lefeCountDeta = LifeCountDeta.Zero;
            Lifes();
            Debug.Log(_lifeCounts);
            Time.timeScale = 0;
            _gameOverText.SetActive(true);
            _button.SetActive(true);
            _player.PlayerDead();
        }
    }

    public void Lifes()
    {
        _lifeCounts--;
        Destroy(_lifes[_lifeCounts]);
    }

    public void ScoreUpper()
    {
        _score += 1000;
    }

    public void PlayerLifeChange()
    {
        _PlayerLife--;
    }

    public void End()
    {
        Time.timeScale = 1;
    }

    enum LifeCountDeta
    {
        Three,
        Two,
        One,
        Zero
    }
}
