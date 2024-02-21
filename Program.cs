namespace Test_hiplatform
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculando custo do produto");
            CalculadoraPrecoProduto calculadoraPrecoProduto = new CalculadoraPrecoProduto(20, 5);

            double custoProduto = calculadoraPrecoProduto.CalcularCustoProduto(10, 1, true, true);
            Console.WriteLine("Custo do produto: {0}", custoProduto);

            double preco = calculadoraPrecoProduto.FormulaMagica(custoProduto, 10);
            Console.WriteLine("Preço do produto: {0}", preco);

            Console.ReadKey();
        }
    }
}