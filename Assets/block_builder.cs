using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_builder : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PrefabApartmentCelle;
    private GameObject[] ApartmentCellesOnXAxis;
    private GameObject[] ApartmentCellesOnZAxis;
    private GameObject[] ApartmentCellesOnYAxis;

    public int amountInXAxis;
    public int amountInZAxis;
    public int amountInYAxis;


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
        Debug.Log("starts couroutine");
        ApartmentCellesOnXAxis = new GameObject[amountInXAxis+1];
        ApartmentCellesOnZAxis = new GameObject[amountInZAxis+1];
        ApartmentCellesOnYAxis = new GameObject[amountInYAxis+1];

        for (float alpha = 1f; alpha <= this.amountInXAxis ; alpha++)
        {
            GameObject goX = (GameObject)Instantiate(this.PrefabApartmentCelle, new Vector3((float) alpha * (float)this.PrefabApartmentCelle.GetComponent<Renderer>().bounds.size.x, 1, 0), Quaternion.identity, this.transform);
            //go.transform.localScale = new Vec
            Debug.Log("ALPHA:" + alpha);
            ApartmentCellesOnXAxis[(int)alpha] = goX;

            //for (float beta = 1f; beta <= this.amountInXAxis; beta++)
            //{

            //    GameObject goZ = (GameObject)Instantiate(this.PrefabApartmentCelle, new Vector3(goX.transform.position.x, goX.transform.position.y, (float)beta * (float)this.PrefabApartmentCelle.GetComponent<Renderer>().bounds.size.z), Quaternion.identity, goX.transform);
            //    ApartmentCellesOnZAxis[(int)beta] = goZ;
            //    Debug.Log("BETA:" + beta);
            //    InstantiatePrefabInZDirection(goX);



            //}
            StartCoroutine(InstantiatePrefabInZDirection(goX));
            



            yield return new WaitForSeconds(1f);

        }

    }


    public IEnumerator InstantiatePrefabInZDirection(GameObject goX)
    {

        ApartmentCellesOnZAxis = new GameObject[amountInZAxis + 1];


        for (float beta = 1f; beta <= this.amountInXAxis; beta++)
        {

            GameObject goZ = (GameObject)Instantiate(this.PrefabApartmentCelle, new Vector3(goX.transform.position.x, goX.transform.position.y, (float)beta * (float)this.PrefabApartmentCelle.GetComponent<Renderer>().bounds.size.z), Quaternion.identity, goX.transform);
            ApartmentCellesOnZAxis[(int)beta] = goZ;
            Debug.Log("BETA:" + beta);
            yield return new WaitForSeconds(1f);

        }

    }
}
