using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public float Size;
    public int Smoothness;
    public LineRenderer lineRenderer;

    void Awake() {
        if (lineRenderer == null) {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        // lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;    
    }
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.loop = true;
        Draw();
    }

    void Draw() {
        if (lineRenderer == null) { return; }
        lineRenderer.positionCount = Smoothness;
        float theta = (2f * Mathf.PI) / Smoothness;
        float angle = 0;
        for (int i=0; i<Smoothness; i++) {
            float x = Size * Mathf.Cos(angle);
            float y = Size * Mathf.Sin(angle);
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
            angle += theta;
        }
    }
}
