using UnityEngine.AI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Truck : MonoBehaviour
{
    public Transform finish;
    public Image GameOver;
    public Image NextLevel;
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(finish.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision girdi");
        if ( collision.collider.CompareTag("Obstacle") || collision.gameObject.name == "Tornado" )
        {
            Debug.Log("game over");
            GetComponent<NavMeshAgent>().isStopped = true;
            GameOver.gameObject.SetActive(true);
        }

        if ( collision.collider.CompareTag("Finish") )
        {
            Debug.Log("level up");
            GetComponent<NavMeshAgent>().isStopped = true;
            NextLevel.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger girdi");
        if ( other.CompareTag("Obstacle") || other.gameObject.name == "Tornado" )
        {
            Debug.Log("game over");
            GetComponent<NavMeshAgent>().isStopped = true;
            GameOver.gameObject.SetActive(true);
        }

        if ( other.gameObject.name == "Finish" )
        {
            Debug.Log("level up");
            GetComponent<NavMeshAgent>().isStopped = true;
            NextLevel.gameObject.SetActive(true);
        }

        if ( other.gameObject.name == "Finish1" )
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            SceneManager.LoadScene(0);
        }
    }
}
