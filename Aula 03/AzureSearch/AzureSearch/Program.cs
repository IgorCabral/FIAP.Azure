using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AzureSearch
{
    class IndexLetras
    {
        [Key]
        [IsRetrievable(true)]
        [IsSortable]
        [IsFilterable]
        public string Id { get; set; }
        [IsRetrievable(true)]
        [IsSortable]
        [IsFilterable]
        public string NomeBanda { get; set; }
        [IsRetrievable(true)]
        [IsSortable]
        [IsFilterable]
        public string Album { get; set; }
        [IsFilterable]
        [IsSortable]
        [IsRetrievable(true)]
        [IsSearchable]
        public string Letra { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var searchServiceClient = new SearchServiceClient("teste-azuresearch-dois", new SearchCredentials("4A91F9970AB73ADB4106D6BC56FD0EE2"));

            var index = searchServiceClient.Indexes.GetClient("index-bandas");
            var index2 = searchServiceClient.Indexes.Get("index-bandas");
            index2.Analyzers.Add(new CustomAnalyzer()
            {
                Name = "custom",
                Tokenizer = TokenizerName.Standard,
                TokenFilters = new[]
                {
                    TokenFilterName.Phonetic, //:O FOnética (thiago / tiago)
                    TokenFilterName.Lowercase,
                    TokenFilterName.AsciiFolding
                }
            });
            index2.Analyzers.Add(new PatternAnalyzer()
            {
                Name = "custom",
                Pattern = @"||,||" //regeeexxxx
            });

            //Settando o analyzer do campo específico, custom foi o nome atribuido
            index2.Fields[3].Analyzer = "custom";

            //Atualizando o sistema para aceitar os filtros criados
            searchServiceClient.Indexes.CreateOrUpdate(index2, true);

            var batch = IndexBatch.Upload<IndexLetras>(new List<IndexLetras>
            {
                new IndexLetras
                {
                    Id = "rm330381",
                    Album = "Nadando com os tubarões",
                    Letra = @"
                        Quem for sangue bom demorou de desenvolver
Saúde tem demais tem pra dar e vender
O rap me diverte, faz eu viajar o mundo
Deus vai me fazer aqui no Brocklin um escudo
Com o tempo, eu fico onde estou, quem vacilou, o esqueleto arrastou
Os homens de preto acionam o dedo (blinck bleu)
Brooklin meu irmão onde eu nasci é cruel
Pra frente aqui vou eu e quem não se envolveu
O meu é partidário vacilou quem prometeu
O ambiente na quebrada é quente meu
Entardeceu vacilou na festa é problema seu
O crime não é crime eu faço parte também
É de lei se respeito é que eu também sei temos que nos preservar
Manter a fé em Deus não pare.
Pode crer Charlie Brown, RZO essa é a família Sabotage Broklin Sul faz a rima.
Salve a favela tô aqui Sabotage,
Desertos, lugar, ligeiro, Criminalidade.

[Refrão]
Ra-tá-tá é bicho solto
Fica ligeiro já faz parte do jogo
Todo cuidado é pouco
Ra-tá-tá é bicho solto

Sandrão aqui convoca os loucos
Entende os outros conhece o jogo
Confiscou aqui só ganha quem supera a morte
no 'corre' só se envolve é quem é forte atitude traz a sorte só dá mole aqui oslock
Quem se envolve não corre das exigências que ocorrem na periferia os piores dias da América Latina
Tem de conviver numa desbaratina rap protetores da periferia vida!
Liga fica de esquina quem deus descrimina vida bandida quantos manos, quantas minas
Tá naquele lá de cima aí ladrão essa é a única alternativa
Só os que servem hip-hop apoiam a greve
Boa peste da nossa inteligência não troca gato por lebre
Microfone, cheque click,cleck,clack, cheque mate, cheque mate!

[Refrão]

RZO, os 'cara'
Rima rica, rima rara
Os pobre fica de cara e a batida aqui não para.
Toda família, mesma família
Os mano aqui são tudo da minha láia, meu escritório é na praia (Você se lembra)
Eles querem te levar
Maloqueiro em carro rico, vão parar pra averiguar
Chego, chego devagar
Chego bem humilde, sei como chegar
Tem, Tem 'pa' mata você,Tem, Tem 'pa' manda buscar
Vai te pru sapão ve, Tem, tem pra te alucinar
Eu não fico dividido, num sei porque tomo batido
Sistema falido, já aconteceu comigo
Zum, Zum, Zum
Cocaína mata um, mata vários, escraviza o mais fraco.
Eu já fui um otário sim, hoje estou bem, já larguei, me curei
Foi bem melhor pra mim, mas conheci vários manos que foram até o fim
Uma horientação a cada esquina, o consumo do alcool te deixa cada vez +louko sim...
Ra - tá - tá é bicho solto, POW, Ra - tá - tá é bicho solto


       Mas pode crer Chorão
       Pirituba é quase igual
       Punk, funk, pagodeiro, curte RZO e Charlie Brown
Som bem legal Racionais melhor ainda se falar da paz
Deus ilumine o graffit
Favela da mandioca tem apetite
vejo pico nosso menino só da humilde que que tem
Pula estação vai de trem vem com nóis
Firme como nossa voz Sandrão, canta
Também cola na banca quem não é se espanta
Descrimina a pampa santa ignorância
Tem que ser igual HC e a banca não manca aumenta a confiança
Esperança é o que não morre não desande faz e corre no skate
Faz até enfeite o Alemão todo dia lá no parque maior viaje
Eu dou valor a arte é ele o toda mão láno parque, no parque tem ganso em toda parte
Mano Sabotagem falou que colar aqui mais tarde
Pode crer você sabe é aquilo
Nosso rap é compromisso e eu prefiro sem vacilo na responsa
humilde eu me sinto pois assim ninguém me afronta
Helião falou e é verdade
É negru - util eu sei de tudo cu de burro pode tudo num segundo mas, eu juro vou rimar
  E vou mostrar que tá no ar música pra respeitar
  O Champignom tá envolvido e todo mundo da baixada
Só a rapa fumaça então que faça
Vamo liberar quem entende e compreeende
tem moral sempre a frente, firmeza total, não se julga o melhor pois Deus é maioral
Quem tá legal fuma o bamba curte RZO e Charlie Brown
[Refrão](2x)

Coração de vagabundo bate na sola do pé skate na veia pau no cú dos mané.

Compositor: Charlie Brown Jr E Rzo
Encontrou algum erro na letra? Por favor, envie uma correção >

Compartilhe
esta música


COMENTAR

                    ",
                    NomeBanda = "Charlie Brown Jr."
                }
            });
           
            //A cada vez que essa linha abaixo é chamada, ela irá inserir um novo registro no searchService
            //index.Documents.Index(batch);

        pesquisarNovamente:
            Console.WriteLine("Digite um termo para a busca:");
            var termo = Console.ReadLine();
            
            var result = index.Documents.Search<IndexLetras>(termo, new SearchParameters()
            {
                IncludeTotalResultCount = true
            });

            Console.WriteLine($"{result.Count} resultados encontrados");
            foreach(var item in result.Results)
            {
                Console.WriteLine($"{item.Document.Id} - {item.Document.NomeBanda}");
            }

            Console.ReadLine();
            goto pesquisarNovamente;
        }
    }
}
