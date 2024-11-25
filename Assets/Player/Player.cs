using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    Rigidbody2D _componentRigidbody2D;
    private float _x;
    private float _y;
    public float _Xspeed = 5f;
    public float _Yspeed = 5f;
    private float _minX = -8.29f;
    private float _maxX = 8.25f;
    private float _minY = -4.35f;
    private float _maxY = 4.36f;
    private Transform _componentTransform;

    public GameObject prefabBullet;
    public AudioSource sfxManager;

    private void Awake()
    {
        _componentRigidbody2D = GetComponent<Rigidbody2D>();
        _componentTransform = GetComponent<Transform>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");
        //Metodo para disparar
        if (Input.GetButtonDown("Fire1") == true)
        {
            Shoot();
        }
        Vector2 playerPosition = _componentTransform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x, _minX, _maxX);
        playerPosition.y = Mathf.Clamp(playerPosition.y, _minY, _maxY);
        _componentTransform.position = playerPosition;

    }

    void Shoot()
    {
        Instantiate(prefabBullet, transform.position, transform.rotation);
        sfxManager.Play();
    }

    private void FixedUpdate()
    {
        _componentRigidbody2D.velocity = new Vector2(_x * _Xspeed, _y * _Yspeed);
    }
}
