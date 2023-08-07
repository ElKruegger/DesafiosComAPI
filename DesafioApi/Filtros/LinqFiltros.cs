using DesafioApi.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesafioApi.Modelos.IBGEObject;

namespace DesafioApi.Filtros;

internal class LinqFiltros
{
    //1 - Trazer o "Nome da cidade, Estado, Mesoregião, Região"
    //2 - Valores ordenados de ordem alfabética
    //3 - Todas as cidades que começam com a letra a
    //4 - Todas as cidades com nomes simples
    //5 - Todas as cidades com nomes compostos
    //6 - Todas as cidades que tenham 3 ou mais palavras
    //7 - cidades que tenham acento no nome
    //8 - Lista de cidades agrupadas por estado
    //9 - Lista de cidades agrupadas por região
    //10 - Lista de cidades agrupadas por estado e região



    public static void NomeRegioes(List<IBGEObject> ibge)
    {

        // 1 - Trazer o "Nome da cidade, Estado, Mesoregião, Região"
        var cidade = ibge.Select(ibge => ibge.municipio.nome!).Distinct().ToList();
        var estado = ibge.Select(ibge => ibge.municipio.microrregiao.mesorregiao.UF.nome!).Distinct().ToList();
        var mesoregiao = ibge.Select(ibge => ibge.municipio.microrregiao.mesorregiao.nome!).Distinct().ToList();
        var regiao = ibge.Select(ibge => ibge.municipio.microrregiao.mesorregiao.UF.regiao.nome!).Distinct().ToList();

        Console.WriteLine("Nome dos municipios :");
        foreach (var m in cidade)
        {
            Console.WriteLine($" - {m}");
        }

        Console.WriteLine("Nome dos estados :");
        foreach (var es in estado)
        {
            Console.WriteLine($" - {es}");
        }

        Console.WriteLine("Nome das mesoregiões");
        foreach (var meso in mesoregiao)
        {
            Console.WriteLine($" - {meso}");
        }

        Console.WriteLine("Nome das regiões");
        foreach (var reg in regiao)
        {
            Console.WriteLine($" - {reg}");
        }

    }

    // 2 - Valores ordenados de ordem alfabética

    public static void ordemalfabetica(List<IBGEObject> ibge)
    {
        var ordemalfabetica = ibge
       .OrderBy(ibgeObj => ibgeObj.municipio.microrregiao.mesorregiao.UF.nome)
       .Select(ibgeObj => ibgeObj.municipio.microrregiao.mesorregiao.UF.nome)
       .Distinct()
       .ToList();

        Console.WriteLine(" Estados posicionados em ordem alfabética :");
        foreach (var estado in ordemalfabetica)
        {

            Console.WriteLine($" - {estado}");
        }
    }

    // 3 - Todas as cidades que começam com a letra a

    public static void FiltrarLetraA(List<IBGEObject> ibge, char letra)
    {
        var municipios = ibge.Where(ibge => ibge.municipio.nome.StartsWith(letra)).Select(ibge => ibge.municipio.nome).Distinct().ToList();

        Console.WriteLine(" Municipios que começam com a letra A");

        foreach (var itensWithLetterA in municipios)
        {
            Console.WriteLine($"- {itensWithLetterA}");
        }
    }


    //4 - Todas as cidades com nomes simples

    public static void NomeSimples(List<IBGEObject> ibge)
    {
        var nomesimples = ibge.Where(ibge => ibge.municipio.nome.Split(' ').Length == 1).Select(ibge => ibge.municipio.nome).Distinct().ToList();

        Console.WriteLine(" Municipios que possuem apenas nomes simp´les :");

        foreach (var nomeSimples in nomesimples)
        {
            Console.WriteLine($" - {nomeSimples}");
        }
    }

    //5 - Todas as cidades com nomes compostos

