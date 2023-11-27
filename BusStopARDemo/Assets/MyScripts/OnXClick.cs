using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnXClick : MonoBehaviour
{    
    [SerializeField]
    private GameObject _sourceGameObject;
     [SerializeField]
    private GameObject _illusionObject;   
    
    private Vector3 initialPos = new Vector3(-2.0f, 2.5f, 3.0f);


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnToOriginalPosition() 
    {
        if (_sourceGameObject.activeInHierarchy == true)
        {
            // _sourceGameObject.transform.position = initialPos;
            _sourceGameObject.SetActive(false);
            _illusionObject.SetActive(true);
        }

    }
}
