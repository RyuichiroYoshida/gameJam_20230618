using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    GameManager manager;
    //[SerializeField]
    //float _waitTime = 1f;
    [SerializeField]
    int _enemyHp = 1;
    [SerializeField] 
    MoveMode _moveMode;
    //動く速さ
    [SerializeField]
    float _moveSpeed = 1f;
    //振れ幅
    [SerializeField]
    float _amplitude = 1f;
    [SerializeField]
    float _stoppingDistance = 0.5f;

    GameObject _player = default;
    [SerializeField] GameObject _enemyBullet;
    float _y = 0;
    float _time = 0;
    Rigidbody2D _rb = default;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _player = GameObject.FindGameObjectWithTag("Player");
        //_enemyBullet = GameObject.FindGameObjectWithTag("EnemyBullets");
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyHp <=  0)
        {
            manager.ScoreUpper();
            Destroy(this.gameObject);
        }

        _time += Time.deltaTime;
    }

        private void FixedUpdate()
    {
        if (_moveMode == MoveMode.PlayerHomingMove)
        {
            PlayerHomingMove();         
        }
        else if (_moveMode == MoveMode.SinCurveMove)
        {
            SinCurveMove();
            EnemyShoot();
        }
    }

    enum MoveMode
    {
        PlayerHomingMove,
        SinCurveMove,
    }

    void PlayerHomingMove()
    {
        float distance = Vector2.Distance(this.transform.position, _player.transform.position);

        if (distance > _stoppingDistance)  // ターゲットに到達するまで処理する
        {
            Vector2 dir = (_player.transform.position - this.transform.position).normalized * _moveSpeed; // 移動方向のベクトルを求める
            //_rb.AddForce(dir * _moveSpeed, ForceMode2D.Force);
            _rb.velocity = dir * _moveSpeed;
        }
        //else
        //{
        //    _rb.velocity = Vector2.zero;
        //}
    }

    void SinCurveMove()
    {
        _y = Mathf.Sin(_time * _moveSpeed) * _amplitude;
        //Debug.Log(_y);
        _rb.velocity = new Vector2(_rb.velocity.x, _y);
    }

    void EnemyShoot()
    {
        //if (_waitTime < _time)
        //{
            //Debug.Log("Shot");
            Instantiate(_enemyBullet, this.gameObject.transform.position, Quaternion.identity);
        //}      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullets") 
        {
            _enemyHp--;
            //Debug.Log("hit");
        }
    }
}
