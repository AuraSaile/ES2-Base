using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controle : MonoBehaviour
{

    [SerializeField] private float _vitesse;
    private Rigidbody _rb;
    private Vector3 directionInput;

    [SerializeField] private float _modifierAnimation;
    private Animator _animator;
    private float _rotationVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAvancerReculer(InputValue directionBase) 
    {
        Debug.Log("Yo");
        Vector2 directionAvecVitesse = directionBase.Get<Vector2>() * _vitesse;
        directionInput = new Vector3(0f, directionAvecVitesse.x, directionAvecVitesse.y);
    }

    private void FixedUpdate()
    {
        Vector3 mouvement = directionInput;

        _rb.AddForce(mouvement, ForceMode.VelocityChange);

        Vector3 vitesseSurPlane = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
    }
}
