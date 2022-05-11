using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialChanger : MonoBehaviour
{
    // Start is called before the first frame update

    public Material OldMaterial;
    public Material NewMaterial;


    void Start()
    {
        int index = 0; 
        foreach (Transform child in transform)
        {

            Debug.Log(child + ""+ index);
            index++;

            if (child.GetComponent<MeshRenderer>().sharedMaterial == OldMaterial || child.GetComponent<MeshRenderer>().sharedMaterial == NewMaterial )
            {
                Debug.Log("has material");
                child.GetComponent<MeshRenderer>().material = NewMaterial;

                if (child.childCount > 0)
                {
                    Debug.Log("has child");

                    foreach (Transform subChild in child)
                    {
                        if (subChild.GetComponent<MeshRenderer>().sharedMaterial == OldMaterial || subChild.GetComponent<MeshRenderer>().sharedMaterial == NewMaterial)
                        {
                            Debug.Log("has material");
                            subChild.GetComponent<MeshRenderer>().material = NewMaterial;

                            if (subChild.childCount > 0)
                            {
                                Debug.Log("has subchild");

                                foreach (Transform subsubChild in subChild)
                                {
                                    if (subsubChild.GetComponent<MeshRenderer>().sharedMaterial == OldMaterial || subsubChild.GetComponent<MeshRenderer>().sharedMaterial == NewMaterial)
                                    {
                                        Debug.Log("has material");
                                        subsubChild.GetComponent<MeshRenderer>().material = NewMaterial;



                                        if (subsubChild.childCount > 0)
                                        {
                                            Debug.Log("has subchild");

                                            foreach (Transform subsubsubChild in subsubChild)
                                            {
                                                if (subsubsubChild.GetComponent<MeshRenderer>().sharedMaterial == OldMaterial || subsubsubChild.GetComponent<MeshRenderer>().sharedMaterial == NewMaterial)
                                                {
                                                    Debug.Log("has material");
                                                    subsubsubChild.GetComponent<MeshRenderer>().material = NewMaterial;


                                                }
                                            }
                                        }


                                    }
                                }
                            }


                        }
                    }
                }
            }
        }

    }


}
