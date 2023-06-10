using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Water : MonoBehaviour
{
    Vector3[] vertices;
    Mesh mesh;
    int[] triangles;
    Vector2[] uvs;
    

    public int xSize = 256;
    public int zSize = 256;

    public float elapsedTime = 0f;
    public float perlinNoise = 0f;
    public float multiplier = 3f;


    void Start(){
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateSurface();
        
    }


    private void Update(){
        getMesh();
        LeftToRightSine(Time.timeSinceLevelLoad);

        elapsedTime = Time.timeSinceLevelLoad;

        perlinNoise = Mathf.PerlinNoise(elapsedTime, 0);



        transform.position = new Vector3(
            transform.position.x,
            perlinNoise * multiplier,
            transform.position.z);


    }

    void CreateSurface(){
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for(int i = 0, z = 0; z <= zSize; z++){
            for(int x = 0; x <= xSize; x++){

                float y = Mathf.PerlinNoise(x * .1f, z * .1f) * 5f;
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

    void LeftToRightSine(float time)
    {
        for(int i = 0; i < vertices.Length; i++){
            Vector3 vertex = vertices[i];
            vertex.y = Mathf.Sin(time+vertex.x);
            vertices[i] = vertex;
        }
    }

    void getMesh(){
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

    }
}
