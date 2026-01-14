using Botiga.Model;

namespace Botiga.Descomptes;

public class DescompteEstandard : IDescompte
{

    public decimal CalcularDte(decimal import)
    {
   
        
        decimal descompte = import * 0.05m;

        return descompte;
    
    }

}