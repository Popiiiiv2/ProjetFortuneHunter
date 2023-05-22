using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestJeu
{

    private Jeu jeu;

    [SetUp]
    public void Setup()
    {
        GameObject go = new GameObject();
        jeu = go.AddComponent<Jeu>();
    }

    [TearDown]
    public void TearDown()
    {
        jeu = null;
    }

    [Test]
    public void TestJeu1()
    {

    }
}
