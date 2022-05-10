using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_builder : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] PrefabApartmentCelles;

    public bool shouldRotate;
    private int[] rotations = new int[] { 90, 0, 180, 270 };

    private GameObject[] ApartmentCellesOnXAxis;
    private GameObject[] ApartmentCellesOnZAxis;
    private GameObject[] ApartmentCellesOnYAxis;

    public int amountInXAxis;
    public int amountInZAxis;
    public int amountInYAxisMin;
    public int amountInYAxisMax;


    void Start()
    {
        StartCoroutine(InstantiatePrefabInXDirection());
    }

    // Update is called once per frame
    void Update()
    {

    }


    public GameObject getRandomItem()
    {
        return PrefabApartmentCelles[Random.Range(0, PrefabApartmentCelles.Length)];
    }
    public IEnumerator InstantiatePrefabInXDirection()
    {
        ApartmentCellesOnXAxis = new GameObject[amountInXAxis+1];
        ApartmentCellesOnZAxis = new GameObject[amountInZAxis+1];


        for (float alpha = 1f; alpha <= this.amountInXAxis ; alpha++)
        {
            GameObject prefab = this.getRandomItem();
            GameObject goX = (GameObject)Instantiate(prefab, new Vector3(this.transform.position.x + (float) alpha * (float)prefab.GetComponent<Renderer>().bounds.size.x, 1, 0), Quaternion.identity, this.transform);
       
            ApartmentCellesOnXAxis[(int)alpha] = goX;

            //if (this.shouldRotate)
            //{
            //    int index = Random.Range(0, rotations.Length);
            //    int selectedRotation = rotations[index];
            //    goX.transform.Rotate(0, 0, selectedRotation);
            //}


            StartCoroutine(InstantiatePrefabInZDirection(goX, alpha));
            StartCoroutine(InstantiatePrefabInYDirection(goX, alpha));




            yield return new WaitForSeconds(1f);

        }

    }


    public IEnumerator InstantiatePrefabInZDirection(GameObject goX, float index)
    {

        ApartmentCellesOnZAxis = new GameObject[amountInZAxis];


        for (float beta = 1f; beta <= this.amountInZAxis-1; beta++)
        {
            GameObject prefab = this.getRandomItem();
            GameObject goZ = (GameObject)Instantiate(prefab, new Vector3(goX.transform.position.x, goX.transform.position.y, (float)beta * (float)prefab.GetComponent<Renderer>().bounds.size.z), Quaternion.identity, goX.transform);

            ApartmentCellesOnZAxis[(int)beta] = goZ;

            //if (this.shouldRotate)
            //{
            //    int index0 = Random.Range(0, rotations.Length);
            //    int selectedRotation = rotations[index0];
            //    goZ.transform.Rotate(0, 0, selectedRotation);
            //}

            StartCoroutine(InstantiatePrefabInYDirection(goZ, beta));

            yield return new WaitForSeconds(0.1f);


        }

    }


    public IEnumerator InstantiatePrefabInYDirection(GameObject goX, float index)
    {

       
        int height = Random.Range(this.amountInYAxisMin, this.amountInYAxisMax);
     
        ApartmentCellesOnYAxis = new GameObject[height+1];

        for (float zeta = 1f; zeta <= height; zeta++)
        {
            GameObject prefab = this.getRandomItem();
            int shouldInstantiate = Random.Range(1, 3);

            GameObject goY = (GameObject)Instantiate(prefab, new Vector3(goX.transform.position.x, (float)zeta * (float)prefab.GetComponent<Renderer>().bounds.size.y + goX.transform.position.y, goX.transform.position.z), Quaternion.identity, goX.transform);
            ApartmentCellesOnYAxis[(int)zeta] = goY;

            if (index == amountInZAxis && shouldInstantiate > 1)
            {
                goY.gameObject.SetActive(false);
                Destroy(goY);
            }

            if (this.shouldRotate)
            {
                int index0 = Random.Range(0, rotations.Length);
                int selectedRotation = rotations[index0];
                goY.transform.Rotate(0,  selectedRotation, 0);
            }





            yield return new WaitForSeconds(0.1f);

        }

    }
}
