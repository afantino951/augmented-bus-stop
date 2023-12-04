using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Locomotion;
using UnityEngine;

namespace Oculus.Interaction.Samples
{
    public class ThumbReturn : MonoBehaviour
    {
        private bool isThumbup = false;
        [SerializeField] private ActiveStateSelector thumbup;
        [SerializeField] private GameObject _sourceGameObject;
        [SerializeField] private GameObject _illusionGameObject;
        [SerializeField] private Transform _rightFingertip;
        [SerializeField] private Transform _leftFingertip;

        private float distanceRight;
        private float distanceLeft;

        private float touch_threshold = 0.1f;
        private float iniTime;
        
        private bool isHit = false;
        private bool in_time = true;
        private Vector3 initialPos = new Vector3(-2.0f, 2.5f, 3.0f);

        // Start is called before the first frame update
        void Start()
        {
            thumbup.WhenSelected += () => {isThumbup = true;};
            thumbup.WhenUnselected += () => {isThumbup = false;};
            _sourceGameObject.transform.position = initialPos;
            _sourceGameObject.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            distanceLeft = DistanceCalculator(_sourceGameObject, _leftFingertip);
            distanceRight = DistanceCalculator(_sourceGameObject, _rightFingertip);
            isHit = ((distanceLeft < touch_threshold) || (distanceRight < touch_threshold));
            
            //if(isHit) Fly();
            if(isHit && in_time) {
                iniTime = Time.time;
                in_time = false;
            }
            else if(!isHit) in_time = true;

            if(Time.time - iniTime >= 0 && isHit) Fly();

            //if(isThumbup) Fly();
        }

        private void Fly()
        {
            _sourceGameObject.transform.position = initialPos;
            _sourceGameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        private float DistanceCalculator(GameObject target, Transform fingertip)
        {
            float dis = 0;
            dis = Vector3.Distance(target.transform.position, fingertip.position);
            return dis;
        }
    }
}