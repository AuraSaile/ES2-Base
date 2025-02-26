using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Controle : MonoBehaviour
{

    // variables de mouvement et contrôle
    [SerializeField] private float _vitessePromenade;
    [SerializeField] private float _MultiplicateurA;
    [SerializeField] private float _MultiplicateurB;
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
        _MultiplicateurA = -1;
        _MultiplicateurB = -1;
    }

    void OnPromener(InputValue directionBase)
    {
        Vector3 directionAvecVitesse = directionBase.Get<Vector2>() * _vitessePromenade;
        directionInput = new Vector3(0f,directionAvecVitesse.x , directionAvecVitesse.y);
        Debug.Log(directionInput);
    }

    void FixedUpdate()
    {
        // calculer et appliquer la translation
        Vector3 mouvement = directionInput;
        _rb.AddRelativeForce(mouvement, ForceMode.VelocityChange);

        Vector3 vitesse = new Vector3(0f, 0f , _rb.velocity.z);
        Vector3 vitessePetite = new Vector3(0f, _rb.velocity.y, 0f);
        _animator.SetFloat("Vitesse", vitesse.z);
        _animator.SetFloat("Vitesse petite", vitessePetite.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
