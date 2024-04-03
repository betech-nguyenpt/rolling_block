using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public TextAsset map;
    public Material groundTexture;
    // Start is called before the first frame update
    void Start()
    {
        LoadMap();
        // Camera
        // -4.5, 4.56, 4.23
        // 35, 90, 0
        // 1, 1, 1
        // =======
        // 4.09 3.32 -4.45
        // 35 0 0
        // 1 1 1
        // =======
        // Block
        // 2, 1.5, 7
        // 0, 0, 0
        // 1, 2, 1
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadMap()
    {
        // Get map content
        string mapContent = map.text;
        Debug.Log(mapContent);
        // Get list lines
        var lines = mapContent.Split('\n');
        var col = 0;
        // Loop through all lines
        foreach (var line in lines)
        {
            // Loop through each character
            for (int row = 0; row < line.Length; row++)
            {
                switch (line[row])
                {
                    case '1':   // Create Ground
                        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        ground.transform.localScale = new Vector3(1.0f, 0.2f, 1.0f);
                        ground.transform.position = new Vector3(col, 0.0f, row);
                        var rendererGround = ground.GetComponent<Renderer>();
                        rendererGround.material.mainTexture = groundTexture.mainTexture;
                        break;
                    case '2':   // Create Start point
                        GameObject groundStart = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        groundStart.transform.localScale = new Vector3(1.0f, 0.2f, 1.0f);
                        groundStart.transform.position = new Vector3(col, 0.0f, row);
                        //GameObject block1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        //block1.transform.position = new Vector3(row, 0.6f, col);
                        //GameObject block2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        //block2.transform.position = new Vector3(row, 1.6f, col);
                        break;
                    case '3':   // Create End point
                        Debug.Log(row);
                        Debug.Log(col);
                        break;
                    default:
                        break;
                }
            }
            col++;
        }
    }
}
