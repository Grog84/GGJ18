using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine.Tilemaps;

public class FloorTiles : Tile {

    [SerializeField]
    private Sprite[] floorSprite;

    [SerializeField]
    private Sprite preview;

    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
            {
                Vector3Int nPos = new Vector3Int(position.x + x, position.y + y, position.z);

                if (HasFloor(tilemap, nPos))
                {
                    tilemap.RefreshTile(nPos);
                }

            }
        }
    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        tileData.sprite = floorSprite[0];
        string composition = string.Empty;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {

                if (HasFloor(tilemap, new Vector3Int(position.x + x, position.y + y, position.z)))
                {
                    
                    composition += 'F'; // add an F to the string identifier
                    //Debug.Log("Yes F!");
                }
                else
                {
                    composition += 'E'; // adds an empty to the string composition
                }
            }
        }

        Debug.Log(composition);

        if (composition[1] == 'E' && composition[3] == 'E' && composition[5] == 'E' && composition[7] == 'E')
        {
            tileData.sprite = floorSprite[16];
        }

        else if (composition[1] == 'E' && composition[3] == 'E' && composition[5] == 'E' && composition[7] == 'F')
        {
            tileData.sprite = floorSprite[12];
        }

        else if (composition[1] == 'E' && composition[3] == 'E' && composition[5] == 'F' && composition[7] == 'E')
        {
            float rand = Random.value;

            if(rand <= 0.5)
                tileData.sprite = floorSprite[17];
            else
                tileData.sprite = floorSprite[18];
        }

        // 1- left, 3 - down, 5 - up, 7 - right

        else if (composition[1] == 'E' && composition[3] == 'F' && composition[5] == 'E' && composition[7] == 'E')
        {
            float rand = Random.value;

            if (rand <= 0.5)
                tileData.sprite = floorSprite[4];
            else
                tileData.sprite = floorSprite[5];
        }

        else if (composition[1] == 'F' && composition[3] == 'E' && composition[5] == 'E' && composition[7] == 'E')
        {
            float rand = Random.value;

            if (rand <= 0.5)
                tileData.sprite = floorSprite[10];
            else
                tileData.sprite = floorSprite[11];
        }

        else if (composition[1] == 'F' && composition[3] == 'F' && composition[5] == 'E' && composition[7] == 'E')
        {
            float rand = Random.value;

            if (rand <= 0.5)
                tileData.sprite = floorSprite[6];
            else
                tileData.sprite = floorSprite[7];
        }

        else if (composition[1] == 'F' && composition[3] == 'E' && composition[5] == 'F' && composition[7] == 'E')
        {
            float rand = Random.value;

            if (rand <= 0.5)
                tileData.sprite = floorSprite[17];
            else
                tileData.sprite = floorSprite[18];
        }

        else if (composition[1] == 'F' && composition[3] == 'E' && composition[5] == 'E' && composition[7] == 'F')
        {
            float rand = Random.value;

            if (rand <= 0.5)
                tileData.sprite = floorSprite[14];
            else
                tileData.sprite = floorSprite[15];
        }

        else if (composition[1] == 'F' && composition[3] == 'E' && composition[5] == 'E' && composition[7] == 'F')
        {
            float rand = Random.value;

            if (rand <= 0.5)
                tileData.sprite = floorSprite[14];
            else
                tileData.sprite = floorSprite[15];
        }

        else if (composition[1] == 'E' && composition[3] == 'F' && composition[5] == 'F' && composition[7] == 'E')
        {
            float rand = Random.value;

            if (rand <= 0.5)
                tileData.sprite = floorSprite[17];
            else
                tileData.sprite = floorSprite[18];
        }

        else if (composition[1] == 'E' && composition[3] == 'F' && composition[5] == 'E' && composition[7] == 'F')
        {
            float rand = Random.value;

            if (rand <= 0.5)
                tileData.sprite = floorSprite[6];
            else
                tileData.sprite = floorSprite[7];
        }

        else if (composition[1] == 'E' && composition[3] == 'E' && composition[5] == 'F' && composition[7] == 'F')
        {
            float rand = Random.value;

            if (rand <= 0.5)
                tileData.sprite = floorSprite[6];
            else
                tileData.sprite = floorSprite[7];
        }

        else if (composition[1] == 'F' && composition[3] == 'F' && composition[5] == 'F' && composition[7] == 'E')
        {
            float rand = Random.value;

            if (rand <= 0.5)
                tileData.sprite = floorSprite[6];
            else
                tileData.sprite = floorSprite[7];
        }

        else if (composition[1] == 'F' && composition[3] == 'E' && composition[5] == 'F' && composition[7] == 'F')
        {
            float rand = Random.value;

            if (rand <= 0.5)
                tileData.sprite = floorSprite[6];
            else
                tileData.sprite = floorSprite[7];
        }

        else if (composition[1] == 'F' && composition[3] == 'F' && composition[5] == 'E' && composition[7] == 'F')
        {
            float rand = Random.value;

            if (rand <= 0.5)
                tileData.sprite = floorSprite[6];
            else
                tileData.sprite = floorSprite[7];
        }

        else if (composition[1] == 'F' && composition[3] == 'F' && composition[5] == 'F' && composition[7] == 'F')
        {
            float rand = Random.value;

            if (rand <= 0.5)
                tileData.sprite = floorSprite[6];
            else
                tileData.sprite = floorSprite[7];
        }
    }

    private bool HasFloor(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }


#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/Floor")]
    public static void CreateFloorTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Floortile", "New Floortile", "asset", "Save Floortile", "Assets");
        if (path == "")
        {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<FloorTiles>(), path);
        
    }
#endif
}
