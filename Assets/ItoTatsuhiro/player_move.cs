using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public GameObject bullet;

    private Rigidbody _rigidbody;

    float time = 0;

    Vector2 _transform;

    [SerializeField] GameManager _gameManager;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _transform = transform.position;
    }

    private void Update()
    {
        if (transform.position.x > -5.5)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))     //���L�[�ō��ɓ���
            {

                transform.Translate(-0.1f, 0, 0);
            }
        }
        if (transform.position.x < 5.5) {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))    //�E�L�[�ŉE�ɓ���
            {
                transform.Translate(0.1f, 0, 0);
            }
        }
        if (transform.position.y < 4.5) { 
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))       //��L�[�ŏ�ɓ���
            {
                transform.Translate(0, 0.1f, 0);
            }
         }
        if (transform.position.y > -4.5)
        {
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))     //���L�[�ŉ��ɓ���
            {
                transform.Translate(0, -0.1f, 0);
            }
        }

        time += Time.deltaTime;

        if (time > 0.1f)        //0.1�b���ɒe���o��
        {
            Instantiate(bullet, new Vector3(transform.position.x + 0.6f, transform.position.y + 0.3f, transform.position.z), Quaternion.identity);
            Instantiate(bullet, new Vector3(transform.position.x + 0.6f, transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(bullet, new Vector3(transform.position.x + 0.6f, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);

            time = 0;
        }

    }   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" ||  collision.gameObject.tag == "EnemyBullets")
        {
            _gameManager.PlayerLifeChange();
            print("aaa");
        }
    }

    public void PlayerDead()
    {
        transform.position = _transform;
    }

}
