using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject selectedObject;




    void Update()
    {
        bool leftClickPressed = Input.GetButtonDown("Fire1");
        bool rightClickPressed = Input.GetButtonDown("Fire2");
        bool gPressed = Input.GetKeyDown(KeyCode.G);

        if (leftClickPressed | rightClickPressed | gPressed)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);


            if (Physics.Raycast(ray, out hit))
            {
                if (leftClickPressed)
                {
                    Destroy(hit.transform.gameObject);
                }   

                else if (rightClickPressed)
                {
                    Vector3 blockSpawnPoint = hit.transform.position;
                    blockSpawnPoint += hit.normal;

                    Instantiate(selectedObject, blockSpawnPoint, Quaternion.identity);
                }

                else if (gPressed)
                {
                    selectedObject = hit.transform.gameObject;
                }
            }
        }
    }
}
