using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Input;
using Oculus.Interaction;
using Meta.WitAi.Utilities;
public class ScaleWithDistance : MonoBehaviour
{
    [SerializeField]
    private GameObject _sourceGameObject;

    [SerializeField]
    private GameObject _cameraRigRef;

    [SerializeField]
    private GameObjectActiveState _objectActiveState;


    private float distance;    
    private float scaleFactor = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        distance = getDistance(_sourceGameObject, _cameraRigRef);
        Debug.Log("Distance: " + distance);
    }

    // Update is called once per frame
    void Update()
    {
        if (_objectActiveState.Active) 
        {
            distance = getDistance(_sourceGameObject, _cameraRigRef);
            Debug.Log(distance);

            if (distance < 1.0f) 
            {
                _sourceGameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            }
            // _sourceGameObject.transform.localScale *= scaleFactor;
            
        }
    }

    private static float getDistance(GameObject obj1, GameObject obj2) 
    {
        return Vector3.Distance(obj1.transform.position, obj2.transform.position);
    }
}
