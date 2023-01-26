using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kadal.Word.Manager
{
    public class KadalManager : MonoBehaviour
    {
        public static KadalManager instance;
        [SerializeField] public List<string> kadalWords = new List<string>();
        [SerializeField] public static List<GameObject> enemyDal = new List<GameObject>();
        [SerializeField] List<GameObject> kadalPrefab = new List<GameObject>();
        [SerializeField] int totalKadal;
        void Start()
        {
            instance = this;
            for (int i = 0; i < totalKadal; i++)
            {
                SpawnObject();
            }
        }
        public void SpawnObject()
        {
            float xPos = Random.Range(Random.Range(-493, -227), Random.Range(-56, 68));
            float zPos = Random.Range(Random.Range(-93, 17), Random.Range(-64, 61));
            int RandomWords = Random.Range(0, kadalWords.Count);
            int RandomSpawn = Random.Range(0, kadalPrefab.Count);
            GameObject SpawningObject = Instantiate(kadalPrefab[RandomSpawn], new Vector3(xPos, 16f, zPos), Quaternion.identity);    
            SpawningObject.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>().text = kadalWords[RandomWords];
            kadalWords.Remove(kadalWords[RandomWords]);
            enemyDal.Add(SpawningObject);
            if(GameData.instance.soundTuyul == true)
            {
                SoundManager.instance.TuyulSpawn();
            }
            if(GameData.instance.soundBabi == true)
            {
                SoundManager.instance.BabiSpawn();
            }
            if(GameData.instance.soundKunti == true)
            {
                SoundManager.instance.KuntiSpawn();
            }
            if(GameData.instance.soundGenderuwo == true)
            {
                SoundManager.instance.GenderuwoSpawn();
            }
        }
        static public bool DieTarget(GameObject daler)
        {
            if (daler.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>().text.Length == 1)
            {
                if(GameData.instance.soundTuyul == true)
                {
                    SoundManager.instance.TuyulDead();
                }
                if(GameData.instance.soundBabi == true)
                {
                    SoundManager.instance.BabiDead();
                }
                if(GameData.instance.soundKunti == true)
                {
                    SoundManager.instance.KuntiDead();
                }
                if(GameData.instance.soundGenderuwo == true)
                {
                    SoundManager.instance.GenderuwoDead();
                }
                Destroy(daler);
                enemyDal.Remove(daler);
                GameManager.instance.score += 100;
                return true;
            }   
            daler.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>().text = daler.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>().text.Substring(1);
            return false;
        }
    }
}

