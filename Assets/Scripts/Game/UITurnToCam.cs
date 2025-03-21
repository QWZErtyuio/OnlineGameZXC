using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITurnToCam : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Work();
    }
    private void Work()
    {
        transform.forward = _camera.transform.forward;
    }
}
