using UnityEngine;
using UnityEngine.XR;

public class SceneSpawnManager : MonoBehaviour
{
    [Header("Spawn Settings")]
    public Transform defaultSpawnPoint;
    public string spawnPointTag = "SpawnPoint";
    
    void Start()
    {
        PositionPlayer();
    }
    
    void PositionPlayer()
    {
        GameObject xrOrigin = GameObject.FindWithTag("Player");
        if (xrOrigin == null)
            xrOrigin = FindObjectOfType<Camera>()?.transform.root.gameObject;
        
        if (xrOrigin != null)
        {
            GameObject spawnPoint = GameObject.FindWithTag(spawnPointTag);
            Transform targetPosition = spawnPoint ? spawnPoint.transform : defaultSpawnPoint;
            
            if (targetPosition != null)
            {
                xrOrigin.transform.position = targetPosition.position;
                xrOrigin.transform.rotation = targetPosition.rotation;
            }
        }
    }
}