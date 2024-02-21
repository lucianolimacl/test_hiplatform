using Test_hiplatform.Models;

namespace Test_hiplatform
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Questão 2: ");

            Console.WriteLine("Calculando custo do produto");
            CalculadoraPrecoProduto calculadoraPrecoProduto = new CalculadoraPrecoProduto(20, 5);

            double custoProduto = calculadoraPrecoProduto.CalcularCustoProduto(10, 1, true, true);
            Console.WriteLine("Custo do produto: {0}", custoProduto);

            double preco = calculadoraPrecoProduto.FormulaMagica(custoProduto, 10);
            Console.WriteLine("Preço do produto: {0}", preco);

            Console.WriteLine("");

            Console.WriteLine("Questão 3: ");

            RelatorioEleitoresPorRua relatorioEleitoresPorRua = new RelatorioEleitoresPorRua();

            var casas = GerarListaCasas();

            var ruasOrdenandaPorEleitores = relatorioEleitoresPorRua.ObterRuasOrdenandaPorEleitores(casas);

            Console.WriteLine("Rua com mais eleitores: {0}", ruasOrdenandaPorEleitores.FirstOrDefault()?.Nome);

            Console.ReadKey();
        }

        private static List<Casa> GerarListaCasas()
        {
            return new List<Casa>
            {
                new Casa
                {
                    Rua = new Rua
                    {
                        Cep = "81925100",
                        Nome = "Major miguel balbino blasi"
                    },
                    Numero = 100,
                    TotalEleitores = 10,
                },
                new Casa
                {
                    Rua = new Rua
                    {
                        Cep = "81925200",
                        Nome = "Castelo branco"
                    },
                    Numero = 100,
                    TotalEleitores = 20,
                },
            };
        }
    }
}