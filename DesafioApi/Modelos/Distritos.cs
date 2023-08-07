using System.Text.Json.Serialization;

namespace DesafioApi.Modelos
{


    // Municipio, microregiao, mesoregiao, uf, regiao
    // municipio, microregiao, regiao imediata, regiaointermediara, uf, regiao

    public class IBGEObject
    {
        public int id { get; set; }
        public string nome { get; set; }
        public Municipio municipio { get; set; }
        public UF UF { get; set; }
        public Mesorregiao mesorregiao { get; set; }
        public Regiao Regiao { get; set; }
        public Microrregiao Microrregiao { get; set; }
    }

    public class Municipio
    {
        public int id { get; set; }
        public string nome { get; set; }
        public Microrregiao microrregiao { get; set; }

        [JsonPropertyName("regiao-imediata")]
        public RegiaoImediata regiaoimediata { get; set; }
    }

    public class Microrregiao
    {
        public int id { get; set; }
        public string nome { get; set; }
        public Mesorregiao mesorregiao { get; set; }
    }

    public class Mesorregiao
    {
        public int id { get; set; }
        public string nome { get; set; }
        public UF UF { get; set; }
    }

    public class UF
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public Regiao regiao { get; set; }
        public Microrregiao microrregiao { get; set; }
    }

    public class Regiao
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
    }

    public class RegiaoImediata
    {
        public int id { get; set; }
        public string nome { get; set; }

        [JsonPropertyName("regiao-intermediaria")]
        public RegiaoIntermediaria regiaointermediaria { get; set; }
    }

    public class RegiaoIntermediaria
    {
        public int id { get; set; }
        public string nome { get; set; }
        public UF1 UF { get; set; }
    }

    public class UF1
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public Regiao1 regiao { get; set; }
    }

    public class Regiao1
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
    }





}

