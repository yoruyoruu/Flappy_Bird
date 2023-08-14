using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public Sprite[] Sprites;
    private int _spriteIndex;
    private Vector3 _direction;
    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private float _strength = 5f;

    private void Awake() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() 
    {
        InvokeRepeating(nameof(animateSprite), 0.15f, 0.15f);
    }

    private void OnEnable() 
    {
        Vector3 posicion = transform.position;
        posicion.y = 0f;
        transform.position = posicion;
        _direction = Vector3.zero;
    }
    
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _direction = Vector3.up * _strength;
        }

        _direction.y += _gravity * Time.deltaTime;
        transform.position += _direction * Time.deltaTime;
    }

    private void animateSprite()
    {
        _spriteIndex++;

        if (_spriteIndex >= Sprites.Length)
        {
            _spriteIndex = 0;
        }

        _spriteRenderer.sprite = Sprites[_spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindAnyObjectByType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindAnyObjectByType<GameManager>().IncreaseScore();
        }
    }

}
