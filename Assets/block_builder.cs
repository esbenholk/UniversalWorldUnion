using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_builder : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PrefabApartmentCelle;
    public Material EdgeMarker;

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

    public IEnumerator InstantiatePrefabInXDirection()
    {
        ApartmentCellesOnXAxis = new GameObject[amountInXAxis+1];
        ApartmentCellesOnZAxis = new GameObject[amountInZAxis+1];


        for (float alpha = 1f; alpha <= this.amountInXAxis ; alpha++)
        {
            GameObject goX = (GameObject)Instantiate(this.PrefabApartmentCelle, new Vector3(this.transform.position.x + (float) alpha * (float)this.PrefabApartmentCelle.GetComponent<Renderer>().bounds.size.x, 1, 0), Quaternion.identity, this.transform);
       
            ApartmentCellesOnXAxis[(int)alpha] = goX;

 
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
            int shouldInstantiate = Random.Range(0, 10);
            GameObject goZ = (GameObject)Instantiate(this.PrefabApartmentCelle, new Vector3(goX.transform.position.x, goX.transform.position.y, (float)beta * (float)this.PrefabApartmentCelle.GetComponent<Renderer>().bounds.size.z), Quaternion.identity, goX.transform);
            ApartmentCellesOnZAxis[(int)beta] = goZ;

            //if (index == amountInZAxis && shouldInstantiate >= 2)
            //{
            //    //goZ.GetComponent<Renderer>().material = EdgeMarker;
            //    Debug.Log("DESTROZS CELLE" + index + goZ);
            //    goZ.gameObject.SetActive(false);
            //    Destroy(goZ);

            //}


            //if (index == amountInZAxis)
            //{
            //    goZ.GetComponent<Renderer>().material = EdgeMarker;
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

            int shouldInstantiate = Random.Range(1, 3);

            GameObject goY = (GameObject)Instantiate(this.PrefabApartmentCelle, new Vector3(goX.transform.position.x, (float)zeta * (float)this.PrefabApartmentCelle.GetComponent<Renderer>().bounds.size.y, goX.transform.position.z), Quaternion.identity, goX.transform);
            ApartmentCellesOnYAxis[(int)zeta] = goY;

            if (index == amountInZAxis && shouldInstantiate > 1)
            {
                goY.GetComponent<Renderer>().material = EdgeMarker;
                Debug.Log("DESTROZS CELLE" + index + goY);
                goY.gameObject.SetActive(false);
                Destroy(goY);
            }



            yield return new WaitForSeconds(0.1f);

        }

    }
}
