using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleFactory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _rectangle;
    void Start()
    {
        MakeRectangles();
    }

    void MakeRectangles() 
    { 
        for(int i = 0; i < 2; i++) 
        { 
            for(int j = 0; j < 8; j++) 
            {
                Instantiate(_rectangle, new Vector3((j - 3f), i+1, 0), Quaternion.identity);
            }
        }
    }
}
