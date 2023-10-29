using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    float _speed = 5.0f;

    int _xDir, _yDir;

    [SerializeField] float _xLimit = 10.0f;
    [SerializeField] float _yLimit = 4.85f;

    [SerializeField] AudioClip _WallC;
    [SerializeField] AudioClip _Paddle;
    [SerializeField] AudioClip _Endg;

    AudioSource _source;

    void Start()
    {
        ResetBall();

        _source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameBehavior.Instance.State == GameBehavior.GameStates.Play)
        {
            if (Mathf.Abs(transform.position.y) >= _yLimit)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y > 0 ? _yLimit : -_yLimit,
                    transform.position.z
                );
                _yDir *= -1;
                _source.clip = _WallC;
                _source.Play();
            }

            if (Mathf.Abs(transform.position.x) >= _xLimit)
            {
                GameBehavior.Instance.UpdateScore(
                    transform.position.x > 0 ? 1 : 2);
                _source.PlayOneShot(_Endg);
                ResetBall();
        
            }


            transform.position +=
                new Vector3(
                    _speed * _xDir,
                    _speed * _yDir, 0) * Time.deltaTime;
        }
        
    }

    void ResetBall()
    {
        _speed = GameBehavior.Instance.BallSpeedInit;
        transform.position = Vector3.zero;

        // Ternary Operator
        // destination = condition ? passing : failing; 
        _xDir = Random.Range(0.0f, 1.0f) >= 0.5f ? 1 : -1;
        _yDir = Random.Range(0.0f, 1.0f) >= 0.5f ? 1 : -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            _speed += GameBehavior.Instance.BallSpeedIncrement;
            _xDir *= -1;
            _source.PlayOneShot(_Paddle);
        }
    }
}
