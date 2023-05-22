using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestJoueur
{

    private Joueur joueur;
    private HudJoueur hudJoueur;

    [SetUp]
    public void Setup()
    {
        GameObject go = new GameObject();
        joueur = go.AddComponent<Joueur>();
        go = new GameObject();
        Plateau plateau = go.AddComponent<Plateau>();
        plateau.creerCases();
        plateau.setNumCase();
        hudJoueur = go.AddComponent<HudJoueur>();
        hudJoueur.initialisationScore();
        joueur.initialisationJoueur(plateau);
        joueur.initialiserScoreJoueur(hudJoueur);
    }

    [TearDown]
    public void TearDown()
    {
        joueur = null;
        hudJoueur = null;
    }

    // A Test behaves as an ordinary method
    [Test]
    public void TestInitialisationJoueurCaseDepart()
    {
        int numCase = joueur.getCase().getNumCase();
        Assert.AreEqual(numCase, 0);
    }

    [Test]
    public void TestInitialisationJoueurMoisDeDepart()
    {
        int moisActuel = joueur.getMoisMax();
        Assert.AreEqual(moisActuel, 1);
    }

    [Test]
    public void TestInitialisationJoueurArgent()
    {
        Assert.AreEqual(joueur.getArgent(), 650);
    }

    [Test]
    public void TestInitialisationJoueurPaye()
    {
        joueur.obtenirPaye();
        Assert.AreEqual(joueur.getArgent(), 2150);
    }

    [UnityTest]
    public IEnumerator TestAvancerCaseFinale()
    {
        int valeurDe = 2;
        int numCaseAttendue = 2;
        joueur.avancer(valeurDe);

        yield return null; 

        // Assert
        Assert.AreEqual(numCaseAttendue, joueur.getCase().getNumCase());
    }
}

