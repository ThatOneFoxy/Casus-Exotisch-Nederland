public class WaarnemingService {
    private readonly WaarnemingRepository _repository;

    public WaarnemingService() {
        _repository = new WaarnemingRepository();
    }

    public void RegistreerWaarneming(Waarneming waarneming) {
        _repository.VoegWaarnemingToe(waarneming);
    }

    public List<Waarneming> HaalAlleWaarnemingenOp() {
        return _repository.HaalAlleWaarnemingenOp();
    }

    public bool UpdateWaarneming(int waarnemingID, Waarneming waarneming) {
        _repository.VeranderWaarneming(waarnemingID, waarneming);
        return true;
    }

    public bool VerwijderWaarneming(int waarnemingID) {
        _repository.VerwijderWaarneming(waarnemingID);
        return true;
    }
}