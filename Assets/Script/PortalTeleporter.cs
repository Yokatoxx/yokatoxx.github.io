using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PortalTeleporter : MonoBehaviour
{
    [Header("Scene Settings")]
    public string targetSceneName;
    public string spawnPointTag = "SpawnPoint";
    
    [Header("Portal Effects")]
    public GameObject portalEffect;
    public AudioSource teleportSound;
    public float fadeTime = 1f;
    
    [Header("Trigger Settings")]
    public bool requiresInput = false;
    public KeyCode activationKey = KeyCode.E;
    
    private bool playerInTrigger = false;
    private bool isTeleporting = false;
    
    void Update()
    {
        if (playerInTrigger && !isTeleporting)
        {
            if (!requiresInput || Input.GetKeyDown(activationKey))
            {
                StartCoroutine(TeleportToScene());
            }
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.name.Contains("XR Origin"))
        {
            playerInTrigger = true;
            if (portalEffect != null)
                portalEffect.SetActive(true);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.name.Contains("XR Origin"))
        {
            playerInTrigger = false;
            if (portalEffect != null)
                portalEffect.SetActive(false);
        }
    }
    
    IEnumerator TeleportToScene()
    {
        isTeleporting = true;
        
        // Jouer le son de téléportation
        if (teleportSound != null)
            teleportSound.Play();
        
        // Effet de fade (optionnel)
        yield return StartCoroutine(FadeScreen());
        
        // Charger la nouvelle scène
        SceneManager.LoadScene(targetSceneName);
    }
    
    IEnumerator FadeScreen()
    {
        // Ici vous pouvez ajouter un effet de fade
        // Par exemple avec un Canvas UI ou un shader
        yield return new WaitForSeconds(fadeTime);
    }
}