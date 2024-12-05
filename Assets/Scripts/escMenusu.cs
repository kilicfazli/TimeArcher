using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    // Bu deðiþken, kontrol etmek istediðin GameObject'i referans alacak.
    public GameObject targetObject;

    void Update()
    {
        // ESC tuþuna basýldýðýný kontrol et
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // targetObject'in aktiflik durumunu tersine çevir (aktifse pasif, pasifse aktif yap)
            if (targetObject != null)
            {
                targetObject.SetActive(!targetObject.activeSelf);
            }
        }
    }
}