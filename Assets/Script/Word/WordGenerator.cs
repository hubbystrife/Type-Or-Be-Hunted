using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = {"crush","ritzy","carve","helpful","automatic","thought","rhyme","hum","friendly","harbor","aggressive","literate","clean","cuddly","roasted","alarm","optimal"
                                        ,"spoon","sponge","snails","marvelous","calculator","property","hard","porter","jump","snake","canvas","frantic","pricey","visit","bag","sulky"
                                        ,"appreciate","savory","bottle","jellyfish","kitty","thoughtless","spark","noisy","hook","enjoy","purple","innate","courageous","handsomely","fasten","believe","pet"};

    public static string GetRandomWord()
    {
        int randomIndex=Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }
}
