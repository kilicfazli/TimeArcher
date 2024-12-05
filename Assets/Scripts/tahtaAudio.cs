using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tahtaAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("engel") || other.gameObject.CompareTag("tas") ||
            other.gameObject.CompareTag("darbeliOk") || other.gameObject.CompareTag("kirilmazOk") || other.gameObject.CompareTag("engel"))
        {
            audioSource.Play();
        }
    }
}
