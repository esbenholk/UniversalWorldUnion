
using UnityEngine;
using UnityEditor;
using System.IO;

// Usage: Attach to gameobject, assign target gameobject (from where the mesh is taken), Run, Press savekey
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class saveAsset : MonoBehaviour
{

    public KeyCode saveKey = KeyCode.F12;
    public string saveName;
    public Transform selectedGameObject;

    private void Awake()
    {
        selectedGameObject = this.transform;
        saveName = this.transform.name;
    }

    void Update()
    {
        if (Input.GetKeyDown(saveKey))
        {
            Debug.Log("presses save button");
            SaveAsset();
        }
    }

   
    static void CreatePrefab()
    {
        // Keep track of the currently selected GameObject(s)
        GameObject[] objectArray = Selection.gameObjects;

        // Loop through every GameObject in the array above
        foreach (GameObject gameObject in objectArray)
        {
            // Create folder Prefabs and set the path as within the Prefabs folder,
            // and name it as the GameObject's name with the .Prefab format
            if (!Directory.Exists("Assets/Prefabs"))
                AssetDatabase.CreateFolder("Assets", "Prefabs");
            string localPath = "Assets/Prefabs/" + gameObject.name + ".prefab";

            // Make sure the file name is unique, in case an existing Prefab has the same name.
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

            // Create the new Prefab and log whether Prefab was saved successfully.
            bool prefabSuccess;
            PrefabUtility.SaveAsPrefabAsset(gameObject, localPath, out prefabSuccess);
            if (prefabSuccess == true)
                Debug.Log("Prefab was saved successfully");
            else
                Debug.Log("Prefab failed to save" + prefabSuccess);
        }
    }

    void SaveAsset()
    {
        var mf = selectedGameObject.GetComponent<MeshFilter>();
        var savePath = "Assets/ApartmentBlock/" + saveName + ".asset";
        CreatePrefab();

        //MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        //CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        //int i = 0;
        //while (i < meshFilters.Length)
        //{
        //    combine[i].mesh = meshFilters[i].sharedMesh;
        //    combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
        //    meshFilters[i].gameObject.SetActive(false);

        //    i++;
        //}
        //transform.GetComponent<MeshFilter>().mesh = new Mesh();
        //transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        //transform.gameObject.SetActive(true);


        //if (mf)
        //{
        //    Debug.Log("Saved Mesh to:" + savePath);
        //    AssetDatabase.CreateAsset(mf.mesh, savePath);
        //}



    }
}
