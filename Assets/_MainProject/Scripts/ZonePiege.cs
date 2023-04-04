using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePiege : MonoBehaviour
{
    // attributs

    private bool _estActiver = false;
    [SerializeField] private float _intensiteForce;
    [SerializeField] private List<GameObject> _listePiege = new List<GameObject>();
    private List<Rigidbody> _listeRB = new List<Rigidbody>();

    private void Start()
    {
        // Rajoute les pièges dans la liste de pièges 
        foreach (var piege in _listePiege)
        {
            _listeRB.Add(piege.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Lorsque que le joueur passe la zone il actionne la graviter sur les pièges qui les fait tomber
        if (!_estActiver && other.gameObject.tag == "Player")
        {
            foreach (var rb in _listeRB)
            {
                rb.useGravity = true;
                rb.AddForce(Vector3.down * _intensiteForce);
            }
        }
    }
}
