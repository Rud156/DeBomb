using UnityEngine;

namespace ComBlitz.Enemy.Base
{
    public class SpawnOrbOnDestroy : MonoBehaviour
    {
        public GameObject orbPrefab;
        public float sphereRadius;
        public int minSpawnCount;
        public int maxSpawnCount;

        private void OnDestroy()
        {
            Vector3 position = transform.position;
            int randomNumber = Random.Range(0, 1000);
            int randomValue = randomNumber % maxSpawnCount + minSpawnCount;

            for (int i = 0; i < randomValue; i++)
            {
                Vector3 randomPointInSphere = Random.insideUnitSphere * sphereRadius;
                Instantiate(orbPrefab, randomPointInSphere, Quaternion.identity);
            }
        }
    }
}