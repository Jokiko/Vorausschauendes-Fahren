using UnityEngine;

public class ObjectSpawnTrigger : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform spawnPoint;
    public float initialRollingSpeed = 5f;

    private bool objectSpawned = false;
    private GameObject spawnedObject;
    private bool initialSpeedApplied = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!objectSpawned && other.CompareTag("Player"))
        {
            spawnedObject = Instantiate(objectPrefab, spawnPoint.position, Quaternion.Euler(270f, 270f, 90f));
            objectSpawned = true;
        }
    }

    private void Update()
    {
        if (objectSpawned && !initialSpeedApplied)
        {
            // Apply initial speed only once
            Rigidbody spawnedRigidbody = spawnedObject.GetComponent<Rigidbody>();
            if (spawnedRigidbody != null)
            {
                // Apply initial speed to the Rigidbody's velocity
                spawnedRigidbody.velocity = spawnedObject.transform.right * initialRollingSpeed;
                initialSpeedApplied = true;
            }
        }
    }
}
