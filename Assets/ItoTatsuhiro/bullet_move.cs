using System.Collections;
using UnityEngine;

public class bullet_move : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(0.25f, 0, 0);        //�e�̈ړ�

        if (transform.position.x > 12)
        {
            Destroy(gameObject);    //��ʊO�ɏo���e������
        }
    }
}
