using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionPlayer : MonoBehaviour
{
    // Attributs
    [SerializeField] private float _vitesse = 1000;
    [SerializeField] private float _vitesseRotation = 10;
    private bool _finJeu = false;
    private Rigidbody _rb;
    private float _timeStart;
    private bool _debutJeu;

    
    private void Start()
    {
        // Cherche le rigid body du joueur et initialise le debut jeu a false
        _rb = GetComponent<Rigidbody>();
        _debutJeu= false;
    }


    private void FixedUpdate()
    {
        // Arrete les mouvements du joueurs si la fin su jeu est true
        if (!_finJeu)
            MouvementJoueur();
    }

    public void finDeJeu()
    {
        // Change le finJeu pour true
        _finJeu = true;
    }

    public float GetTimeStart()
    {
        // Retourne le temps
        return _timeStart;
    }


    private void MouvementJoueur()
    {
        // Permet de bouger le personnage
        if(_debutJeu == false && (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizaontal") > 0))
        {
            _timeStart = Time.time;
            _debutJeu = true;
            Debug.Log("c'est parti!" + Time.time);
        }
        float positionX = Input.GetAxis("Vertical");
        float positionZ = Input.GetAxis("Horizontal");
        if(positionX > 0)
        {
            //this.GetComponent<Rigidbody>().velocity = Vector3.forward * _vitesse;
            transform.Translate(Vector3.forward * _vitesse);
        }
        if(positionZ != 0)
        {
            transform.Rotate(0f, positionZ * _vitesseRotation, 0f);
        }
        
    }

}
