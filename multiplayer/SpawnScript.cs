using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class SpawnScript : MonoBehaviour
{
    // Define the position of the object according to ARCamera position
    // Sphere element to spawn
    public GameObject mSphereObj;
    // Qtd of Spheres to be Spawned
    public int mTotalSpheres = 10;
    // Time to spawn the Spheres
    public float mTimeToSpawn = 1f;
    // hold all Spheres on stage
    private GameObject[] mSpheres;
    // define if position was set
    private bool mPositionSet;

    private IEnumerator SpawnLoop()
    {
        // Defining the Spawning Position
        StartCoroutine(ChangePosition());
        yield return new WaitForSeconds(0.2f);
        // Spawning the elements
        int i = 0;
        while (i <= (mTotalSpheres - 1))
        {
            mSpheres[i] = SpawnElement();
            i++;
            yield return new WaitForSeconds(Random.Range(mTimeToSpawn, mTimeToSpawn * 3));
        }

        // Spawn a Sphere
        private GameObject SpawnElement()
        {
            // spawn the element on a random position, inside a imaginary sphere
            GameObject Sphere = Instantiate(mSphereObj, (Random.insideUnitSphere * 4) + transform.position,
            transform.rotation) as GameObject;
            // define a random scale for the Sphere
            float scale = Random.Range(0.5f, 2f);
            // change the Sphere scale
            Sphere.transform.localScale = new Vector3(scale, scale, scale);
            return Sphere;
        }

        private bool SetPosition()
        {
            // get the camera position
            Transform cam = Camera.main.transform;
            // set the position 10 units forward from the camera position
            transform.position = cam.forward * Random.Range(10, 200);
            return true;
        }
        void Start()
        {
            // Initializing spawning loop
            StartCoroutine(SpawnLoop());
            // Initialize Spheres array according to
            // the desired quantity
            mSpheres = new GameObject[mTotalSpheres];
        }

        // We'll use a Coroutine to give a little delay before setting the position
        private IEnumerator ChangePosition()
        {
            yield return new WaitForSeconds(0.2f);
            // Define the Spawn position only once
            if (!mPositionSet)
            {
                // change the position only if Vuforia is active
                if (VuforiaBehaviour.Instance.enabled)
                    SetPosition();
            }
        }
    }
}