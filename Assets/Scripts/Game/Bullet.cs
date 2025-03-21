using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 8.0f;
    private bool _isLaunched = false;
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward * _speed, ForceMode.Impulse);
        Destroy(gameObject, 8.0f / _speed);
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable) && _isLaunched)
        {
            damageable.TakeDamage(10);
            PhotonNetwork.Destroy(gameObject)
        }

        if (_isLaunched == false)
        {
            _isLaunched=true;
        }
    }
}
