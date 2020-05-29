using System.Collections.Generic;

namespace FilmWebAPI.Requests.Get
{
    public enum ProfessionType
    {
        scenarzysta,
        scenarzystka,
        reżyser,
        reżyserka,
        zdjęcia,
        muzyka,
        scenografia,
        aktor__ka, /* aktor lub aktorka */
        aktorka,
        aktor,
        zespół,
        producent,
        producentka,
        montaż,
        kostiumy,
        materiały_do_scenariusza,
        dźwięk,
        materiały_archiwalne,
        głos,
        we_własnej_osobie,
        gościnnie,
        puste,
    }

    public static class ProfessionTypeMap
    {
        public static Dictionary<int, List<ProfessionType>> Instance = new Dictionary<int, List<ProfessionType>>
        {
            {1, new List<ProfessionType> {ProfessionType.scenarzysta, ProfessionType.scenarzystka}},
            {2, new List<ProfessionType> {ProfessionType.reżyser, ProfessionType.reżyserka}},
            {3, new List<ProfessionType> {ProfessionType.zdjęcia}},
            {4, new List<ProfessionType> {ProfessionType.muzyka}},
            {5, new List<ProfessionType> {ProfessionType.scenografia}},
            {6, new List<ProfessionType> {ProfessionType.aktor__ka, ProfessionType.aktorka, ProfessionType.aktor, ProfessionType.zespół}},
            {7, new List<ProfessionType> {ProfessionType.producent, ProfessionType.producentka}},
            {10, new List<ProfessionType> {ProfessionType.montaż}},
            {12, new List<ProfessionType> {ProfessionType.kostiumy}},
            {17, new List<ProfessionType> {ProfessionType.materiały_do_scenariusza}},
            {18, new List<ProfessionType> {ProfessionType.dźwięk}},
            {19, new List<ProfessionType> {ProfessionType.materiały_archiwalne}},
            {20, new List<ProfessionType> {ProfessionType.głos}},
            {21, new List<ProfessionType> {ProfessionType.we_własnej_osobie, ProfessionType.puste, ProfessionType.puste, ProfessionType.zespół}},
            {22, new List<ProfessionType> {ProfessionType.gościnnie}},
        };
    }
}