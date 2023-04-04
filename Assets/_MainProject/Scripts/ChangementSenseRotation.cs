using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementSenseRotation : MonoBehaviour
{
    //Attributs
    [SerializeField] private List<GameObject> _listGameObject = new List<GameObject>();
    private List<ArbreTombant> _listeArbre = new List<ArbreTombant>();
    [SerializeField] private string _tag;
    // Start is called before the first frame update
    void Start()
    {
        //Ajouts des arbres dedans la list
        foreach(var arbre in _listGameObject)
        {
            _listeArbre.Add(arbre.GetComponent<ArbreTombant>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Lorsque le tag rentrez est égale au tag decidé il lancera changerSenseRotation
        if(other.gameObject.tag == _tag)
        {
            foreach(var arbre in _listeArbre)
            {
               arbre.ChangerSenseRotation();
            }
        }
    }
}
