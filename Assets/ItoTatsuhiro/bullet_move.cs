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
        transform.Translate(0.25f, 0, 0);        //弾の移動

        if (transform.position.x > 12)
        {
            Destroy(gameObject);    //画面外に出た弾を消す
        }
    }
}
