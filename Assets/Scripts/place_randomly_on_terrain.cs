using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class place_randomly_on_terrain : MonoBehaviour
{
public GameObject prefab;
public Terrain terrain;
public float yOffset = 0.5f;
public float amount;

private float terrainWidth;
private float terrainLength;

private float xTerrainPos;
private float zTerrainPos;


void Start()
{
    //Get terrain size
    terrainWidth = terrain.terrainData.size.x;
    terrainLength = terrain.terrainData.size.z;

    //Get terrain position
    xTerrainPos = terrain.transform.position.x;
    zTerrainPos = terrain.transform.position.z;

    generateObjectOnTerrain();
}

void generateObjectOnTerrain()
{
     //Generate the Prefab on the generated position
    for(int i = 0; i < amount; i++)  // output:
    {		
        //Generate random x,z,y position on the terrain
        float randX = UnityEngine.Random.Range(xTerrainPos, xTerrainPos + terrainWidth);
        float randZ = UnityEngine.Random.Range(zTerrainPos, zTerrainPos + terrainLength);
        float yVal = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ));
        float rotZ = UnityEngine.Random.Range(0f, 360f);

        //Apply Offset if needed
    
        if ( yVal > -2) 
        {
            yVal = yVal + yOffset;
             GameObject objInstance = (GameObject)Instantiate(prefab, new Vector3(randX, yVal, randZ), Quaternion.Euler(90,0,rotZ));
        } 
    
    }	
}
}
