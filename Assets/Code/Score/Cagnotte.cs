public class Cagnotte : Score
{
    public Cagnotte(){
        this.montant = 0;
    }
    
    public override string ToString() {
        return montant+" €";
    }

    public void reinitialiserCagnotte(){
        this.montant = 0;
    }

}
