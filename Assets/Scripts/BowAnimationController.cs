using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAnimationController : MonoBehaviour
{
    private Animator animator;
    private bool isDrawing;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
            animator.SetBool("isDrawing", true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
            animator.SetBool("isDrawing", false);
        }
    }
}