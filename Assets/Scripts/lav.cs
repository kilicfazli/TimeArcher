using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lav : MonoBehaviour
{
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("rakip"))
        {
            _audio.Play();
            Destroy(other.gameObject);
        }
    }
}
