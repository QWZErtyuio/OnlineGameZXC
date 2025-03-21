using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour, IDamageable
{
   [SerializeField] private int _maxHealth = 100;
    private int _health;
    private int Health {  get { return _health; } set { _health = value; _healthBar.SetValue(value); } }

    private UIHealthBar _healthBar;// esli ti seks bomba, to ya saper, esli lybis shoy shoy, ya reziser
    private PhotonView _photonView;
    public void TakeDamage(int damage) //turip ip ip ip tutip ip tuuuriip tuturip ip ip tututututurip
    {
        _photonView.RPC("RemoteDamage", RpcTarget.All, damage);
        Health -= damage;//pisyni tayat v moem rtyyyy oeeeee
    }

    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        _healthBar = GetComponentInChildren<UIHealthBar>();
        _healthBar.SetMax(_maxHealth);
        Health = _maxHealth;
    }
    [PunRPC] 
    private void RemoteDamage(int damage)
    {
        Health -= damage;
    }

    void Update()
    {
        
    }
    
}
