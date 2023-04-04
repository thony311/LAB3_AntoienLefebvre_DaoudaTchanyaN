using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PiegeRenard : MonoBehaviour
{
    // Attributs
    [SerializeField] private float _vitesse = 10;
    private RaycastHit Hit;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Bloque la rotation et bouge les renards
        transform.Rotate(0f,0f, 0f);
        transform.Translate(Vector3.forward * _vitesse * Time.deltaTime);
        // Lorsque qu'une collision se fait le renards rotationne sur le y en random
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out Hit, 1))
         {
            transform.Rotate(0f,Random.Range(135f, 225f),0f);
            
        }
    }

}
