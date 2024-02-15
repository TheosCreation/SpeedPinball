
using Unity.Mathematics;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    public Texture2D map;
    public colorToPrefab[] colorMappings; 
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    // Update is called once per frame
    void GenerateLevel() { 
        for(int x = 0 ; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }
    void GenerateTile(int x, int y) { 
        Color pixColor = map.GetPixel(x, y);

        if (pixColor.a == 0) {
            return;
            //blank pixel
        }
        
        foreach (colorToPrefab colorMapping in colorMappings) {
            if (colorMapping.color.Equals(pixColor)) {
                Vector2 position = new Vector2(x, y);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }


    }
}
