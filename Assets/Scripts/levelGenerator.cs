
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    public Texture2D map;
    public colorToPrefab[] colorMappings;
    public GameObject Player;
    public Texture2D[] levels;
    int currentLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        map = levels[currentLevel];
        GenerateLevel();
    }
     void Update()
    {
        if (Player.GetComponent<PlayerMovement>().g_win&& currentLevel< levels.Length) {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            Player.transform.position = new Vector3(12, 12, 0);
            currentLevel++;
            map = levels[currentLevel];
            GenerateLevel();
            Player.GetComponent<PlayerMovement>().g_win = false;
        }
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
                var inst = Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
                if (colorMapping.prefab.CompareTag("Enemy")) {
                    inst.GetComponent<EnemyAI>().m_target = Player;
                }
            }
        }


    }
}
