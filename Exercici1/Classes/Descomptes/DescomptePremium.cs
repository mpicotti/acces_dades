public class DescomptePremium
{
    private readonly IDescompte _descompte;

    public DescomptePremium(IDescompte descompte)
    {
        _descompte = descompte;
    }

    public void StartDescompte()
    {
        _descompte.Start();
    }
}