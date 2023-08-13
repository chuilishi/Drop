using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CreateMesh : MonoBehaviour
{
    public Vector2 pos1;
    public Vector2 pos2;
    Mesh mesh;
    private void OnEnable() {
        Debug.Log("Enable!");
        mesh = new Mesh();
        Vector3 [] vertices = new Vector3[]{
            pos1,
            new Vector2(pos1.x,pos2.y),
            pos2,
            new Vector2(pos2.x,pos1.y)
        };
        int[]triangles = new int[]{
            0,3,2,
            2,1,0
        };
        Vector2[]uv = new Vector2[]{
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,1),
            new Vector2(1,1),
        };
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
