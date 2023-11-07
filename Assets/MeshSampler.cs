using UnityEngine;

public class MeshSampler : MonoBehaviour
{
    public GameObject grassPrefab;
    public int numberOfGrassPrefabs = 1000;

    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        for (int i = 0; i < numberOfGrassPrefabs; i++)
        {
            // Sample a random point on the mesh
            Vector3 randomPoint = mesh.vertices[Random.Range(0, mesh.vertices.Length)];

            // Instantiate grass prefab at the sampled point
            Instantiate(grassPrefab, transform.TransformPoint(randomPoint), Quaternion.identity);
        }
    }
}