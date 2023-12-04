using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Input;
using Oculus.Interaction;
using Meta.WitAi.Utilities;
using Unity.VisualScripting;
public class ScaleWithDistance : MonoBehaviour
{
    [SerializeField]
    private GameObject _sourceGameObject;

    [SerializeField]
    private GameObject _cameraRigRef;

    [SerializeField, Interface(typeof(IActiveState))]
    private UnityEngine.Object _activeState;
    private IActiveState ActiveState { get; set; }

    [SerializeField]
    private float _scaleFactor = 0.01f;
    
    [SerializeField]
    private float _distanceThreshold = 0.1f;


    private float distance;    
    private float prevDistance;

    private Vector3 originalScale = new Vector3();
    private bool wasActive;
    private bool zeroed = false;

    // Start is called before the first frame update
    void Start()
    {
        ActiveState = _activeState as IActiveState;
        originalScale = _sourceGameObject.transform.localScale;
        distance = getDistance(_sourceGameObject, _cameraRigRef);
        Debug.Log("Distance: " + distance);
    }

    // Update is called once per frame
    // void Update()
    // {
        // private bool isActive = ActiveState.Active;
        // if (isActive && !wasActive) 
        // {
        //     distance = getDistance(_sourceGameObject, _cameraRigRef);

        //     if (distance < _distanceThreshold) 
        //     {
        //         _sourceGameObject.transform.localScale = new Vector3(0.5f, 0.25f, 0.5f);
        //     }
            
        // }
        // else {
        //     prevDistance = getDistance(_sourceGameObject, _cameraRigRef);
        // }
    // }


    protected virtual void Update()
    {
        bool isActive = ActiveState.Active;
        // if (_lastActiveValue != isActive)
        // {
        //     SetMaterialColor(isActive ? _activeColor : _normalColor);
        //     _lastActiveValue = isActive;
        // }
        if (!wasActive && isActive){
            // distance = getDistance(_sourceGameObject, _cameraRigRef);
            
            // if (!zeroed)
            // {
                _sourceGameObject.transform.localScale = Vector3.Lerp(
                    originalScale, Vector3.zero, 1.0f
                );
                zeroed = true;
            }
            else 
            {
                _sourceGameObject.transform.localScale = Vector3.Lerp(
                    Vector3.zero, originalScale, 1.0f
                );
                zeroed = false;
            }

        // }

        wasActive = isActive;
    }

    private static float getDistance(GameObject obj1, GameObject obj2) 
    {
        return Vector3.Distance(obj1.transform.position, obj2.transform.position);
    }
}
