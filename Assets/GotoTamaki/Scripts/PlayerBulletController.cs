using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    //“®‚­‘¬‚³
    [SerializeField]
    float _moveSpeed = 15f;
    [SerializeField]
    float _destroyTime = 3f;

    float _timer = 0;
    Rigidbody2D _rb = default;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector2.right * _moveSpeed;
    }
}
