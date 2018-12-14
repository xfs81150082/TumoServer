using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    [Serializable]
    public enum RoleType
    {
        Player,
        Monster,
        Npcer,
        Engineer,
        Booker,
        Teacher,
        CostEngineer,                  //造价师
        SupervisionEngineer,           //监理师
        BuildEngineer,                 //建造师 
        Administration,
        Valuation,
        Metering,
        Case,
    }
    [Serializable]
    public enum Tribe
    {
        Administration,
        Valuation,
        Metering,
        Case,
    }
    [Serializable]
    public enum PatrolState
    {
        CorePoint,
        RandomPoint,
        IndexPoint,
    }
    [Serializable]
    public enum Grade
    {
        Standard,
        Elite,
        Boss,
    }
       
}
