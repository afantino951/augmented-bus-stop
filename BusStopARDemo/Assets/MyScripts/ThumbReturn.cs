using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Oculus.Interaction.Samples
{
    public class ThumbReturn : MonoBehaviour
    {
        private bool isThumbup = false;
        private bool isThumbdown = false;
        [SerializeField] private ActiveStateSelector thumbup;
        [SerializeField] private ActiveStateSelector thumbdown;
        [SerializeField] private GameObject _sourceGameObject;

        private Vector3 scale_inc = new Vector3(0.01f,0.01f,0.01f);

	private float distance;

        // Start is called before the first frame update
        void Start()
        {
            thumbup.WhenSelected += () => {isThumbup = true;};
            thumbup.WhenUnselected += () => {isThumbup = false;};
            thumbdown.WhenSelected += () => {isThumbdown = true;};
            thumbdown.WhenUnselected += () => {isThumbdown = false;};
        }

        // Update is called once per frame
        void Update()
        {
            if(isThumbup) Sizeup();
            if(isThumbdown) Sizedown();
        }

        private void Sizeup()
        {
            _sourceGameObject.transform.position = _sourceGameObject.transform.position - _sourceGameObject.transform.position;
            Debug.Log("thumb up detected");
        }

        private void Sizedown()
        {
            if (_sourceGameObject.transform.localScale.y > 0)
            {
                _sourceGameObject.transform.localScale -= scale_inc;
                Debug.Log("thumb down detected");
            }
            Debug.Log("thumb down is detected!");
            
        }
    }
}