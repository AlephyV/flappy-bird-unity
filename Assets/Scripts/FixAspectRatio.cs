using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FixAspectRatio : MonoBehaviour
{
    // 9:16 (retrato)
    public float targetAspect = 9f / 16f;
    Camera cam;
    int lastW, lastH;

    void Awake()
    {
        cam = GetComponent<Camera>();
        Apply();
    }

    void Update()
    {
        if (Screen.width != lastW || Screen.height != lastH)
            Apply();
    }

    void Apply()
    {
        lastW = Screen.width;
        lastH = Screen.height;

        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1f)
        {
            // barras em cima/baixo (letterbox)
            cam.rect = new Rect(0f, (1f - scaleHeight) * 0.5f, 1f, scaleHeight);
        }
        else
        {
            // barras nas laterais (pillarbox)
            float scaleWidth = 1f / scaleHeight;
            cam.rect = new Rect((1f - scaleWidth) * 0.5f, 0f, scaleWidth, 1f);
        }
    }
}
