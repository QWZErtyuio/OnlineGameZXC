using DG.Tweening;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _trailRenderer;
    [SerializeField] private GameObject _BulletPrefap;
    [SerializeField] private Transform _bulletOrigin;

    private Camera _camera;
    private PlayerInput _playerInput;

    private PhotonView _photonView;

    private bool _isAimimg;
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _photonView = GetComponent<PhotonView>();
    }
    private void OnEnable()
    {
        _playerInput.Enable();
    }private void OnDisable()
    {
        _playerInput.Disable();
    }
    void Start()
    {
        _camera = Camera.main;
        if (_photonView.IsMine)
        {
           _playerInput.PlayerKeyboardInput.Aim.started += OnAimChanged;
           _playerInput.PlayerKeyboardInput.Aim.canceled += OnAimChanged;
           _playerInput.PlayerKeyboardInput.AGONb.started += Shoot; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProstoAim();
    }
    private void OnAimChanged(InputAction.CallbackContext context)
    {
        _isAimimg = context.ReadValueAsButton();
        _trailRenderer.SetActive(_isAimimg);
    }
    private void ProstoAim()
    {
        if (_isAimimg)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 point = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);
                Vector3 direction = point - transform.position;
                _trailRenderer.transform.forward = direction;


            }

        }
    }
  private void Shoot(InputAction.CallbackContext context)
    {
        if (_isAimimg)
        {
           GameObject bullet = PhotonNetwork.Instantiate("Bullet", _bulletOrigin.position, _trailRenderer.transform.rotation);
            bullet.GetComponentInChildren<Collider>().enabled = true;
        }
    }
}
