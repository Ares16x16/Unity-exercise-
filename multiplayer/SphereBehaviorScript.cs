using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SphereBehaviorScript : MonoBehaviour
{
    // sphere’s Max/Min scale
    public float mScaleMax = 2f;
    public float mScaleMin = 0.5f;
    // Orbit max Speed
    public float mOrbitMaxSpeed = 30f;
    // Orbit speed
    private float mOrbitSpeed;
    // Anchor point for the Sphere to rotate around
    private Transform mOrbitAnchor;
    // Orbit direction
    private Vector3 mOrbitDirection;
    // Max Sphere Scale
    private Vector3 mSphereMaxScale;
    // Growing Speed
    public float mGrowingSpeed = 10f;
    private bool mIsSphereScaled = false;
    void Start()
    {
        SphereSettings();
    }
    // Set initial sphere settings
    private void SphereSettings()
    {
        // defining the anchor point as the main camera
        mOrbitAnchor = Camera.main.transform;
        // defining the orbit direction
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        mOrbitDirection = new Vector3(x, y, z);
        // defining speed
        mOrbitSpeed = Random.Range(5f, mOrbitMaxSpeed);
        // defining scale
        float scale = Random.Range(mScaleMin, mScaleMax);
        mSphereMaxScale = new Vector3(scale, scale, scale);
        // set Sphere scale to 0, to grow it lates
        transform.localScale = Vector3.zero;

        // Update is called once per frame
        void Update()
        {
            // makes the spehere orbit and rotate
            RotateSphere();
            // scale sphere if needed
            if (!mIsSphereScaled)
                ScaleObj();
        }
        // Scale object from 0 to 1
        private void ScaleObj()
        {
            // growing obj
            if (transform.localScale != mSphereMaxScale)
                transform.localScale = Vector3.Lerp(transform.localScale, mSphereMaxScale, Time.deltaTime *
                mGrowingSpeed);
            else
                mIsSphereScaled = true;
        }

        // Makes the sphere rotate around a anchor point
        // and rotate around its own axis
        private void RotateSphere()
        {
            // rotate sphere around camera
            transform.RotateAround(
            mOrbitAnchor.position, mOrbitDirection, mOrbitSpeed * Time.deltaTime);
            // rotating around its axis
            transform.Rotate(mOrbitDirection * 30 * Time.deltaTime);
        }
    }
}