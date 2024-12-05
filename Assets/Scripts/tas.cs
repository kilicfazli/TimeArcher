using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tas : MonoBehaviour
{
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("rakip"))
        {
            _audio.Play();
            Destroy(other.gameObject);
        }
    }
}
