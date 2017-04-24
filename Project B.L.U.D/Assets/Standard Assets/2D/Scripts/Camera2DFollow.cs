using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 0;
        public float lookAheadFactor = 1;
        public float lookAheadReturnSpeed = 4.0f;
        public float lookAheadMoveThreshold = 0.0f;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition, r;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        // Use this for initialization
        private void Start()
        {
            r = target.position;
            r.y = r.y + 10;
            m_LastTargetPosition = r;
            m_OffsetZ = (transform.position - r).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
            r = target.position;
            r.y = r.y + 6f;
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (r - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
            }


            Vector3 aheadTargetPos = r + m_LookAheadPos + Vector3.forward * m_OffsetZ;
            Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y + 7, target.transform.position.z - 10f);

            transform.position = newPos;

            m_LastTargetPosition = r;
        }
    }
}
