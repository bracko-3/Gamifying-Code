using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;

public class User
{
    public string name;
    public int score;

    public User(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
