public class DescompteEstandardFactory : IDescompteFactory
{
    public IDescompte CreateDescompte()
    {
        return new DescompteEstandard();
    }
}
