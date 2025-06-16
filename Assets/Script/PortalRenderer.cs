using UnityEngine;

public class PortalRenderer : MonoBehaviour
{
    [Header("Portal Visual")]
    public Material portalMaterial;
    public Transform portalFrame;
    public Camera portalCamera;
    public RenderTexture portalTexture;
    
    [Header("Animation")]
    public float rotationSpeed = 50f;
    public bool animateRotation = true;
    
    void Start()
    {
        SetupPortalCamera();
    }
    
    void Update()
    {
        if (animateRotation && portalFrame != null)
        {
            portalFrame.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
    
    void SetupPortalCamera()
    {
        if (portalCamera != null && portalTexture != null)
        {
            portalCamera.targetTexture = portalTexture;
            if (portalMaterial != null)
                portalMaterial.mainTexture = portalTexture;
        }
    }
}