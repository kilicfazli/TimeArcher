using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darbeliOk : MonoBehaviour
{
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("engel"))
        {
            Destroy(other.gameObject);     
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("rakip"))
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag ("tas") || other.gameObject.CompareTag("zemin"))
        {
            Destroy(gameObject);
        }
    }
}
