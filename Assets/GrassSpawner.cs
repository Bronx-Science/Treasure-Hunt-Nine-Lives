using UnityEngine;

public class GrassSpawner : MonoBehaviour
{
    public GameObject grassPrefab;
    public int numberOfGrassObjects = 1000;

    void Start()
    {
        Mesh mesh = grassPrefab.GetComponent<MeshFilter>().sharedMesh;
        Material material = grassPrefab.GetComponent<Renderer>().sharedMaterial;

        Matrix4x4[] matrices = new Matrix4x4[numberOfGrassObjects];
        for (int i = 0; i < numberOfGrassObjects; i++)
        {
            Vector3 position = new Vector3(Random.Range(0f, 10f), 0, Random.Range(0f, 10f)); // Set your desired position range
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0); // Random rotation

            matrices[i] = Matrix4x4.TRS(position, rotation, Vector3.one);
        }

        Graphics.DrawMeshInstanced(mesh, 0, material, matrices);
    }
}
