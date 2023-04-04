using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllerRetourBateau: MonoBehaviour
{
    //Attributs
    [SerializeField] private float _vitesse = -0.2f;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        //Initialisation de la direction
        direction = new Vector3(_vitesse, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Mouvement du bateau
        transform.Translate(direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Changement du mouvement pour l'opposé en plus d'une rotation 180 degrée lorsque qu'il y a une collision pour faire une 
        _vitesse *= -1;
        transform.Rotate(0f, 180f, 0f);
        
    }

}