    public static void FiltrarNomesCompostos(List<IBGEObject> ibge) 
    {
        var nomecomposto = ibge.Where(ibge => ibge.municipio.nome.Split(' ').Length == 2).Select(ibge => ibge.municipio.nome).Distinct().ToList();

        Console.WriteLine(" Municipios que possuem nomes compostos :");

        foreach (var nomescompostos in nomecomposto)
        {
            Console.WriteLine($" - {nomescompostos}");
        }
    }


    //6 - Todas as cidades que tenham 3 ou mais palavras

    public static void TresOuMaisPalavras(List<IBGEObject> ibge)
    {
        var nomemunicipios = ibge.Where(ibge => ibge.municipio.nome.Split(' ').Length == 3 || ibge.municipio.nome.Split(' ').Length == 4).Select(ibge => ibge.municipio.nome).Distinct().ToList();

        Console.WriteLine(" Municipios que possuem 3 ou mais palavras");

        foreach (var tresoumais in nomemunicipios)
        {
            Console.WriteLine($" - {tresoumais}");
        }
    }


    //7 - cidades que tenham acento no nome

    public static void PalavrasComAcento(List<IBGEObject> ibge)
    {
        char[] acentuacao = new char[] { 'Á', 'À', 'Ã', 'Â', 'É', 'È', 'Ê', 'Í', 'Ì', 'Î', 'Ó', 'Ò', 'Ô', 'Õ', 'Ú', 'Ù', 'Û', '´', '`', '~', '^', '-' };

        var palavraacentuada = ibge.Select(ibge => ibge.municipio.nome).Where(ibge => ibge.Any(c => acentuacao.Contains(c))).Distinct().ToList();

        Console.WriteLine(" Municipios que possuem acentuação em seus nomes");

        foreach (var nomesAcentuados in palavraacentuada)
        {
            Console.WriteLine($" - {nomesAcentuados}");
        }
    }

    //8 - Lista de cidades agrupadas por estado

    public static void CidadesAgrupadasPorEstado(List<IBGEObject> ibge)
    {
        var municipiosPorEstado = ibge.GroupBy(ibge => ibge.municipio.microrregiao.mesorregiao.UF.nome).Distinct().ToList();

        Console.WriteLine(" Lista de municipios agrupados por estado :");

        foreach (var municipiosEstados in municipiosPorEstado)
        {
            Console.WriteLine();
            Console.WriteLine($"  - - - - - - -   Estado : {municipiosEstados.Key}");
            foreach (var municipios in municipiosEstados)
            {
                Console.WriteLine($" - {municipios.nome}");
            }
            
        }
    }

    //9 - Lista de cidades agrupadas por região
    
    public static void CidadesAgrupadasPorRegiao(List<IBGEObject> ibge)
    {
        var municipiosporregiao = ibge.GroupBy(ibge => ibge.municipio.microrregiao.mesorregiao.UF.regiao.nome).Distinct().ToList();

        Console.WriteLine(" Lista de municipios agrupados por Região :");

        foreach (var regiao in municipiosporregiao)
        {
            Console.WriteLine();
            Console.WriteLine($" - - - - - - - - Região : {regiao.Key}");
            foreach (var municipios in municipiosporregiao)
            {
                Console.WriteLine($" - {municipios.Key}");
            }
        }
    }

    //10 - Lista de cidades agrupadas por estado e região
    public static void FiltrarCidadesPorEstadoRegiao(List<IBGEObject> ibge)
    {
        var cidadeEstadoRegiao = ibge.GroupBy(ibge => ibge.municipio.microrregiao.mesorregiao.UF.regiao.nome).Distinct().ToList();

        Console.WriteLine(" Lista de municipios agrupados por estado e região");

        foreach (var regiao in cidadeEstadoRegiao)
        {
            Console.WriteLine();
            Console.WriteLine($" regiao {regiao.Key}");
            foreach (var estado in regiao)
            {
                Console.WriteLine($" Estado {estado.municipio.microrregiao.mesorregiao.UF.nome}");

                foreach(var municipio in estado.municipio.nome)
                {
                    Console.WriteLine($" municipio {municipio}");
                }
            }
        }
    }


}
