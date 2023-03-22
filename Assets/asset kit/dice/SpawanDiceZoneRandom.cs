
using UnityEngine;

public class SpawanDiceZoneRandom : MonoBehaviour
{
   [SerializeField]
   private GameObject cubePrefab;
   
    [SerializeField] 
    private Vector3 zoneSize;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject instantiated = Instantiate(cubePrefab);

            instantiated.transform.position = new Vector3(
                Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x/2),
                Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y/2),
                Random.Range(transform.position.z - zoneSize.z / 2, transform.position.z + zoneSize.z/2)


            );
        }
    }

    private void OnDrawGizmos(){

        Gizmos.color = Color.yellow; 
        Gizmos.DrawWireCube(transform.position, zoneSize);
    }
}
