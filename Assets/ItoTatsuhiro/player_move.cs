using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))     //���L�[�ō��ɓ���
        {
            transform.Translate(-0.01f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))    //�E�L�[�ŉE�ɓ���
        {
            transform.Translate(0.01f, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))       //��L�[�ŏ�ɓ���
        {
            transform.Translate(0, 0.01f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))     //���L�[�ŉ��ɓ���
        {
            transform.Translate(0, -0.01f, 0);
        }
    }

}
