using System.Collections;
using UnityEngine;



[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour {

	public int xSize, ySize;

	//private Mesh mesh;
	private Vector3[] vertices;

	private void Awake ()
	{
        StartCoroutine(Generate());
	
	}


    private IEnumerator Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.05f);
        Mesh mesh = GetComponent<MeshFilter>().mesh = new Mesh();
        mesh.name = "Procedural Grid";
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x, y);               
            }
        }
        mesh.vertices = vertices;

        int[] triangles = new int[xSize * ySize * 6];
        for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++)
        {
            for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
                yield return wait;
                mesh.triangles = triangles;
            }    
        }
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        Vector2[] uv = new Vector2[vertices.Length];
        // Debug.Log(vertices.Length);
        Vector4[] tangents = new Vector4[vertices.Length];
        Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x, y);
                uv[i] = new Vector2((float)x / xSize, (float)y / ySize);
                tangents[i] = tangent;
            }
        }
       // mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.RecalculateNormals();
        mesh.tangents = tangents;
    }
    private void OnDrawGizmos()
    {
        
        if (vertices == null)
        {
            return;
        }
        Gizmos.color = Color.black;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
   
}