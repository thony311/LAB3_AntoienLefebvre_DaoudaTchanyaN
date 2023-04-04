using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Attribut
    [SerializeField] private float _vitesseRotationY = 0.5f;

    void Update()
    {
        // Fait une rotation sur l'axe des Y
        transform.Rotate(0f, _vitesseRotationY, 0f);
    }
}
