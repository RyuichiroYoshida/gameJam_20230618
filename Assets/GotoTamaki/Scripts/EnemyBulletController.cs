using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _destroyTime) 
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector2.left * _moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Wall" || other.gameObject.tag == "PlayerBullets") 
        {
            Destroy(this.gameObject);
        }
    }
}
