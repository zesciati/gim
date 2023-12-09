using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
   
    private void Update()
    {
        // Rotasi Roda gergaji(Saw)
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
