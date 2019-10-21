using UnityEngine;
using System.Collections;
using UnityEngine.UI; //so we can reference a text object

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public Text waveCountDownText;
    private int waveIndex = 0;

        void Update()
        {
         //Spawns waves
         if (countdown <= 0f)
         {
             StartCoroutine(SpawnWave()); //runs the coroutine specified as Spawnwave
             countdown = timeBetweenWaves;
         }

            //after every wave, the countdown shortens
            countdown -= Time.deltaTime;

            //MathF.Floor cuts off all the decimal places and only leaves the first one
            //TLDR; it rounds down to an integer, but keeps it as a float
            waveCountDownText.text = Mathf.Round(countdown).ToString();
        }

        //IEnumerator allows us to pause this code segment, whereas void doesn't
        IEnumerator SpawnWave () 
        {
            waveIndex++;

            for (int i = 0; i < waveIndex; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f); 
            }
            
        }

        void SpawnEnemy ()
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
}
