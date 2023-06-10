using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Surface : MonoBehaviour
{
    Vector3[] vertices;
    Mesh mesh;
    int[] triangles;
    Vector2[] uvs;

    public float MeshHeightmultiplier = 10f;
    

    public int xSize = 256;
    public int zSize = 256;

    void Start(){
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateSurface();
        
    }


    private void Update(){
        getMesh();
    }

    void CreateSurface(){
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for(int i = 0, z = 0; z <= zSize; z++){
            for(int x = 0; x <= xSize; x++){

                float y = Mathf.PerlinNoise(x * .1f, z * .1f) * MeshHeightmultiplier;
                vertices[i] = new Vector3(x, y, z);

                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tri = 0;

        for(int z = 0; z < zSize; z++){
            for(int x = 0; x < xSize; x++){
                

                triangles[tri + 0] = vert + 0;
                triangles[tri + 1] = vert + xSize + 1;
                triangles[tri + 2] = vert + 1;
                triangles[tri + 3] = vert + 1;
                triangles[tri + 4] = vert + xSize + 1;
                triangles[tri + 5] = vert + xSize + 2;

                vert++;
                tri += 6;

            }
        }

        uvs = new Vector2[vertices.Length];

        for(int i = 0, z = 0; z <= zSize; z++){
            for(int x = 0; x <= xSize; x++){

                uvs[i] = new Vector2((float) x / xSize, (float) z / zSize);
                i++;
            }
        }
        
    }

    void getMesh(){
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

    }

    

}
