using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSwitcher : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string[] texts;
    private int currentIndex = 0;

    void Start()
    {
        if (texts.Length > 0)
        {
            textMeshPro.text = texts[currentIndex]; // Ýlk metni seç
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Sað týk (mouse button 1)
        {
            SwitchText();
        }
    }

    void SwitchText()
    {
        currentIndex = (currentIndex + 1) % texts.Length;
        textMeshPro.text = texts[currentIndex];
    }
}