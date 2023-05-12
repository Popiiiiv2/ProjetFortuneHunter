using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cartes;

public class Joueur : MonoBehaviour
{
    public Jeu jeu;
    public Plateau plateau;
    public GameObject prefabObjetCarte;
    public GameObject prefabObjetBrocante;
    public GameObject prefabObjetJoueur;
    private Case casePlateau;
    private NewDice de;
    private bool tourFini;
    private int moisActuel;
    private CarteControleur paquet;
    private HudJoueur hudJoueur;
    private string prefabName;
    private const float TEMPS_ATTENTE = 0.5f;
    private const int NB_JOUR_MAX = 31;

    public IEnumerator effectuerUnTour(){
        tourFini = false;
        de.lancerDe();
        while(de.getValeurDe() == 0){
            yield return new WaitForSeconds(TEMPS_ATTENTE);
        }
        avancer(de.getValeurDe());
    }

    public void avancer(int valeurDe)
    {
        int numCaseFinale = valeurDe + casePlateau.getNumCase();
        if (numCaseFinale >= NB_JOUR_MAX)
        {
            numCaseFinale = NB_JOUR_MAX;
            moisActuel++;
        }
        StartCoroutine(deplacerJoueur(numCaseFinale));
    }
    //tour du joueur
    IEnumerator deplacerJoueur(int numCaseFinale)
    {
        CarteData carteData = new CarteData();
        int numCasePlateauSuivante = casePlateau.getNumCase() + 1;
        yield return new WaitForSeconds(TEMPS_ATTENTE);
        for (int i = numCasePlateauSuivante; i <= numCaseFinale; i++)
        {
            Case caseSuivante = plateau.getCase(i);
            this.transform.position = caseSuivante.transform.position;
            yield return new WaitForSeconds(TEMPS_ATTENTE);
        }
        casePlateau = plateau.getCase(numCaseFinale);
        paquet = jeu.paquets.getPaquet(casePlateau.getTypeCase());
        carteData = paquet.tirerRandomCarte();
        chargerPrefab(carteData);
        afficherTexteCarte(carteData);
        hudJoueur.setScore(carteData);
        supprimerPrefab();
        yield return new WaitForSeconds(TEMPS_ATTENTE);
        tourFini = true;
    }

    public Case getCase()
    {
        return this.casePlateau;
    }

    public bool isTourFini()
    {
        return tourFini;
    }

    public int getMoisMax(){
        return moisActuel;
    }

    // Start is called before the first frame update
    void Start()
    {
        caseDepart();
        de = GameObject.Find("Button").GetComponent<NewDice>();
        this.moisActuel = 1;
    }

    public void caseDepart()
    {
        this.casePlateau = plateau.caseDebutPartie();
        this.transform.position = casePlateau.transform.position;
    }

    private void chargerPrefab(CarteData carteData){
        if(carteData.getType() == "Brocante"){
            GameObject nouvelObjet = Instantiate(prefabObjetBrocante);
            prefabName = "PrefabCarteBrocante(Clone)";
        } else {
            GameObject nouvelObjet = Instantiate(prefabObjetCarte);
            prefabName = "PrefabCarte(Clone)";
        }
    }

    private void supprimerPrefab(){
        GameObject objetASupprimer = GameObject.Find(prefabName);
        if (objetASupprimer != null){
            Destroy(objetASupprimer,2);
        }else{
            Debug.LogError("L'objet à supprimer n'a pas été trouvé dans la scène.");
        }
    }

    public void afficherTexteCarte(CarteData carteData){
        GameObject textObject = GameObject.Find("Carte_text");
        Text composantTexte = textObject.GetComponent<Text>();
        composantTexte.text = carteData.getDescription();

        textObject = GameObject.Find("CarteTitle_text");
        composantTexte = textObject.GetComponent<Text>();
        composantTexte.text = carteData.getType();

        textObject = GameObject.Find("CarteAction_text");
        composantTexte = textObject.GetComponent<Text>();
        composantTexte.text = "Gain : " + carteData.getValeur();

        switch(carteData.getAction()){
            case "Gain": 
                composantTexte.text = "Gagner : " + carteData.getValeur();
            break;
            case "Perte": 
                composantTexte.text = "Payer : " + carteData.getValeur();
            break;
            default : 
            composantTexte.text = "";
            break;
        }
    }

    public void initialiserScoreJoueur(HudJoueur hudJoueur){
        this.hudJoueur = hudJoueur;
    }
}
