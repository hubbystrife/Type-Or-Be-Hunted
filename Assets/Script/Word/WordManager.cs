using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    public GameObject tuyul;
    private bool hasActiveWord;
    private Word activeWord;
    public WordSpawner wordSpawner;
    private int length;

    private void Update()
    {
        AddWord();
        if (words.Count == 0)
        {
            GameData.instance.Score += 100;
            Destroy(this.tuyul);
            SoundManager.instance.TuyulDead();
        }
    }


    public void AddWord()
    {
        if (length < 1 ) 
        {
            Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
            Debug.Log(word.word);

            words.Add(word);
            length+=1;
        }
        
    }

    public void TypeLetter (char letter)
    {
        if(hasActiveWord)
        {
            if(activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach(Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }
        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
}
