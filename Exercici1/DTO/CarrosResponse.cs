﻿using Botiga.Model;

namespace Botiga.DTO;

public record CarrosResponse(Guid Id, string Nom)
{
    public static CarrosResponse FromCarros(Carros carro)
    {
        return new CarrosResponse(carro.Id, carro.Nom);
    }
}
