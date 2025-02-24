using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Controle : MonoBehaviour
{

    // variables de mouvement et contrôle
    [SerializeField] private float _vitessePromenade;
    private Rigidbody _rb;
    private Vector3 directionInput;

    // variables de contrôle d'animation
    [SerializeField] private float _modifierAnimTranslation;
    private Animator _animator;
    private float _rotationVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void OnPromener(InputValue directionBase)
    {
        Vector3 directionAvecVitesse = directionBase.Get<Vector3>() * _vitessePromenade;
        directionInput = new Vector3(0f,directionAvecVitesse.z , directionAvecVitesse.y);
    }

    void FixedUpdate()
    {
        // calculer et appliquer la translation
        Vector3 mouvement = directionInput;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
