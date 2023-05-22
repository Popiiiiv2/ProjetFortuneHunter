using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestJoueur
{

    private Joueur joueur;

    [SetUp]
    public void Setup()
    {
        GameObject go = new GameObject();
        joueur = go.AddComponent<Joueur>();
        go = new GameObject();
        Plateau plateau = go.AddComponent<Plateau>();
        plateau.creerCases();
        plateau.setNumCase();
        joueur.InitialisationJoueur(plateau);
    }

    [TearDown]
    public void TearDown()
    {
        joueur = null;
    }

    // A Test behaves as an ordinary method
    [Test]
    public void TestInitialisationJoueurCaseDepart()
    {
        int numCase = joueur.getCase().getNumCase();
        Assert.AreEqual(numCase, 0);
    }
}

