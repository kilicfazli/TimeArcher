using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour
{
    public GameObject[] arrowPrefabs; 
    [SerializeField] Transform spawnPoint;
    public Transform spriteTransform; 
    [SerializeField] LineRenderer linerenderer; 

    [SerializeField] float launchForce = 1.5f;
    [SerializeField] float trajectoryTimeStep = 0.1f;
    [SerializeField] int trajectoryStepCount = 15;
    private AudioSource _audio;
    private int currentArrowIndex = 0;
    private int remainingArrows;

    Vector2 velocity, startMousePos, currentMousePos;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        remainingArrows = arrowPrefabs.Length+1;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SwitchArrow();
        }

        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _audio.Play();
        }

        if (Input.GetMouseButton(0))
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            velocity = (startMousePos - currentMousePos) * launchForce;

            DrawTrajectory();
        }

        if (Input.GetMouseButtonUp(0) && remainingArrows > 0)
        {
            FireProjectile();
            remainingArrows--;
        }

        if (linerenderer.positionCount >= 2)
        {
            // Line Renderer'ýn ilk ve son noktasýný al
            Vector3 startPoint = linerenderer.GetPosition(0);
            Vector3 endPoint = linerenderer.GetPosition(linerenderer.positionCount - 1);

            // Yön vektörünü hesapla
            Vector3 direction = endPoint - startPoint;

            // Açýyý hesapla
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Spritein rotasyonunu ayarla
            spriteTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    void SwitchArrow()
    {
        currentArrowIndex = (currentArrowIndex + 1) % arrowPrefabs.Length; // Ok prefab'larý arasýnda geçiþ
        Debug.Log("Switched to arrow: " + currentArrowIndex);
    }

    void DrawTrajectory()
    {
        Vector3[] positions = new Vector3[trajectoryStepCount];
        for (int i = 0; i < trajectoryStepCount; i++)
        {
            float t = i * trajectoryTimeStep;
            Vector3 pos = (Vector2)spawnPoint.position + velocity * t + 0.5f * Physics2D.gravity * t * t;

            positions[i] = pos;
        }
        linerenderer.positionCount = trajectoryStepCount;
        linerenderer.SetPositions(positions);
    }

    void FireProjectile()
    {
        // Seçili ok prefab'ýný instantiate et
        GameObject arrow = Instantiate(arrowPrefabs[currentArrowIndex], spawnPoint.position, Quaternion.identity);

        // Okun Rigidbody2D bileþenini al ve hýzýný ayarla
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
    }
}