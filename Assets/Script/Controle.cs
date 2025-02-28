using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Controle : MonoBehaviour
{

    // variables de mouvement et contrôle
    [SerializeField] private float _vitessePromenade;
    [SerializeField] private float _boost;
    [SerializeField] private float _MuliplicateurA;
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
        _boost = 1;
        _MuliplicateurA = -1;
    }

    void OnPromener(InputValue directionBase)
    {
        Vector3 directionAvecVitesse = directionBase.Get<Vector2>() * _vitessePromenade * _boost;
        directionInput = new Vector3(0f,directionAvecVitesse.x , directionAvecVitesse.y);
        Debug.Log(directionInput);
    }

    void OnDash(InputValue dash)
    {
        Debug.Log("Dash");
        if(dash.isPressed)
        {
            _vitessePromenade = 2f;
            _boost = 2f;
        }
        else
        {
            _vitessePromenade = 1f;
            _boost = 1f;
        }
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
