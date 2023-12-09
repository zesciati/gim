using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    // Menghitung cherry yg ada
    private int cherries = 0;

    // mereferensi text legacy (Cherries Text)
    [SerializeField] private Text cherriesText;

    [SerializeField] private AudioSource collectionSoundEffect;

    // OnTrigger2D karena objek Cherry menggunakan Is Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        { 
            // audio collect
            collectionSoundEffect.Play();
            //Remove item from the game
            Destroy(collision.gameObject);
            cherries++;
            // Mengupdate int cherries = 0 menjadi berapa kali player mengenai cherry
            cherriesText.text = "Cherries: " + cherries;
        }
    }
}
