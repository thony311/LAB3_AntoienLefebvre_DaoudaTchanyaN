using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Le but de se gestion collision est pour les skinned Mesh Renderer à la place des Mesh Renderer normal
public class GestionCollisionSkinned : MonoBehaviour
{
    // Attributs 
    private GestionJeu _gestionJeu;
    private bool _toucher;
    private float _timeToChange = 4f;
    private float _timeSinceChange = 0f;
    [SerializeField] private Material _couleur;
    [SerializeField] private Material _couleurRouge;
    // Start is called before the first frame update
    void Start()
    {
        // Va chercher le gestion jeu
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _toucher = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Après un nombre de temps déterminé l'objet va revenir de ca couleur original
        _timeSinceChange += Time.deltaTime;
        if (_timeSinceChange >= _timeToChange && _toucher == true)
        {
            gameObject.GetComponent<SkinnedMeshRenderer>().material = _couleur;
            _toucher = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Lorsque qu'il y a une collision avec le joueur, l'objet va devenir rouge
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Touché!!!!");
            if (_toucher == false)
            {
                _toucher = true;
                gameObject.GetComponent<SkinnedMeshRenderer>().material = _couleurRouge;
                _gestionJeu.AugmenterPointage();
                _timeSinceChange = 0f;

            }
        }
    }
}
