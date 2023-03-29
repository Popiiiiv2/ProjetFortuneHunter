namespace Cartes
{
    public abstract class Carte
    {
        public string description, titre, type, fichier, action;
        public int valeur, vente, id;
        public abstract string getDescription();

        public abstract string getTitre();

        public abstract string getType();

        public abstract string getFichier();

        public abstract string getAction();

        public abstract int getValeur();

        public abstract int getId();

    }
}