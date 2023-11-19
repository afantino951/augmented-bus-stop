using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Input;
using Oculus.Interaction;
public class ScaleWithDistance : MonoBehaviour
{
    [SerializeField]
    private GameObject _sourceGameObject;

    [SerializeField, Interface(typeof(IOVRCameraRigRef))]
    private UnityEngine.Object _cameraRigRef;

    [SerializeField]
    private GameObjectActiveState _objectActiveState;


    private float distance;    

    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance(_sourceGameObject.transform.position, _cameraRigRef.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_objectActiveState.Active) 
        {
            distance = Vector3.Distance(_sourceGameObject.transform.position, _cameraRigRef.transform.position);
            
        }
    }
}
