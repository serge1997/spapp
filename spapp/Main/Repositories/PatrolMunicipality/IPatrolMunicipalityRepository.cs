﻿using spapp.Http.Requests;
using spapp.Models;

namespace spapp.Main.Repositories.PatrolMunicipality
{
    public interface IPatrolMunicipalityRepository
    {
        void Create(PatrolRequest request, PatrolModel patrol);
    }
}
