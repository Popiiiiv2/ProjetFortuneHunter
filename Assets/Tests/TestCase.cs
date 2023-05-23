using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestCase
{

    private Case cases;

    [SetUp]
    public void Setup()
    {
        GameObject go = new GameObject();
        cases = go.AddComponent<Case>();
        cases.setNumCase(3);
    }

    [TearDown]
    public void TearDown()
    {
        cases = null;
    }


    [Test]
    public void testNumCase(){
        Assert.AreEqual(cases.getNumCase(), 3);
    }

    [Test]
    public void testTypeCaseDimanche(){
        cases.setTypeCase(TypeCase.DIMANCHE);
         Assert.AreEqual(cases.getTypeCase(), TypeCase.DIMANCHE);
    }

    [Test]
    public void testTypeCaseBrocante(){
        cases.setTypeCase(TypeCase.BROCANTE);
         Assert.AreEqual(cases.getTypeCase(), TypeCase.BROCANTE);
    }

    [Test]
    public void testTypeCaseEvenement(){
        cases.setTypeCase(TypeCase.EVENEMENT);
         Assert.AreEqual(cases.getTypeCase(), TypeCase.EVENEMENT);
    }

    [Test]
    public void testTypeCaseMail(){
        cases.setTypeCase(TypeCase.MAIL);
        Assert.AreEqual(cases.getTypeCase(), TypeCase.MAIL);
    }

    [Test]
    public void testTypeCasePaye(){
        cases.setTypeCase(TypeCase.PAYE);
        Assert.AreEqual(cases.getTypeCase(), TypeCase.PAYE);
    }

}