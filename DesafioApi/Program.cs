using DesafioApi.Filtros;
using DesafioApi.Modelos;
using System.Text.Json;
using System.Net.Http;
using System.Net;
using static DesafioApi.Modelos.IBGEObject;





// Municipio, microregiao, mesoregiao, uf, regiao
// municipio, microregiao, regiao imediata, regiaointermediara, uf, regiao
using (HttpClient cliente = new HttpClient())
{
    try
    {
        using var httpClient = new HttpClient();
        string resposta = await cliente.GetStringAsync("https://servicodados.ibge.gov.br/api/v1/localidades/distritos");
        var ibge = JsonSerializer.Deserialize<List<IBGEObject>>(resposta)!;


        //1 - Trazer o "Nome da cidade, Estado, Mesoregião, Região"
        //LinqFiltros.NomeRegioes(ibge);

        // 2 - Valores ordenados de ordem alfabética
        //LinqFiltros.ordemalfabetica(ibge);

        // 3 - Todas as cidades que começam com a letra a
        //LinqFiltros.FiltrarLetraA(ibge, 'A');

        //4 - Todas as cidades com nomes simples
        //LinqFiltros.NomeSimples(ibge);

        //5 - Todas as cidades com nomes compostos
        //LinqFiltros.FiltrarNomesCompostos(ibge);

        //6 - Todas as cidades que tenham 3 ou mais palavras
        //LinqFiltros.TresOuMaisPalavras(ibge);

        //7 - cidades que tenham acento no nome
        //LinqFiltros.PalavrasComAcento(ibge);

        //8 - Lista de cidades agrupadas por estado
        //LinqFiltros.CidadesAgrupadasPorEstado(ibge);

        //9 - Lista de cidades agrupadas por região
        //LinqFiltros.CidadesAgrupadasPorRegiao(ibge);

        //10 - Lista de cidades agrupadas por estado e região
        //LinqFiltros.FiltrarCidadesPorEstadoRegiao(ibge);

        // Bonus - Lista de cidades agrupadas por estado e mesoregião e que a mesoregião comece com a letra "A" 
        LinqFiltros.FiltrarCidadeMesoRegiaoComA(ibge);

    }
    catch (Exception ex)
    {
        Console.WriteLine($" Há um erro em alguma parte do código, favor verificar : {ex}");
    }




}