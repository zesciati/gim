using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // mereference atribut Transform di objek Player
    [SerializeField] private Transform player;
 
    private void Update()
    {
        //Mengatur kamera utk fokus ke player di setiap frame
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        
    }
}
