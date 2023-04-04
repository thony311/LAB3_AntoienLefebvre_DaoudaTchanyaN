using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    // Attributs
    private GestionJeu _gestionJeu;
    private bool _toucher;
    private float _timeToChange =4f; 
    private float _timeSinceChange = 0f;
    [SerializeField] private Material _couleur;

    private void Start()
    {
        // Va chercher le gestion jeu
        _gestionJeu = FindObjectOfType<GestionJeu>();
        // Initialise _toucher à faux
        _toucher = false;
        
    }

    private void Update()
    {
        // Ramene la couleur à la couleur de base après un nombre de seconde déterminer
        _timeSinceChange += Time.deltaTime;
        if(_timeSinceChange >= _timeToChange && _toucher == true)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = _couleur.color;
            _toucher = false;
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Lorsque qu'il rentre en collision avec le player/joueur, il va devenir rouge et augementer le pointage
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Touché!!!!");
            if (!_toucher)
            {
                _toucher = true;
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                _gestionJeu.AugmenterPointage();
                _timeSinceChange = 0f;
            }
        }
    }
}
