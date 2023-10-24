using UnityEngine;

public class GrassRenderer : MonoBehaviour
{
    public Material grassMaterial;
    public int numberOfGrassObjects = 100;

    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        for (int i = 0; i < numberOfGrassObjects; i++)
        {
            Vector3 randomPoint = GetRandomPointOnMesh(mesh);
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0); // Random rotation

            GameObject grassObject = new GameObject("Grass");
            grassObject.transform.position = randomPoint;
            grassObject.transform.rotation = rotation;

            MeshRenderer renderer = grassObject.AddComponent<MeshRenderer>();
            MeshFilter filter = grassObject.AddComponent<MeshFilter>();

            filter.mesh = CreateQuadMesh();
            renderer.material = grassMaterial;
        }
    }
    Vector3 GetRandomPointOnMesh(Mesh mesh)
    {
        Vector3[] vertices = mesh.vertices;
        int randomVertexIndex = Random.Range(0, vertices.Length);
        Vector3 randomVertex = transform.TransformPoint(vertices[randomVertexIndex]);

        return randomVertex;
    }
    Mesh CreateQuadMesh()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(-0.5f, 0, -0.5f),
            new Vector3(0.5f, 0, -0.5f),
            new Vector3(0.5f, 0, 0.5f),
            new Vector3(-0.5f, 0, 0.5f)
        };

        int[] triangles = new int[6] { 0, 2, 1, 0, 3, 2 };

        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1)
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        return mesh;
    }
}