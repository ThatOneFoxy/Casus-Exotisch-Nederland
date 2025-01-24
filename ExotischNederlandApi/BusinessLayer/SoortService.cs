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

    public bool UpdateSoort(int soortID, Soort soort)
    {
        _repository.VeranderSoort(soortID, soort);
        return true;
    }


    public bool VerwijderSoort(int soortID)
    {
        _repository.VerwijderSoort(soortID);
        return true;
    }
}