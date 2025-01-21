public class SoortService
{
    private readonly SoortRepository _repository;

    public SoortService()
    {
        _repository = new SoortRepository();
    }

    public void RegistreerSoort(Soort soort)
    {
        _repository.VoegSoortToe(soort);
    }

    public List<Soort> HaalAlleSoortenOp()
    {
        return _repository.HaalAlleSoortenOp();
    }

    public bool UpdateSoort(string soortNaam, Soort soort)
    {
        _repository.VeranderSoort(soort);
        return true;
    }


    public bool VerwijderSoort(String naam)
    {
        //TODO: implementeer 
        //var soort = _repository.HaalInheemseSoortOp(naam);
        //if (soort == null)
        //{
        //    return false;
        //}

        _repository.VerwijderSoort(naam);
        return true;
    }
}