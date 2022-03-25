using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToolGenerator : MonoBehaviour
{
    public GameObject[] handleParts;
    public GameObject[] headParts;
    int arrayPositionHead;
    public int arrayPosHead
    {
        get { return arrayPositionHead; }
        set
        {
            if (value > headParts.Length - 1)
            {
                value = 0;
                arrayPositionHead = value;
            }
            else if (value < 0)
            {
                value = headParts.Length - 1;
                arrayPositionHead = value;
            }
            else
            {
                arrayPositionHead = value;
            }
        }

    }
    int arrayPositionHandle;
    public int arrayPosHandle
    {
        get { return arrayPositionHandle; }
        set
        {
            if (value > handleParts.Length - 1)
            {
                value = 0;
                arrayPositionHandle = value;
            }
            else if (value < 0)
            {
                value = handleParts.Length - 1;
                arrayPositionHandle = value;
            }
            else
            {
                arrayPositionHandle = value;
            }
        }
    }

    public Vector3 spawningVector;

    public GameObject newWeaponPrefab;
    public GameObject spawnArea;
    public GameObject newWeapon;
    public GameObject instHandle;
    public ToolHandle toolHandle;
    public GameObject instHead;

    
    // Start is called before the first frame update
    void Start()
    {
        // Defines spawningVector as 0, in order to center any items instantiated with it in the BuildingScene and defines the ToolGenerator as non-destructible to perserve data
        spawningVector = Vector3.zero;
        DontDestroyOnLoad(this);
    }

    // Button function to jump to TestingArea (next scene), IF a tool has been created
    public void TestSceneStart()
    {
        if (newWeapon != null)
        {
            SceneManager.LoadScene("TestingArea");
        }
    }

    // Function to verify if there's an already spawned weapon before randomizing it. This deletes the whole object and spawns a new one
    public void CheckWeaponSpawn()
    {
        if(newWeapon!= null)
        {
            Destroy(newWeapon);
            
        }
        ToolRandomSpawn();
    }

    // Button function to remove 1 value to the integer of the Head's Array ID and change it for the previous prafab
    public void LastHeadSpawn()
    {
        arrayPosHead--;
        createWeapon();
    }

    // Button function to add 1 value to the integer of the Head's Array ID and change it for the next prefab
    public void NextHeadSpawn()
    {
        arrayPosHead++;
        createWeapon();
    }

    // Button function to remove 1 value to the integer of the Handle's Array ID and change it for the previous prafab
    public void LastHandleSpawn()
    {
        arrayPosHandle--;
        createWeapon();
    }

    // Button function to add 1 value to the integer of the Handle's Array ID and change it for the next prefab
    public void NextHandleSpawn()
    {
        arrayPosHandle++;
        createWeapon();
    }

    // Function that randomly spawns a complete object. Is run at the end of CheckWeaponSpawn, in order to verify if there's another weapon when it's executed and destroy it
    public void ToolRandomSpawn()
    {
        newWeapon = Instantiate(newWeaponPrefab, spawningVector, Quaternion.identity, spawnArea.transform);

        arrayPosHandle = getRandomHandle();

        arrayPosHead = getRandomHead();

        createWeapon();
    }

    // Integer value that is used by ToolRandomSpawn to decide a random value for the Handle Array's ID
    public int getRandomHandle()
    {
       return Random.Range(0, handleParts.Length);
        
    }

    // Integer value that is used by ToolRandomSpawn to decide a random value for the Head Array's ID
    public int getRandomHead()
    {
        return Random.Range(0, headParts.Length);
    }

    // Function that is run everytime a new component is spawned, in order to store information of which components are part of the weapon
    public void createWeapon()
    {
        if (newWeapon != null)
        {
            Destroy(newWeapon);
        }
        newWeapon = Instantiate(newWeaponPrefab, spawningVector, Quaternion.identity, spawnArea.transform);
        instHandle = Instantiate(handleParts[arrayPosHandle], Vector3.zero, Quaternion.identity, newWeapon.transform);
        toolHandle = instHandle.GetComponent<ToolHandle>();
        instHead = Instantiate(headParts[arrayPosHead], toolHandle.headConnection.position, headParts[arrayPosHead].transform.rotation, newWeapon.transform);
    }
}